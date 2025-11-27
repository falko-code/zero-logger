using System.Buffers;
using System.Runtime.InteropServices;
using Falko.Logging.Factories;
using Falko.Logging.Utils;

namespace Falko.Logging.Renderers;

[method: MethodImpl(MethodImplOptions.AggressiveInlining)]
internal sealed class ManyFactoryArgumentsMessageFactoryLogMessageRenderer
(
    LogMessageFactory messageFactory,
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

        var interpolatedMessage = MessageArgumentsInterpolationUtils.Interpolate(messageFactory(),
            ref argumentsRef, argumentFactoriesLength);

        arrays.Return(arguments);

        return interpolatedMessage;
    }
}
