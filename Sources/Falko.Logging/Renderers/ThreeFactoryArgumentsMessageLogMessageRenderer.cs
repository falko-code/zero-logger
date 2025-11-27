using Falko.Logging.Factories;
using Falko.Logging.Utils;

namespace Falko.Logging.Renderers;

[method: MethodImpl(MethodImplOptions.AggressiveInlining)]
internal sealed class ThreeFactoryArgumentsMessageLogMessageRenderer
(
    string? message,
    LogMessageArgumentFactory argumentFactory1,
    LogMessageArgumentFactory argumentFactory2,
    LogMessageArgumentFactory argumentFactory3
) : PersistentLogMessageRenderer
{
    protected override string RenderCore()
    {
        return MessageArgumentsInterpolationUtils.Interpolate(message,
            argumentFactory1(),
            argumentFactory2(),
            argumentFactory3());
    }
}
