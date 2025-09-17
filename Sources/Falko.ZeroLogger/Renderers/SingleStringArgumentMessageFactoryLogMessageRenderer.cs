using System.Logging.Factories;
using System.Logging.Utils;

namespace System.Logging.Renderers;

[method: MethodImpl(MethodImplOptions.AggressiveInlining)]
internal sealed class SingleStringArgumentMessageFactoryLogMessageRenderer
(
    LogMessageFactory messageFactory,
    string? argument
) : PersistentLogMessageRenderer
{
    protected override string RenderCore()
    {
        return MessageArgumentsInterpolationUtils.Interpolate(messageFactory(),
            argument);
    }
}
