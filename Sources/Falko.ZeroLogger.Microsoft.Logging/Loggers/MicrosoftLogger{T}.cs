using Microsoft.Extensions.Logging;

namespace System.Logging.Loggers;

public sealed class MicrosoftLogger<TTarget> : ILogger<TTarget>
{
    private readonly IMicrosoftLogger _logger;

    // ReSharper disable once ConvertToPrimaryConstructor
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public MicrosoftLogger(IMicrosoftLoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<TTarget>();
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
        _logger.Log
        (
            microsoftLogLevel,
            microsoftEventIdentifier,
            messageState,
            exception,
            messageFormatter
        );
    }

    public bool IsEnabled(MicrosoftLogLevel microsoftLogLevel)
    {
        return _logger.IsEnabled(microsoftLogLevel);
    }

    public IDisposable? BeginScope<T>(T messageState) where T : notnull
    {
        return _logger.BeginScope(messageState);
    }
}
