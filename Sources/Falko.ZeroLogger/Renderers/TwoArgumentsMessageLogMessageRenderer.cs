using System.Logging.Logs;
using System.Logging.Utils;

namespace System.Logging.Renderers;

[method: MethodImpl(MethodImplOptions.AggressiveInlining)]
internal sealed class TwoArgumentsMessageLogMessageRenderer<T1, T2>
(
    string? message,
    LogMessageArgument<T1> argument1,
    LogMessageArgument<T2> argument2
) : PersistentLogMessageRenderer
{
    protected override string RenderCore()
    {
        return MessageArgumentsInterpolationUtils.Interpolate(message,
            argument1.ToString(),
            argument2.ToString());
    }
}
