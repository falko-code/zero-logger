namespace System.Logging.Loggers;

internal sealed class MicrosoftLogger : IMicrosoftLogger
{
    private readonly LoggerRuntime _loggerRuntime;

    private readonly Logger _logger;

    // ReSharper disable once ConvertToPrimaryConstructor
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public MicrosoftLogger(string loggerName, LoggerRuntime loggerRuntime)
    {
        _loggerRuntime = loggerRuntime;
        _logger = loggerRuntime.LoggerFactory.CreateLogger(loggerName);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void Log<T>
    (
        MicrosoftLogLevel microsoftLogLevel,
        MicrosoftEventIdentifier microsoftEventIdentifier,
        T messageState,
        Exception? exception,
        Func<T, Exception?, string> messageFormatter
    )
    {
        var logLevel = microsoftLogLevel.ToLogLevel();
        var logMessage = new MicrosoftLogMessage<T>(messageFormatter, messageState);

        _logger.Emit(logLevel, exception, logMessage, MicrosoftLogMessage<T>.LogMessageFactory);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool IsEnabled(MicrosoftLogLevel microsoftLogLevel)
    {
        return _loggerRuntime
            .GetLoggerContext()
            .Level.IsEnabled(microsoftLogLevel.ToLogLevel());
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public IDisposable? BeginScope<T>(T messageState) where T : notnull
    {
        return null;
    }
}
