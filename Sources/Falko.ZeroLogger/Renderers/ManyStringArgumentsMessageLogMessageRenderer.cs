using System.Logging.Utils;
using System.Runtime.InteropServices;

namespace System.Logging.Renderers;

[method: MethodImpl(MethodImplOptions.AggressiveInlining)]
internal sealed class ManyStringArgumentsMessageLogMessageRenderer
(
    string? message,
    string?[] arguments
) : PersistentLogMessageRenderer
{
    protected override string RenderCore()
    {
        return MessageArgumentsInterpolationUtils.Interpolate(message,
            ref MemoryMarshal.GetArrayDataReference(arguments), arguments.Length);
    }
}
