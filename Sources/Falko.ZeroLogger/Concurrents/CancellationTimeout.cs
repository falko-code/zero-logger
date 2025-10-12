using System.Diagnostics;

namespace Falko.Logging.Concurrents;

public readonly struct CancellationTimeout
{
    private static readonly Stopwatch GlobalStopwatch = Stopwatch.StartNew();

    private static readonly long TicksPerMillisecond = Stopwatch.Frequency / 1000;

    private static int MaximumMilliseconds => ToMilliseconds(TimeSpan.MaxValue);

    private readonly Stopwatch _globalStopwatch;

    private readonly long _endTicks;

    private readonly int _durationMilliseconds;

    // ReSharper disable ConvertToPrimaryConstructor
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public CancellationTimeout(int millisecondsTimeout)
    {
        _globalStopwatch = GlobalStopwatch;
        _endTicks = GlobalStopwatch.ElapsedTicks + millisecondsTimeout * TicksPerMillisecond;

        _durationMilliseconds = millisecondsTimeout;
    }

    public static CancellationTimeout None => new(MaximumMilliseconds);

    public bool CanBeCanceled
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => _durationMilliseconds < MaximumMilliseconds;
    }

    public bool IsCancellationRequested
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => _globalStopwatch.ElapsedTicks >= _endTicks;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static CancellationTimeout From(TimeSpan timeout)
    {
        var millisecondsTimeout = ToMilliseconds(timeout);

        ThrowIfInvalid(millisecondsTimeout);

        return new CancellationTimeout(millisecondsTimeout);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ThrowIfInvalid(int millisecondsTimeout)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(millisecondsTimeout);
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(millisecondsTimeout, MaximumMilliseconds);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int ToMilliseconds(TimeSpan timeout)
    {
        return (int)Math.Floor(timeout.TotalMilliseconds);
    }
}
