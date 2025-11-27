using Falko.Logging.Concurrents;
using Falko.Logging.Contexts;
using Falko.Logging.Renderers;

namespace Falko.Logging.Targets;

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
