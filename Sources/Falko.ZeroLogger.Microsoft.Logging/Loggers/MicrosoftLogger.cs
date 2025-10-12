using Falko.Logging.Logs;
using Falko.Logging.Runtimes;

namespace Falko.Logging.Loggers;

public sealed class MicrosoftLogger : IMicrosoftLogger
{
    private readonly LoggerRuntime _loggerRuntime;

    private readonly Logger _logger;

    // ReSharper disable once ConvertToPrimaryConstructor
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal MicrosoftLogger(string loggerName, LoggerRuntime loggerRuntime)
    {
        _loggerRuntime = loggerRuntime;
        _logger = loggerRuntime.LoggerFactory.CreateLogger(loggerName);
    }

    public void Log<TState>
    (
        MicrosoftLogLevel microsoftLogLevel,
        MicrosoftEventIdentifier microsoftEventIdentifier,
        TState messageState,
        Exception? exception,
        Func<TState, Exception?, string> messageFormatter
    )
    {
        var logLevel = microsoftLogLevel.ToLogLevel();
        var logMessage = new MicrosoftLogMessage<TState>(messageFormatter, messageState);

        _logger.Emit(logLevel, exception, logMessage, MicrosoftLogMessage<TState>.LogMessageFactory);
    }

    public bool IsEnabled(MicrosoftLogLevel microsoftLogLevel)
    {
        return _loggerRuntime
            .GetLoggerContext()
            .Level.IsEnabled(microsoftLogLevel.ToLogLevel());
    }

    public IDisposable? BeginScope<T>(T messageState) where T : notnull
    {
        return null;
    }
}
