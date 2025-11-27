using Falko.Logging.Factories;
using Falko.Logging.Utils;

namespace Falko.Logging.Renderers;

[method: MethodImpl(MethodImplOptions.AggressiveInlining)]
internal sealed class TwoFactoryArgumentsMessageFactoryLogMessageRenderer
(
    LogMessageFactory messageFactory,
    LogMessageArgumentFactory argumentFactory1,
    LogMessageArgumentFactory argumentFactory2
) : PersistentLogMessageRenderer
{
    protected override string RenderCore()
    {
        return MessageArgumentsInterpolationUtils.Interpolate(messageFactory(),
            argumentFactory1(),
            argumentFactory2());
    }
}
