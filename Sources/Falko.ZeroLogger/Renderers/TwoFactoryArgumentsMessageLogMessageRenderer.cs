using System.Logging.Factories;
using System.Logging.Utils;

namespace System.Logging.Renderers;

[method: MethodImpl(MethodImplOptions.AggressiveInlining)]
internal sealed class TwoFactoryArgumentsMessageLogMessageRenderer
(
    string? message,
    LogMessageArgumentFactory argumentFactory1,
    LogMessageArgumentFactory argumentFactory2
) : PersistentLogMessageRenderer
{
    protected override string RenderCore()
    {
        return MessageArgumentsInterpolationUtils.Interpolate(message,
            argumentFactory1(),
            argumentFactory2());
    }
}
