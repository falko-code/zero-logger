using System.Logging.Concurrents;
using System.Logging.Contexts;
using System.Logging.Renderers;

namespace System.Logging.Targets;

public abstract class LoggerTarget : IDisposable
{
    public virtual bool RequiresSynchronization => true;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Initialize() => Initialize(CancellationContext.None);

    public abstract void Initialize(CancellationContext cancellationContext);

    public abstract void Publish
    (
        in LogContext context,
        ILogContextRenderer renderer,
        CancellationToken cancellationToken
    );

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Dispose() => Dispose(CancellationContext.None);

    public abstract void Dispose(CancellationContext cancellationContext);
}
