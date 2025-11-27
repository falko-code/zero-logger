using Falko.Logging.Concurrents;
using Falko.Logging.Contexts;
using Falko.Logging.Renderers;

namespace Falko.Logging.Targets;

[method: MethodImpl(MethodImplOptions.AggressiveInlining)]
public sealed class LockingLoggerTarget(LoggerTarget singleThreadLoggerTarget) : LoggerTarget
{
#if NET9_0_OR_GREATER
    private readonly Lock _locker = new();
#else
    private readonly object _locker = new();
#endif

    public override bool RequiresSynchronization => false;

    public override void Initialize(CancellationContext cancellationContext)
    {
#if NET9_0_OR_GREATER
        using (_locker.EnterScope()) singleThreadLoggerTarget.Initialize(cancellationContext);
#else
        lock (_locker) singleThreadLoggerTarget.Initialize(cancellationContext);
#endif
    }

    public override void Publish
    (
        in LogContext context,
        ILogContextRenderer renderer,
        CancellationToken cancellationToken
    )
    {
#if NET9_0_OR_GREATER
        using (_locker.EnterScope()) singleThreadLoggerTarget.Publish(context, renderer, cancellationToken);
#else
        lock (_locker) singleThreadLoggerTarget.Publish(context, renderer, cancellationToken);
#endif
    }

    public override void Dispose(CancellationContext cancellationContext)
    {
#if NET9_0_OR_GREATER
        using (_locker.EnterScope()) singleThreadLoggerTarget.Dispose(cancellationContext);
#else
        lock (_locker) singleThreadLoggerTarget.Dispose(cancellationContext);
#endif
    }
}
