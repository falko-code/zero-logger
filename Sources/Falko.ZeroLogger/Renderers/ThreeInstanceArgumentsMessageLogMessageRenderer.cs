using System.Logging.Utils;

namespace System.Logging.Renderers;

[method: MethodImpl(MethodImplOptions.AggressiveInlining)]
internal sealed class ThreeInstanceArgumentsMessageLogMessageRenderer<T1, T2, T3>
(
    string? message,
    T1 argument1,
    T2 argument2,
    T3 argument3
) : PersistentLogMessageRenderer
{
    protected override string RenderCore()
    {
        return MessageArgumentsInterpolationUtils.Interpolate(message,
            StringUtils.ToString(argument1),
            StringUtils.ToString(argument2),
            StringUtils.ToString(argument3));
    }
}
