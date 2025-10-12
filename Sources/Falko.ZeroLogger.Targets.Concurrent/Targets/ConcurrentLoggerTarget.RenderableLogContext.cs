using Falko.Logging.Contexts;
using Falko.Logging.Renderers;

namespace Falko.Logging.Targets;

public sealed partial class ConcurrentLoggerTarget
{
    private readonly struct RenderableLogContext
    {
        public readonly LogContext Context;

        public readonly ILogContextRenderer Renderer;

        public readonly CancellationToken CancellationToken;

        // ReSharper disable once ConvertToPrimaryConstructor
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public RenderableLogContext(in LogContext context, ILogContextRenderer renderer, CancellationToken cancellationToken)
        {
            Context = context;
            Renderer = renderer;
            CancellationToken = cancellationToken;
        }
    }
}
