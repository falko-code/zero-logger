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
        scoped ref readonly LogContext context,
        ILogContextRenderer renderer,
        CancellationToken cancellationToken
    )
    {
        Console.Write(renderer.Render(in context));
    }

    public override void Dispose(CancellationContext cancellationContext) { }
}
