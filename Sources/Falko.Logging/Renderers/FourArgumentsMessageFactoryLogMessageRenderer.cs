using Falko.Logging.Factories;
using Falko.Logging.Logs;
using Falko.Logging.Utils;

namespace Falko.Logging.Renderers;

[method: MethodImpl(MethodImplOptions.AggressiveInlining)]
internal sealed class FourArgumentsMessageFactoryLogMessageRenderer<T1, T2, T3, T4>
(
    LogMessageFactory messageFactory,
    LogMessageArgument<T1> argument1,
    LogMessageArgument<T2> argument2,
    LogMessageArgument<T3> argument3,
    LogMessageArgument<T4> argument4
) : PersistentLogMessageRenderer
{
    protected override string RenderCore()
    {
        return MessageArgumentsInterpolationUtils.Interpolate(messageFactory(),
            argument1.ToString(),
            argument2.ToString(),
            argument3.ToString(),
            argument4.ToString());
    }
}
