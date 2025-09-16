using System.Logging.Contexts;
using System.Logging.Renderers;
using System.Runtime.CompilerServices;

namespace System.Logging.Targets;

public sealed partial class ConcurrentLoggerTarget
{
    private readonly struct RenderableLogContext
    {
        public readonly LogContext Context;

        public readonly ILogContextRenderer Renderer;

        // ReSharper disable once ConvertToPrimaryConstructor
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public RenderableLogContext(in LogContext context, ILogContextRenderer renderer)
        {
            Context = context;
            Renderer = renderer;
        }
    }
}
