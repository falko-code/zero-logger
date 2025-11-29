using Falko.Logging.Concurrents;
using Falko.Logging.Contexts;
using Falko.Logging.Renderers;
using Falko.Logging.Targets;

namespace Falko.Examples.Targets;

public sealed class WithRenderingZeroLoggerTarget : LoggerTarget
{
    public static readonly WithRenderingZeroLoggerTarget Instance = new();

    private WithRenderingZeroLoggerTarget() { }

    public override void Initialize(CancellationContext cancellationContext) { }

    public override void Publish
    (
        scoped ref readonly LogContext context,
        ILogContextRenderer renderer,
        CancellationToken cancellationToken
    )
    {
        _ = renderer.Render(in context);
    }

    public override void Dispose(CancellationContext cancellationContext) { }
}
