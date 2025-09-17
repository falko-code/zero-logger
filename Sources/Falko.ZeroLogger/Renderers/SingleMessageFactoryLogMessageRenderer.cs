using System.Logging.Factories;

namespace System.Logging.Renderers;

[method: MethodImpl(MethodImplOptions.AggressiveInlining)]
internal sealed class SingleMessageFactoryLogMessageRenderer(LogMessageFactory messageFactory) : PersistentLogMessageRenderer
{
    protected override string RenderCore()
    {
        return messageFactory() ?? string.Empty;
    }
}
