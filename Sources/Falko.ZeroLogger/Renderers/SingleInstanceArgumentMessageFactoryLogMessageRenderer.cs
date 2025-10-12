using Falko.Logging.Factories;
using Falko.Logging.Utils;

namespace Falko.Logging.Renderers;

[method: MethodImpl(MethodImplOptions.AggressiveInlining)]
internal sealed class SingleInstanceArgumentMessageFactoryLogMessageRenderer<T>
(
    LogMessageFactory messageFactory,
    T argument
) : PersistentLogMessageRenderer
{
    protected override string RenderCore()
    {
        return MessageArgumentsInterpolationUtils.Interpolate(messageFactory(),
            StringUtils.ToString(argument));
    }
}
