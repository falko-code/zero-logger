using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Falko.Logging.Providers;

internal sealed class ProcessorDateTimeProvider : IDateTimeProvider
{
    private const long CachedTimeUpdateThresholdMilliseconds = 8;

    private readonly Stopwatch _stopwatch;

    private readonly long _stopwatchTicksThreshold;

    private readonly double _stopwatchTicksRatio;

    private DateTimeSnapshot _snapshot;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ProcessorDateTimeProvider()
    {
        _stopwatch = Stopwatch.StartNew();

        var stopwatchTicksThreshold = Stopwatch.Frequency * CachedTimeUpdateThresholdMilliseconds / 1000;
        _stopwatchTicksThreshold = stopwatchTicksThreshold <= 0 ? 1 : stopwatchTicksThreshold;

        _stopwatchTicksRatio = (double)TimeSpan.TicksPerSecond / Stopwatch.Frequency;

        var rootUtcTime = DateTime.Now;

        _snapshot = new DateTimeSnapshot
        {
            SnapshotVersion = 0,
            LocalTicks = rootUtcTime.Ticks,
            StopwatchTicks = _stopwatch.ElapsedTicks
        };
    }

    public DateTime Now
    {
        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.AggressiveOptimization)]
        get
        {
            scoped ref var snapshotRef = ref _snapshot;

            RetryRead:

            var snapshotVersionToRead = Volatile.Read(ref snapshotRef.SnapshotVersion);

            if ((snapshotVersionToRead & 1) != 0)
            {
                goto RetryRead;
            }

            var currentSnapshot = snapshotRef;

            var currentLocalTicks = currentSnapshot.LocalTicks;
            var currentStopwatchTicks = currentSnapshot.StopwatchTicks;

            var snapshotVersionToWrite = Volatile.Read(ref snapshotRef.SnapshotVersion);

            if (snapshotVersionToRead != snapshotVersionToWrite
                || (snapshotVersionToWrite & 1) != 0)
            {
                goto RetryRead;
            }

            var deltaStopwatchTicks = _stopwatch.ElapsedTicks - currentStopwatchTicks;

            if (deltaStopwatchTicks < _stopwatchTicksThreshold)
            {
                var addDeltaTicks = (long)(deltaStopwatchTicks * _stopwatchTicksRatio);
                return new DateTime(currentLocalTicks + addDeltaTicks);
            }

            if (Interlocked.CompareExchange(ref snapshotRef.SnapshotVersion,
                    snapshotVersionToWrite + 1,
                    snapshotVersionToWrite)
                != snapshotVersionToWrite)
            {
                goto RetryRead;
            }

            var nextTime = DateTime.Now;

            var nextLocalTicks = nextTime.Ticks;
            var nextStopwatchTicks = _stopwatch.ElapsedTicks;

            snapshotRef.LocalTicks = nextLocalTicks;
            snapshotRef.StopwatchTicks = nextStopwatchTicks;

            Volatile.Write(ref snapshotRef.SnapshotVersion, snapshotVersionToWrite + 2);

            return nextTime;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct DateTimeSnapshot
    {
        public int SnapshotVersion;

        public long LocalTicks;

        public long StopwatchTicks;
    }
}
