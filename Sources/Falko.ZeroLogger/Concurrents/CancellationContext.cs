namespace System.Logging.Concurrents;

public readonly struct CancellationContext
{
    private readonly bool _cancellationTokenAvailable;

    private readonly bool _cancellationTimeoutAvailable;

    public readonly CancellationToken CancellationToken;

    public readonly CancellationTimeout CancellationTimeout;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public CancellationContext(CancellationToken cancellationToken, CancellationTimeout cancellationTimeout)
    {
        CancellationToken = cancellationToken;
        _cancellationTokenAvailable = cancellationToken.CanBeCanceled;

        CancellationTimeout = cancellationTimeout;
        _cancellationTimeoutAvailable = cancellationTimeout.CanBeCanceled;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public CancellationContext(CancellationToken cancellationToken)
    {
        CancellationToken = cancellationToken;
        _cancellationTokenAvailable = cancellationToken.CanBeCanceled;

        CancellationTimeout = CancellationTimeout.None;
        _cancellationTimeoutAvailable = false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public CancellationContext(CancellationTimeout cancellationTimeout)
    {
        CancellationToken = CancellationToken.None;
        _cancellationTokenAvailable = false;

        CancellationTimeout = cancellationTimeout;
        _cancellationTimeoutAvailable = cancellationTimeout.CanBeCanceled;
    }

    public static CancellationContext None => new();

    public bool IsCancellationRequested
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            if (_cancellationTokenAvailable && CancellationToken.IsCancellationRequested) return true;

            if (_cancellationTimeoutAvailable && CancellationTimeout.IsCancellationRequested) return true;

            return false;
        }
    }
}
