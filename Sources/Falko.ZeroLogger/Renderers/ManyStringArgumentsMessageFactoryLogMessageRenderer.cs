using System.Runtime.InteropServices;
using Falko.Logging.Factories;
using Falko.Logging.Utils;

namespace Falko.Logging.Renderers;

[method: MethodImpl(MethodImplOptions.AggressiveInlining)]
internal sealed class ManyStringArgumentsMessageFactoryLogMessageRenderer
(
    LogMessageFactory messageFactory,
    string?[] arguments
) : PersistentLogMessageRenderer
{
    protected override string RenderCore()
    {
        return MessageArgumentsInterpolationUtils.Interpolate(messageFactory(),
            ref MemoryMarshal.GetArrayDataReference(arguments), arguments.Length);
    }
}
