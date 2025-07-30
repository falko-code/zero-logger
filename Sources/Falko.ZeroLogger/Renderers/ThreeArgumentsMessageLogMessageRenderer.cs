using System.Logging.Logs;
using System.Logging.Utils;

namespace System.Logging.Renderers;

internal sealed class ThreeArgumentsMessageLogMessageRenderer<T1, T2, T3>
(
    string? message,
    LogMessageArgument<T1> argument1,
    LogMessageArgument<T2> argument2,
    LogMessageArgument<T3> argument3
) : PersistentLogMessageRenderer
{
    protected override string RenderCore()
    {
        return MessageArgumentsInterpolationUtils.Interpolate(message,
            argument1.ArgumentFactory(argument1.Argument),
            argument2.ArgumentFactory(argument2.Argument),
            argument3.ArgumentFactory(argument3.Argument));
    }
}
