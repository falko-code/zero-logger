using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace System.Logging.Utils;

internal sealed class ProcessorDateTimeOffsetProvider : IDateTimeOffsetProvider
{
    private const long CachedTimeUpdateIntervalTicks = 10 * 1000 * 1000; // 10ms

    private readonly Stopwatch _stopwatch = Stopwatch.StartNew();

    private readonly float _stopwatchTickToDateTimeTicks = TimeSpan.TicksPerSecond / (float)Stopwatch.Frequency;

    private DateTimeOffset _cachedTime = DateTimeOffset.Now;

    private long _lastTicksTime;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ProcessorDateTimeOffsetProvider() => _lastTicksTime = _stopwatch.ElapsedTicks;

    public DateTimeOffset Now
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            var currentTicks = _stopwatch.ElapsedTicks;

            var currentTicksDelta = currentTicks - _lastTicksTime;

            if (currentTicksDelta < CachedTimeUpdateIntervalTicks)
            {
                return _cachedTime.AddTicks((long)(currentTicksDelta * _stopwatchTickToDateTimeTicks));
            }

            _cachedTime = DateTimeOffset.Now;
            _lastTicksTime = currentTicks;

            return _cachedTime;
        }
    }
}
