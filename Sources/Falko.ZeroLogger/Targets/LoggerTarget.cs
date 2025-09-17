using System.Logging.Contexts;
using System.Logging.Renderers;

namespace System.Logging.Targets;

public abstract class LoggerTarget : IDisposable
{
    public virtual bool RequiresSynchronization => true;

    public void Initialize() => Initialize(CancellationToken.None);

    public abstract void Initialize(CancellationToken cancellationToken);

    public abstract void Publish(in LogContext context, ILogContextRenderer renderer, CancellationToken cancellationToken);

    public abstract void Dispose(CancellationToken cancellationToken);

    public void Dispose() => Dispose(CancellationToken.None);
}
