using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace System.Logging.Common;

internal readonly struct CancellationTimeout
{
    private static readonly Stopwatch GlobalStopwatch = Stopwatch.StartNew();

    private static readonly long TicksPerMillisecond = Stopwatch.Frequency / 1000;

    private static int MaximumMilliseconds => (int)Math.Floor(TimeSpan.MaxValue.TotalMilliseconds);

    private readonly Stopwatch _globalStopwatch;

    private readonly long _endTicks;

    public readonly int DurationMilliseconds;

    // ReSharper disable once ConvertToPrimaryConstructor
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public CancellationTimeout(int millisecondsTimeout)
    {
        _globalStopwatch = GlobalStopwatch;
        _endTicks = GlobalStopwatch.ElapsedTicks + millisecondsTimeout * TicksPerMillisecond;

        DurationMilliseconds = millisecondsTimeout;
    }

    public bool IsExpired
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => _globalStopwatch.ElapsedTicks >= _endTicks;
    }

    public int RemainingMilliseconds
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            var elapsedTicks = _globalStopwatch.ElapsedTicks;
            var endTicks = _endTicks;

            if (elapsedTicks >= endTicks) return 0;

            var remainingTicks = endTicks - elapsedTicks;

            return (int)(remainingTicks / TicksPerMillisecond);
        }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ThrowIfInvalid(int millisecondsTimeout)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(millisecondsTimeout);
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(millisecondsTimeout, MaximumMilliseconds);
    }
}
