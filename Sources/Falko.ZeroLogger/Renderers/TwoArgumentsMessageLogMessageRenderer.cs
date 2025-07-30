using System.Logging.Logs;
using System.Logging.Utils;

namespace System.Logging.Renderers;

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
            argument1.ArgumentFactory(argument1.Argument),
            argument2.ArgumentFactory(argument2.Argument));
    }
}
