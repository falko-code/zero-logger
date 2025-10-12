using Falko.Logging.Factories;
using Falko.Logging.Utils;

namespace Falko.Logging.Renderers;

[method: MethodImpl(MethodImplOptions.AggressiveInlining)]
internal sealed class SingleFormattableArgumentMessageFactoryLogMessageRenderer<T>
(
    LogMessageFactory messageFactory,
    T argument
) : PersistentLogMessageRenderer where T : IFormattable
{
    protected override string RenderCore()
    {
        return MessageArgumentsInterpolationUtils.Interpolate(messageFactory(),
            argument.ToString(null, null));
    }
}
