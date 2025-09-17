using System.Logging.Contexts;
using System.Logging.Renderers;

namespace System.Logging.Targets;

public sealed class LockLoggerTarget(LoggerTarget singleThreadLoggerTarget) : LoggerTarget
{
#if NET9_0_OR_GREATER
    private readonly Lock _locker = new();
#else
    private readonly object _locker = new();
#endif

    public override bool RequiresSynchronization => false;

    public override void Initialize(CancellationToken cancellationToken)
    {
        lock (_locker)
        {
            singleThreadLoggerTarget.Initialize(cancellationToken);
        }
    }

    public override void Publish(in LogContext context, ILogContextRenderer renderer, CancellationToken cancellationToken)
    {
        lock (_locker)
        {
            singleThreadLoggerTarget.Publish(context, renderer, cancellationToken);
        }
    }

    public override void Dispose(CancellationToken cancellationToken)
    {
        lock (_locker)
        {
            singleThreadLoggerTarget.Dispose(cancellationToken);
        }
    }
}
