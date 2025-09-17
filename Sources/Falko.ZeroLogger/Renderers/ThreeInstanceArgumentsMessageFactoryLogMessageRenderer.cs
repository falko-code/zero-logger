using System.Logging.Factories;
using System.Logging.Utils;

namespace System.Logging.Renderers;

[method: MethodImpl(MethodImplOptions.AggressiveInlining)]
internal sealed class ThreeInstanceArgumentsMessageFactoryLogMessageRenderer<T1, T2, T3>
(
    LogMessageFactory messageFactory,
    T1 argument1,
    T2 argument2,
    T3 argument3
) : PersistentLogMessageRenderer
{
    protected override string RenderCore()
    {
        return MessageArgumentsInterpolationUtils.Interpolate(messageFactory(),
            StringUtils.ToString(argument1),
            StringUtils.ToString(argument2),
            StringUtils.ToString(argument3));
    }
}
