using Falko.Logging.Renderers;

namespace Falko.Logging.Contexts;

internal readonly struct LogContextRendererSpan(ILogContextRenderer renderer, int count)
{
    public readonly ILogContextRenderer Renderer = renderer;

    public readonly int Count = count;
}
