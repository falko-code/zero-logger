using System.Buffers;
using System.Logging.Factories;
using System.Logging.Utils;
using System.Runtime.InteropServices;

namespace System.Logging.Renderers;

internal sealed class ManyInstanceArgumentsMessageFactoryLogMessageRenderer
(
    LogMessageFactory messageFactory,
    object?[] argumentObjects
) : PersistentLogMessageRenderer
{
    protected override string RenderCore()
    {
        var argumentObjectsLength = argumentObjects.Length;

        var arrays = ArrayPool<string?>.Shared;
        var arguments = arrays.Rent(argumentObjectsLength);

        scoped ref var argumentsRef = ref MemoryMarshal.GetArrayDataReference(arguments);
        scoped ref var argumentFactoriesRef = ref MemoryMarshal.GetArrayDataReference(argumentObjects);

        for (var argumentObjectIndex = 0; argumentObjectIndex < argumentObjectsLength; argumentObjectIndex++)
        {
            var argumentObject = Unsafe.Add(ref argumentFactoriesRef, argumentObjectIndex);

            Unsafe.Add(ref argumentsRef, argumentObjectIndex) = StringUtils.ToString(argumentObject);
        }

        var interpolatedMessage = MessageArgumentsInterpolationUtils.Interpolate(messageFactory(),
            ref argumentsRef, argumentObjectsLength);

        arrays.Return(arguments);

        return interpolatedMessage;
    }
}
