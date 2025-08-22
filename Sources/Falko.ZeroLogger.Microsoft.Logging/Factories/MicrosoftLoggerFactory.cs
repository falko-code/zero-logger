using System.Collections.Concurrent;
using System.Logging.Loggers;

namespace System.Logging.Factories;

public sealed class MicrosoftLoggerFactory : IMicrosoftLoggerFactory
{
    private readonly ConcurrentDictionary<string, IMicrosoftLogger> _loggers = new(StringComparer.Ordinal);

    private readonly LoggerRuntime _loggerRuntime;

    private readonly bool _disposeLoggerRuntime;

    // ReSharper disable once ConvertToPrimaryConstructor
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public MicrosoftLoggerFactory(LoggerRuntime loggerRuntime, bool disposeLoggerRuntime)
    {
        _loggerRuntime = loggerRuntime;
        _disposeLoggerRuntime = disposeLoggerRuntime;
    }

    public IMicrosoftLogger CreateLogger(string categoryName)
    {
        return _loggers.GetOrAdd
        (
            categoryName,
            static (categoryName, loggerRuntime) => new MicrosoftLogger(categoryName, loggerRuntime),
            _loggerRuntime
        );
    }

    public void AddProvider(IMicrosoftLoggerProvider provider) { }

    public void Dispose()
    {
        _loggerRuntime.Dispose();
    }
}
