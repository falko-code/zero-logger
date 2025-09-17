using System.Logging.Contexts;
using System.Logging.Renderers;

namespace System.Logging.Targets;

[method: MethodImpl(MethodImplOptions.AggressiveInlining)]
public sealed class LockingLoggerTarget(LoggerTarget singleThreadLoggerTarget) : LoggerTarget
{
#if NET9_0_OR_GREATER
    private readonly Lock _locker = new();
#else
    private readonly object _locker = new();
#endif

    public override bool RequiresSynchronization => false;

    public override void Initialize(CancellationToken cancellationToken)
    {
#if NET9_0_OR_GREATER
        using var _ = _locker.EnterScope();
        singleThreadLoggerTarget.Initialize(cancellationToken);
#else
        lock (_locker) singleThreadLoggerTarget.Initialize(cancellationToken);
#endif
    }

    public override void Publish(in LogContext context, ILogContextRenderer renderer, CancellationToken cancellationToken)
    {
#if NET9_0_OR_GREATER
        using var _ = _locker.EnterScope();
        singleThreadLoggerTarget.Publish(context, renderer, cancellationToken);
#else
        lock (_locker) singleThreadLoggerTarget.Publish(context, renderer, cancellationToken);
#endif
    }

    public override void Dispose(CancellationToken cancellationToken)
    {
#if NET9_0_OR_GREATER
        using var _ = _locker.EnterScope();
        singleThreadLoggerTarget.Dispose(cancellationToken);
#else
        lock (_locker) singleThreadLoggerTarget.Dispose(cancellationToken);
#endif
    }
}
