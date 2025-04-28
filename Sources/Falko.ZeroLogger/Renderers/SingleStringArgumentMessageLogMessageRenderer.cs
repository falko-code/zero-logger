using System.Logging.Utils;

namespace System.Logging.Renderers;

internal sealed class SingleStringArgumentMessageLogMessageRenderer
(
    string? message,
    string? argument
) : PersistentLogMessageRenderer
{
    protected override string RenderCore()
    {
        return MessageArgumentsInterpolationUtils.Interpolate(message,
            argument);
    }
}
