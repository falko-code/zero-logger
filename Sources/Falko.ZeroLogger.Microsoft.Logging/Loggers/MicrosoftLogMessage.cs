using System.Logging.Factories;

namespace System.Logging.Loggers;

internal readonly struct MicrosoftLogMessage<T>
{
    public static readonly LogMessageFactory<MicrosoftLogMessage<T>> LogMessageFactory =
        static logMessage => logMessage.ToString();

    private readonly Func<T, Exception?, string> _messageFormatter;

    private readonly T _messageState;

    // ReSharper disable once ConvertToPrimaryConstructor
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public MicrosoftLogMessage(Func<T, Exception?, string> messageFormatter, T messageState)
    {
        _messageFormatter = messageFormatter;
        _messageState = messageState;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString()
    {
        return _messageFormatter(_messageState, null);
    }
}
