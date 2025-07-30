using System.Logging.Factories;
using System.Logging.Logs;
using System.Logging.Utils;

namespace System.Logging.Renderers;

internal sealed class SingleArgumentMessageFactoryLogMessageRenderer<T>
(
    LogMessageFactory messageFactory,
    LogMessageArgument<T> argument
) : PersistentLogMessageRenderer
{
    protected override string RenderCore()
    {
        return MessageArgumentsInterpolationUtils.Interpolate(messageFactory(),
            argument.ArgumentFactory(argument.Argument));
    }
}
