using Falko.Logging.Utils;

namespace Falko.Logging.Renderers;

[method: MethodImpl(MethodImplOptions.AggressiveInlining)]
internal sealed class FourInstanceArgumentsMessageLogMessageRenderer<T1, T2, T3, T4>
(
    string? message,
    T1 argument1,
    T2 argument2,
    T3 argument3,
    T4 argument4
) : PersistentLogMessageRenderer
{
    protected override string RenderCore()
    {
        return MessageArgumentsInterpolationUtils.Interpolate(message,
            StringUtils.ToString(argument1),
            StringUtils.ToString(argument2),
            StringUtils.ToString(argument3),
            StringUtils.ToString(argument4));
    }
}
