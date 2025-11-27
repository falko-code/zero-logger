using Falko.Logging.Utils;

namespace Falko.Logging.Renderers;

[method: MethodImpl(MethodImplOptions.AggressiveInlining)]
internal sealed class SingleFormattableArgumentMessageLogMessageRenderer<T>
(
    string? message,
    T argument
) : PersistentLogMessageRenderer where T : IFormattable
{
    protected override string RenderCore()
    {
        return MessageArgumentsInterpolationUtils.Interpolate(message,
            argument.ToString(null, null));
    }
}
