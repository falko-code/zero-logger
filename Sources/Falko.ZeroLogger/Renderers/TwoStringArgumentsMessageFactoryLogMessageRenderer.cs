using Falko.Logging.Factories;
using Falko.Logging.Utils;

namespace Falko.Logging.Renderers;

[method: MethodImpl(MethodImplOptions.AggressiveInlining)]
internal sealed class TwoStringArgumentsMessageFactoryLogMessageRenderer
(
    LogMessageFactory messageFactory,
    string? argument1,
    string? argument2
) : PersistentLogMessageRenderer
{
    protected override string RenderCore()
    {
        return MessageArgumentsInterpolationUtils.Interpolate(messageFactory(),
            argument1,
            argument2);
    }
}
