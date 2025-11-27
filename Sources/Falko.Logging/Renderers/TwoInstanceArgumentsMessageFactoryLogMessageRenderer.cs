using Falko.Logging.Factories;
using Falko.Logging.Utils;

namespace Falko.Logging.Renderers;

[method: MethodImpl(MethodImplOptions.AggressiveInlining)]
internal sealed class TwoInstanceArgumentsMessageFactoryLogMessageRenderer<T1, T2>
(
    LogMessageFactory messageFactory,
    T1 argument1,
    T2 argument2
) : PersistentLogMessageRenderer
{
    protected override string RenderCore()
    {
        return MessageArgumentsInterpolationUtils.Interpolate(messageFactory(),
            StringUtils.ToString(argument1),
            StringUtils.ToString(argument2));
    }
}
