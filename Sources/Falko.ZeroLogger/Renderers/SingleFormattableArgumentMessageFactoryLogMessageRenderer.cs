using System.Logging.Factories;
using System.Logging.Utils;

namespace System.Logging.Renderers;

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
