using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Falko.Logging.Providers;

internal sealed class ProcessorDateTimeOffsetProvider : IDateTimeOffsetProvider
{
    private const long CachedTimeUpdateThresholdMilliseconds = 8;

    private readonly Stopwatch _stopwatch;

    private readonly long _stopwatchTicksThreshold;

    private readonly double _stopwatchTicksRatio;

    private DateTimeOffsetSnapshot _snapshot;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ProcessorDateTimeOffsetProvider()
    {
        _stopwatch = Stopwatch.StartNew();

        var stopwatchTicksThreshold = Stopwatch.Frequency * CachedTimeUpdateThresholdMilliseconds / 1000;
        _stopwatchTicksThreshold = stopwatchTicksThreshold <= 0 ? 1 : stopwatchTicksThreshold;

        _stopwatchTicksRatio = (double)TimeSpan.TicksPerSecond / Stopwatch.Frequency;

        var rootUtcTime = DateTime.UtcNow;
        var rootOffsetTime = TimeZoneInfo.Local.GetUtcOffset(rootUtcTime);

        _snapshot = new DateTimeOffsetSnapshot
        {
            SnapshotVersion = 0,
            LocalTicks = rootUtcTime.Ticks + rootOffsetTime.Ticks,
            LocalOffset = rootOffsetTime,
            StopwatchTicks = _stopwatch.ElapsedTicks
        };
    }

    public DateTimeOffset Now
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            RetryRead:

            var snapshotVersionToRead = Volatile.Read(ref _snapshot.SnapshotVersion);

            if ((snapshotVersionToRead & 1) != 0)
            {
                goto RetryRead;
            }

            var currentSnapshot = _snapshot;

            var currentLocalTicks = currentSnapshot.LocalTicks;
            var currentLocalOffset = currentSnapshot.LocalOffset;
            var currentStopwatchTicks = currentSnapshot.StopwatchTicks;

            var snapshotVersionToWrite = Volatile.Read(ref _snapshot.SnapshotVersion);

            if (snapshotVersionToRead != snapshotVersionToWrite
                || (snapshotVersionToWrite & 1) != 0)
            {
                goto RetryRead;
            }

            var deltaStopwatchTicks = _stopwatch.ElapsedTicks - currentStopwatchTicks;

            if (deltaStopwatchTicks < _stopwatchTicksThreshold)
            {
                var addDeltaTicks = (long)(deltaStopwatchTicks * _stopwatchTicksRatio);
                return new DateTimeOffset(currentLocalTicks + addDeltaTicks, currentLocalOffset);
            }

            if (Interlocked.CompareExchange(ref _snapshot.SnapshotVersion,
                    snapshotVersionToWrite + 1,
                    snapshotVersionToWrite)
                != snapshotVersionToWrite)
            {
                goto RetryRead;
            }

            var nextUtcTime = DateTime.UtcNow;
            var nextOffsetTime = TimeZoneInfo.Local.GetUtcOffset(nextUtcTime);

            var nextLocalTicks = nextUtcTime.Ticks + nextOffsetTime.Ticks;
            var nextStopwatchTicks = _stopwatch.ElapsedTicks;

            _snapshot.LocalTicks = nextLocalTicks;
            _snapshot.LocalOffset = nextOffsetTime;
            _snapshot.StopwatchTicks = nextStopwatchTicks;

            Volatile.Write(ref _snapshot.SnapshotVersion, snapshotVersionToWrite + 2);

            return new DateTimeOffset(nextLocalTicks, nextOffsetTime);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct DateTimeOffsetSnapshot
    {
        public int SnapshotVersion;

        public long LocalTicks;

        public TimeSpan LocalOffset;

        public long StopwatchTicks;
    }
}
