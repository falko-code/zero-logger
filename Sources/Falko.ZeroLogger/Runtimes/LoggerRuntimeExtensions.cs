using Falko.Logging.Builders;
using Falko.Logging.Concurrents;

namespace Falko.Logging.Runtimes;

public static partial class LoggerRuntimeExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static LoggerRuntime Initialize
    (
        this LoggerRuntime loggerRuntime,
        Func<LoggerContextBuilder, LoggerContextBuilder> loggerBuilderFactory
    )
    {
        ArgumentNullException.ThrowIfNull(loggerRuntime);
        ArgumentNullException.ThrowIfNull(loggerBuilderFactory);

        var loggerBuilder = loggerBuilderFactory(new LoggerContextBuilder());

        loggerRuntime.Initialize(loggerBuilder, CancellationContext.None);

        return loggerRuntime;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static LoggerRuntime Initialize
    (
        this LoggerRuntime loggerRuntime,
        CancellationContext cancellationContext,
        Func<LoggerContextBuilder, LoggerContextBuilder> loggerBuilderFactory
    )
    {
        ArgumentNullException.ThrowIfNull(loggerRuntime);
        ArgumentNullException.ThrowIfNull(loggerBuilderFactory);

        var loggerBuilder = loggerBuilderFactory(new LoggerContextBuilder());

        loggerRuntime.Initialize(loggerBuilder, cancellationContext);

        return loggerRuntime;
    }
}
