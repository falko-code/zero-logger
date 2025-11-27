using Falko.Logging.Utils;

namespace Falko.Logging.Renderers;

[method: MethodImpl(MethodImplOptions.AggressiveInlining)]
internal sealed class ThreeStringArgumentsMessageLogMessageRenderer
(
    string? message,
    string? argument1,
    string? argument2,
    string? argument3
) : PersistentLogMessageRenderer
{
    protected override string RenderCore()
    {
        return MessageArgumentsInterpolationUtils.Interpolate(message,
            argument1,
            argument2,
            argument3);
    }
}
