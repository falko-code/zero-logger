using Falko.Logging.Builders;
using Falko.Logging.Collections;

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
        if (string.IsNullOrEmpty(message)) return string.Empty;

        var argumentStartIndex = message.IndexOf(ArgumentOpenBrace);

        if (argumentStartIndex is -1) return message;

        var argumentStartAfterIndex = argumentStartIndex + 1;

        var argumentEndIndex = message.IndexOf(ArgumentCloseBrace, argumentStartAfterIndex);

        if (argumentEndIndex is -1)
        {
            var bracerContext = new BracerInterpolationContext
            (
                message: message,
                bracerStartIndex: argumentStartIndex
            );

            return string.Create(message.Length - 1, bracerContext, static (span, context) =>
            {
                var message = context.Message;
                var bracerIndex = context.BracerStartIndex;

                message[..bracerIndex].CopyTo(span);
                message[(bracerIndex + 1)..].CopyTo(span[bracerIndex..]);
            });
        }

        var argumentEndAfterIndex = argumentEndIndex + 1;

        argument ??= NullString;

        var messageLength = message.Length + argument.Length - (argumentEndAfterIndex - argumentStartIndex);

        var argumentContext = new ArgumentInterpolationContext
        (
            message: message,
            argument: argument,
            argumentStartIndex: argumentStartIndex,
            argumentEndAfterIndex: argumentEndAfterIndex
        );

        return string.Create(messageLength, argumentContext, static (span, context) =>
        {
            scoped ReadOnlySpan<char> messageSpan = context.Message;

            var left = messageSpan[..context.ArgumentStartIndex];
            var leftLength = left.Length;

            left.CopyTo(span);

            var argument = context.Argument;
            var argumentLength = argument.Length;

            argument.CopyTo(span[leftLength..]);

            var right = messageSpan[context.ArgumentEndAfterIndex..];

            right.CopyTo(span[(leftLength + argumentLength)..]);
        });
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Interpolate(string? message,
        string? argument1,
        string? argument2)
    {
        if (string.IsNullOrEmpty(message)) return string.Empty;

        const int argumentsCount = 2;

        Inline2StringsArray arguments = default;

        scoped ref var argumentsRef = ref InlineArrayMarshal
            .GetArrayDataReference<Inline2StringsArray, string?>(ref arguments);

        Unsafe.Add(ref argumentsRef, 0) = argument1;
        Unsafe.Add(ref argumentsRef, 1) = argument2;

        message = InterpolateCore(message, ref argumentsRef, argumentsCount);

        return message;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Interpolate(string? message,
        string? argument1,
        string? argument2,
        string? argument3)
    {
        if (string.IsNullOrEmpty(message)) return string.Empty;

        const int argumentsCount = 3;

        Inline3StringsArray arguments = default;

        scoped ref var argumentsRef = ref InlineArrayMarshal
            .GetArrayDataReference<Inline3StringsArray, string?>(ref arguments);

        Unsafe.Add(ref argumentsRef, 0) = argument1;
        Unsafe.Add(ref argumentsRef, 1) = argument2;
        Unsafe.Add(ref argumentsRef, 2) = argument3;

        message = InterpolateCore(message, ref argumentsRef, argumentsCount);

        return message;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Interpolate(string? message,
        string? argument1,
        string? argument2,
        string? argument3,
        string? argument4)
    {
        if (string.IsNullOrEmpty(message)) return string.Empty;

        const int argumentsCount = 4;

        Inline4StringsArray arguments = default;

        scoped ref var argumentsRef = ref InlineArrayMarshal
            .GetArrayDataReference<Inline4StringsArray, string?>(ref arguments);

        Unsafe.Add(ref argumentsRef, 0) = argument1;
        Unsafe.Add(ref argumentsRef, 1) = argument2;
        Unsafe.Add(ref argumentsRef, 2) = argument3;
        Unsafe.Add(ref argumentsRef, 3) = argument4;

        message = InterpolateCore(message, ref argumentsRef, argumentsCount);

        return message;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Interpolate(string? message, scoped ref string? arguments, int count)
    {
        if (string.IsNullOrEmpty(message)) return string.Empty;

        return InterpolateCore(message, ref arguments, count);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static string InterpolateCore(string message, scoped ref string? argumentsRef, int argumentsCount)
    {
        var messageLength = message.Length;

        var messageBuilderCapacity = messageLength * argumentsCount * DefaultMessageArgumentLength;

        using scoped var messageBuilder = messageBuilderCapacity > ValueStringBuilder.MaximumSafeStackBufferSize
            ? new ValueStringBuilder(messageBuilderCapacity)
            : new ValueStringBuilder(stackalloc char[ValueStringBuilder.MaximumSafeStackBufferSize]);

        scoped var messageSpan = message.AsSpan();

        var messageIndex = 0;

        for (var argumentIndex = 0; argumentIndex < argumentsCount; argumentIndex++)
        {
            var argumentOpenIndex = message.IndexOf
            (
                value: ArgumentOpenBrace,
                startIndex: messageIndex,
                count: messageLength - messageIndex
            );

            if (argumentOpenIndex is -1) break;

            messageBuilder.Append(messageSpan[messageIndex..argumentOpenIndex]);

            var argumentOpenAfterIndex = argumentOpenIndex + 1;

            var argumentCloseIndex = message.IndexOf
            (
                ArgumentCloseBrace,
                argumentOpenAfterIndex,
                messageLength - argumentOpenAfterIndex
            );

            if (argumentCloseIndex is -1)
            {
                messageIndex = argumentOpenAfterIndex;
                break;
            }

            var argument = Unsafe.Add(ref argumentsRef, argumentIndex) ?? NullString;

            messageBuilder.Ensure(argument.Length);
            messageBuilder.Append(argument);

            messageIndex = argumentCloseIndex + 1;
        }

        messageBuilder.Append(messageSpan[messageIndex..]);
        return messageBuilder.ToString();
    }
}

[method: MethodImpl(MethodImplOptions.AggressiveInlining)]
file struct ArgumentInterpolationContext
(
    string message,
    string argument,
    int argumentStartIndex,
    int argumentEndAfterIndex
)
{
    public readonly string Message = message;

    public readonly string Argument = argument;

    public readonly int ArgumentStartIndex = argumentStartIndex;

    public readonly int ArgumentEndAfterIndex = argumentEndAfterIndex;
}

[method: MethodImpl(MethodImplOptions.AggressiveInlining)]
file struct BracerInterpolationContext
(
    string message,
    int bracerStartIndex
)
{
    public readonly string Message = message;

    public readonly int BracerStartIndex = bracerStartIndex;
}
