using Falko.Logging.Factories;
using Falko.Logging.Utils;

namespace Falko.Logging.Renderers;

[method: MethodImpl(MethodImplOptions.AggressiveInlining)]
internal sealed class SingleFactoryArgumentMessageLogMessageRenderer
(
    string? message,
    LogMessageArgumentFactory argumentFactory
) : PersistentLogMessageRenderer
{
    protected override string RenderCore()
    {
        return MessageArgumentsInterpolationUtils.Interpolate(message,
            argumentFactory());
    }
}
