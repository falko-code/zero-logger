namespace System.Logging.Logs;

public static partial class LogLevelExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static LogLevel ToLogLevel(this MicrosoftLogLevel microsoftLogLevel)
    {
        var nativeLogLevel = Unsafe.As<MicrosoftLogLevel, int>(ref microsoftLogLevel) + 1;
        return Unsafe.As<int, LogLevel>(ref nativeLogLevel);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static LogLevel ToMinimumLogLevel(this MicrosoftLogLevel microsoftLogLevel)
    {
        return microsoftLogLevel switch
        {
            MicrosoftLogLevel.Trace => LogLevels.TraceAndAbove,
            MicrosoftLogLevel.Debug => LogLevels.DebugAndAbove,
            MicrosoftLogLevel.Information => LogLevels.InfoAndAbove,
            MicrosoftLogLevel.Warning => LogLevels.WarnAndAbove,
            MicrosoftLogLevel.Error => LogLevels.ErrorAndAbove,
            MicrosoftLogLevel.Critical => LogLevels.FatalAndAbove,
            _ => throw new ArgumentOutOfRangeException(nameof(microsoftLogLevel), microsoftLogLevel, null)
        };
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static MicrosoftLogLevel ToMinimumLogLevel(this LogLevel logLevel)
    {
        if (logLevel.IsEnabled(LogLevel.Trace)) return MicrosoftLogLevel.Trace;
        if (logLevel.IsEnabled(LogLevel.Debug)) return MicrosoftLogLevel.Debug;
        if (logLevel.IsEnabled(LogLevel.Info)) return MicrosoftLogLevel.Information;
        if (logLevel.IsEnabled(LogLevel.Warn)) return MicrosoftLogLevel.Warning;
        if (logLevel.IsEnabled(LogLevel.Error)) return MicrosoftLogLevel.Error;
        if (logLevel.IsEnabled(LogLevel.Fatal)) return MicrosoftLogLevel.Critical;
        throw new ArgumentOutOfRangeException(nameof(logLevel), logLevel, null);
    }
}
