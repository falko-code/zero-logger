using System.Logging.Providers;

namespace System.Logging.Runtimes;

public static partial class LoggerRuntimeExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IMicrosoftLoggerProvider ToMicrosoftLoggerProvider
    (
        this LoggerRuntime loggerRuntime,
        bool forceDispose = false
    )
    {
        ArgumentNullException.ThrowIfNull(loggerRuntime);

        return new MicrosoftLoggerProvider(loggerRuntime, forceDispose);
    }
}
