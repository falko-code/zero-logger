using System.Logging.Logs;
using System.Logging.Utils;

namespace System.Logging.Renderers;

[method: MethodImpl(MethodImplOptions.AggressiveInlining)]
internal sealed class SingleArgumentMessageLogMessageRenderer<T>
(
    string? message,
    LogMessageArgument<T> argument
) : PersistentLogMessageRenderer
{
    protected override string RenderCore()
    {
        return MessageArgumentsInterpolationUtils.Interpolate(message,
            argument.ToString());
    }
}
