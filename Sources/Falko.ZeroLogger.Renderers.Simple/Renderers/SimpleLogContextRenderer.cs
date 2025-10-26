using System.Numerics;
using Falko.Logging.Builders;
using Falko.Logging.Contexts;
using Falko.Logging.Logs;

namespace Falko.Logging.Renderers;

public sealed class SimpleLogContextRenderer : ILogContextRenderer
{
    public static readonly SimpleLogContextRenderer Instance = new();

    private static readonly string[] LevelShortNames =
    [
        "TRC",
        "DBG",
        "INF",
        "WRN",
        "ERR",
        "FTL"
    ];

    private static readonly string NewLine = Environment.NewLine;
    private static readonly int NewLineLength = NewLine.Length;

    private const string UnknownException = "UnknownException";

    private const string ExceptionTypeBlockName = "Exception: ";
    private static readonly int ExceptionTypeBlockNameLength = ExceptionTypeBlockName.Length;

    private const string ExceptionMessageBlockName = "Message: ";
    private static readonly int ExceptionMessageBlockNameLength = ExceptionMessageBlockName.Length;

    private static readonly string ExceptionStackTraceBlockName = $"Trace:{NewLine}";
    private static readonly int ExceptionStackTraceBlockNameLength = ExceptionStackTraceBlockName.Length;

    private static readonly int DefiledMessageHeaderLength = NewLineLength + TimeHeaderBlockLength + LevelHeaderBlockLength;

    private const int ExceptionBlockPadding = 2;

    private const int TimeHeaderLength = 12;

    private const int TimeHeaderBlockLength = TimeHeaderLength + BlockMinimumLength;

    private const int LevelHeaderBlockLength = 3 + BlockMinimumLength;

    private const int BlockMinimumLength = 3;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private SimpleLogContextRenderer() { }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public string Render(in LogContext logContext)
    {
        var levelText = FormatLevel(logContext.Level);

        var sourceText = logContext.Source;

        var messageText = logContext.Message.Render();

        var messageLength = messageText.Length
            + GetHeaderBlockLength(sourceText)
            + DefiledMessageHeaderLength;

        var exception = logContext.Exception;

        if (exception is null)
        {
            return string.Create(messageLength, (logContext.Time, levelText, sourceText, messageText), static (span, context) =>
            {
                var messageBuilder = new ValueStringBuilder(span);

                RenderHeader(ref messageBuilder, context.Time, context.levelText, context.sourceText, context.messageText);
            });
        }

        var exceptionTypeName = exception.GetType().FullName ?? UnknownException;

        var exceptionMessage = exception.Message;

        var exceptionStackTrace = exception.StackTrace;
        var exceptionStackTraceBlockLength = exceptionStackTrace is not null
            ? GetExceptionBlockLength(ExceptionStackTraceBlockNameLength, exceptionStackTrace)
            : 0;

        messageLength = messageLength
                        + GetExceptionBlockLength(ExceptionTypeBlockNameLength, exceptionTypeName)
                        + GetExceptionBlockLength(ExceptionMessageBlockNameLength, exceptionMessage)
                        + exceptionStackTraceBlockLength;

        return string.Create(messageLength, (logContext.Time, levelText, sourceText, messageText, exceptionTypeName, exceptionMessage, exceptionStackTrace, exception), static (span, context) =>
        {
            var messageBuilder = new ValueStringBuilder(span);

            RenderHeader(ref messageBuilder, context.Time, context.levelText, context.sourceText, context.messageText);

            RenderExceptionBlock(ref messageBuilder, ExceptionTypeBlockName, context.exceptionTypeName);
            RenderExceptionBlock(ref messageBuilder, ExceptionMessageBlockName, context.exceptionMessage);

            if (context.exceptionStackTrace is not null)
            {
                RenderExceptionBlock(ref messageBuilder, ExceptionStackTraceBlockName, context.exceptionStackTrace);
            }
        });
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void RenderHeader(scoped ref ValueStringBuilder messageBuilder,
        DateTimeOffset time,
        string levelText,
        string sourceText,
        string messageText)
    {
        RenderTimeHeaderBlock(ref messageBuilder, time);
        RenderHeaderBlock(ref messageBuilder, levelText);
        RenderHeaderBlock(ref messageBuilder, sourceText);

        messageBuilder.Append(messageText);

        messageBuilder.Append(NewLine);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int GetHeaderBlockLength(string blockText)
    {
        return blockText.Length + BlockMinimumLength;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void RenderHeaderBlock(scoped ref ValueStringBuilder messageBuilder,
        string blockText)
    {
        messageBuilder.Append('[');
        messageBuilder.Append(blockText);
        messageBuilder.Append(']');
        messageBuilder.Append(' ');
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void RenderTimeHeaderBlock(scoped ref ValueStringBuilder messageBuilder,
        DateTimeOffset time)
    {
        messageBuilder.Append('[');
        AppendTime(ref messageBuilder, time);
        messageBuilder.Append(']');
        messageBuilder.Append(' ');
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int GetExceptionBlockLength(int blockNameLength, string blockText)
    {
        return ExceptionBlockPadding + blockNameLength + blockText.Length + NewLineLength;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void RenderExceptionBlock(scoped ref ValueStringBuilder messageBuilder,
        string blockName,
        string blockText)
    {
        messageBuilder.Append(' ', ExceptionBlockPadding);
        messageBuilder.Append(blockName);
        messageBuilder.Append(blockText);
        messageBuilder.Append(NewLine);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static string FormatLevel(LogLevel level)
    {
        var index = BitOperations.TrailingZeroCount((int)level);

        return LevelShortNames[index];
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void AppendTime(scoped ref ValueStringBuilder messageBuilder, DateTimeOffset time)
    {
        messageBuilder.Append(TimeHeaderLength, time.TimeOfDay, static (buffer, time) =>
        {
            var hours = time.Hours;
            var hoursTensDigit = hours / 10;
            var hoursOnesDigit = hours - hoursTensDigit * 10;
            buffer[0] = (char)('0' + hoursTensDigit);
            buffer[1] = (char)('0' + hoursOnesDigit);
            buffer[2] = ':';

            var minutes = time.Minutes;
            var minutesTensDigit = minutes / 10;
            var minutesOnesDigit = minutes - minutesTensDigit * 10;
            buffer[3] = (char)('0' + minutesTensDigit);
            buffer[4] = (char)('0' + minutesOnesDigit);
            buffer[5] = ':';

            var seconds = time.Seconds;
            var secondsTensDigit = seconds / 10;
            var secondsOnesDigit = seconds - secondsTensDigit * 10;
            buffer[6] = (char)('0' + secondsTensDigit);
            buffer[7] = (char)('0' + secondsOnesDigit);
            buffer[8] = '.';

            var milliseconds = time.Milliseconds;
            var millisecondsHundredsDigit = milliseconds / 100;
            var millisecondsRemainder = milliseconds - millisecondsHundredsDigit * 100;
            var millisecondsTensDigit = millisecondsRemainder / 10;
            var millisecondsOnesDigit = millisecondsRemainder - millisecondsTensDigit * 10;
            buffer[9] = (char)('0' + millisecondsHundredsDigit);
            buffer[10] = (char)('0' + millisecondsTensDigit);
            buffer[11] = (char)('0' + millisecondsOnesDigit);
        });
    }
}
