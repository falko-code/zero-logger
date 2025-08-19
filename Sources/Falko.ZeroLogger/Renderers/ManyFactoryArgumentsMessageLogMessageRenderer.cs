using System.Buffers;
using System.Logging.Factories;
using System.Logging.Utils;
using System.Runtime.InteropServices;

namespace System.Logging.Renderers;

internal sealed class ManyFactoryArgumentsMessageLogMessageRenderer
(
    string? message,
    LogMessageArgumentFactory[] argumentFactories
) : PersistentLogMessageRenderer
{
    protected override string RenderCore()
    {
        var argumentFactoriesLength = argumentFactories.Length;

        var arrays = ArrayPool<string?>.Shared;
        var arguments = arrays.Rent(argumentFactoriesLength);

        scoped ref var argumentsRef = ref MemoryMarshal.GetArrayDataReference(arguments);
        scoped ref var argumentFactoriesRef = ref MemoryMarshal.GetArrayDataReference(argumentFactories);

        for (var argumentFactoryIndex = 0; argumentFactoryIndex < argumentFactoriesLength; argumentFactoryIndex++)
        {
            var argumentFactory = Unsafe.Add(ref argumentFactoriesRef, argumentFactoryIndex)();

            Unsafe.Add(ref argumentsRef, argumentFactoryIndex) = argumentFactory;
        }

        var interpolatedMessage = MessageArgumentsInterpolationUtils.Interpolate(message,
            ref argumentsRef, argumentFactoriesLength);

        arrays.Return(arguments);

        return interpolatedMessage;
    }
}
