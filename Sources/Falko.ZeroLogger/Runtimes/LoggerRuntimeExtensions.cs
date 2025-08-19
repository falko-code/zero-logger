using System.Logging.Builders;

namespace System.Logging.Runtimes;

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

        loggerRuntime.Initialize(loggerBuilder, CancellationToken.None);

        return loggerRuntime;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static LoggerRuntime Initialize
    (
        this LoggerRuntime loggerRuntime,
        TimeSpan timeout,
        Func<LoggerContextBuilder, LoggerContextBuilder> loggerBuilderFactory
    )
    {
        ArgumentNullException.ThrowIfNull(loggerRuntime);
        ArgumentNullException.ThrowIfNull(loggerBuilderFactory);

        var loggerBuilder = loggerBuilderFactory(new LoggerContextBuilder());

        loggerRuntime.Initialize(loggerBuilder, timeout);

        return loggerRuntime;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static LoggerRuntime Initialize
    (
        this LoggerRuntime loggerRuntime,
        CancellationToken cancellationToken,
        Func<LoggerContextBuilder, LoggerContextBuilder> loggerBuilderFactory
    )
    {
        ArgumentNullException.ThrowIfNull(loggerRuntime);
        ArgumentNullException.ThrowIfNull(loggerBuilderFactory);

        var loggerBuilder = loggerBuilderFactory(new LoggerContextBuilder());

        loggerRuntime.Initialize(loggerBuilder, cancellationToken);

        return loggerRuntime;
    }
}
