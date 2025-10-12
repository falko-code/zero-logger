using System.Buffers;
using System.Runtime.InteropServices;
using Falko.Logging.Builders;

namespace Falko.Logging.Utils;

internal static class MessageArgumentsInterpolationUtils
{
    private const string NullString = "null";

    private const char ArgumentOpenBrace = '{';
    private const char ArgumentCloseBrace = '}';

    private const int DefaultMessageArgumentLength = 8;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string Interpolate(string? message,
        string? argument)
    {
        if (message is null) return string.Empty;

        var argumentStartIndex = message.IndexOf(ArgumentOpenBrace);
        if (argumentStartIndex is -1) return message;

        var argumentEndIndex = message.IndexOf(ArgumentCloseBrace, argumentStartIndex + 1);
        if (argumentEndIndex is -1) return message;

        scoped ReadOnlySpan<char> argumentSpan = argument ?? NullString;

        const int argumentSymbolsCount = 2;

        var messageLength = message.Length + argumentSpan.Length - argumentSymbolsCount;

        using scoped var messageBuilder = messageLength > ValueStringBuilder.MaximumSafeStackBufferSize
            ? new ValueStringBuilder(messageLength)
            : new ValueStringBuilder(stackalloc char[messageLength]);

        scoped var messageSpan = message.AsSpan();

        messageBuilder.Append(messageSpan[..argumentStartIndex]);
        messageBuilder.Append(argumentSpan);
        messageBuilder.Append(messageSpan[(argumentEndIndex + 1)..]);

        return messageBuilder.ToString();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Interpolate(string? message,
        string? argument1,
        string? argument2)
    {
        if (message is null) return string.Empty;

        const int argumentsCount = 2;

        var arrays = ArrayPool<string?>.Shared;

        var arguments = arrays.Rent(argumentsCount);

        scoped ref var argumentsRef = ref MemoryMarshal.GetArrayDataReference(arguments);

        try
        {
            Unsafe.Add(ref argumentsRef, 0) = argument1;
            Unsafe.Add(ref argumentsRef, 1) = argument2;

            message = InterpolateCore(message, ref argumentsRef, argumentsCount);
        }
        finally
        {
            Unsafe.Add(ref argumentsRef, 0) = null;
            Unsafe.Add(ref argumentsRef, 1) = null;

            arrays.Return(arguments);
        }

        return message;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Interpolate(string? message,
        string? argument1,
        string? argument2,
        string? argument3)
    {
        if (message is null) return string.Empty;

        const int argumentsCount = 3;

        var arrays = ArrayPool<string?>.Shared;

        var arguments = arrays.Rent(argumentsCount);

        scoped ref var argumentsRef = ref MemoryMarshal.GetArrayDataReference(arguments);

        try
        {
            Unsafe.Add(ref argumentsRef, 0) = argument1;
            Unsafe.Add(ref argumentsRef, 1) = argument2;
            Unsafe.Add(ref argumentsRef, 2) = argument3;

            message = InterpolateCore(message, ref argumentsRef, argumentsCount);
        }
        finally
        {
            Unsafe.Add(ref argumentsRef, 0) = null;
            Unsafe.Add(ref argumentsRef, 1) = null;
            Unsafe.Add(ref argumentsRef, 2) = null;

            arrays.Return(arguments);
        }

        return message;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Interpolate(string? message,
        string? argument1,
        string? argument2,
        string? argument3,
        string? argument4)
    {
        if (message is null) return string.Empty;

        const int argumentsCount = 4;

        var arrays = ArrayPool<string?>.Shared;

        var arguments = arrays.Rent(argumentsCount);

        scoped ref var argumentsRef = ref MemoryMarshal.GetArrayDataReference(arguments);

        try
        {
            Unsafe.Add(ref argumentsRef, 0) = argument1;
            Unsafe.Add(ref argumentsRef, 1) = argument2;
            Unsafe.Add(ref argumentsRef, 2) = argument3;
            Unsafe.Add(ref argumentsRef, 3) = argument4;

            message = InterpolateCore(message, ref argumentsRef, argumentsCount);
        }
        finally
        {
            Unsafe.Add(ref argumentsRef, 0) = null;
            Unsafe.Add(ref argumentsRef, 1) = null;
            Unsafe.Add(ref argumentsRef, 2) = null;
            Unsafe.Add(ref argumentsRef, 3) = null;

            arrays.Return(arguments);
        }

        return message;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Interpolate(string? message, scoped ref string? arguments, int count)
    {
        if (message is null) return string.Empty;

        return InterpolateCore(message, ref arguments, count);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string InterpolateCore(string message, scoped ref string? argumentsRef, int argumentsCount)
    {
        var messageLength = message.Length * argumentsCount * DefaultMessageArgumentLength;

        using scoped var messageBuilder = messageLength > ValueStringBuilder.MaximumSafeStackBufferSize
            ? new ValueStringBuilder(messageLength)
            : new ValueStringBuilder(stackalloc char[ValueStringBuilder.MaximumSafeStackBufferSize]);

        scoped var messageSpan = message.AsSpan();

        var messageIndex = 0;
        var argumentIndex = -1;

        for (;;)
        {
            var argumentOpenIndex = message.IndexOf(ArgumentOpenBrace, messageIndex);

            if (argumentOpenIndex is -1)
            {
                messageBuilder.Append(messageSpan[messageIndex..]);
                break;
            }

            messageBuilder.Append(messageSpan[messageIndex..argumentOpenIndex]);

            var argumentCloseIndex = message.IndexOf(ArgumentCloseBrace, argumentOpenIndex + 1);

            if (argumentCloseIndex is -1)
            {
                messageBuilder.Append(messageSpan[argumentOpenIndex..]);
                break;
            }

            ++argumentIndex;

            if (argumentIndex >= argumentsCount)
            {
                messageBuilder.Append(messageSpan[argumentOpenIndex..]);
                break;
            }

            var argument = Unsafe.Add(ref argumentsRef, argumentIndex) ?? NullString;

            messageBuilder.Ensure(argument.Length);
            messageBuilder.Append(argument);

            messageIndex = argumentCloseIndex + 1;
        }

        return messageBuilder.ToString();
    }
}
