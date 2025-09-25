using System.Logging.Concurrents;
using System.Logging.Contexts;
using System.Logging.Renderers;

namespace System.Logging.Targets;

public sealed class LoggerConsoleTarget : LoggerTarget
{
    public static readonly LoggerConsoleTarget Instance = new();

    private LoggerConsoleTarget() { }

    public override void Initialize(CancellationContext cancellationContext) { }

    public override void Publish
    (
        in LogContext context,
        ILogContextRenderer renderer,
        CancellationToken cancellationToken
    )
    {
        Console.Write(renderer.Render(context));
    }

    public override void Dispose(CancellationContext cancellationContext) { }
}
