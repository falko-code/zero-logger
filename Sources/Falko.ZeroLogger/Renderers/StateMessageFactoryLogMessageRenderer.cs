using System.Logging.Factories;

namespace System.Logging.Renderers;

[method: MethodImpl(MethodImplOptions.AggressiveInlining)]
internal sealed class StateMessageFactoryLogMessageRenderer<T>
(
    LogMessageFactory<T> messageFactory,
    T messageState
) : PersistentLogMessageRenderer
{
    protected override string RenderCore()
    {
        return messageFactory(messageState) ?? string.Empty;
    }
}
