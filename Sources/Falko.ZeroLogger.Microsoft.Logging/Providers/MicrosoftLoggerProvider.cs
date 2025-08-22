using System.Logging.Loggers;

namespace System.Logging.Providers;

internal sealed class MicrosoftLoggerProvider : IMicrosoftLoggerProvider
{
    private readonly LoggerRuntime _loggerRuntime;

    private readonly bool _disposeLoggerRuntime;

    // ReSharper disable once ConvertToPrimaryConstructor
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public MicrosoftLoggerProvider(LoggerRuntime loggerRuntime, bool disposeLoggerRuntime)
    {
        _loggerRuntime = loggerRuntime;
        _disposeLoggerRuntime = disposeLoggerRuntime;
    }

    public IMicrosoftLogger CreateLogger(string categoryName)
    {
        return new MicrosoftLogger(categoryName, _loggerRuntime);
    }

    public void Dispose()
    {
        if (_disposeLoggerRuntime) _loggerRuntime.Dispose();
    }
}
