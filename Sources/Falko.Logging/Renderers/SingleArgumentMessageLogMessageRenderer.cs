using Falko.Logging.Logs;
using Falko.Logging.Utils;

namespace Falko.Logging.Renderers;

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
