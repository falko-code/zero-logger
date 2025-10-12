using Falko.Logging.Factories;
using Falko.Logging.Logs;
using Falko.Logging.Utils;

namespace Falko.Logging.Renderers;

[method: MethodImpl(MethodImplOptions.AggressiveInlining)]
internal sealed class SingleArgumentMessageFactoryLogMessageRenderer<T>
(
    LogMessageFactory messageFactory,
    LogMessageArgument<T> argument
) : PersistentLogMessageRenderer
{
    protected override string RenderCore()
    {
        return MessageArgumentsInterpolationUtils.Interpolate(messageFactory(),
            argument.ToString());
    }
}
