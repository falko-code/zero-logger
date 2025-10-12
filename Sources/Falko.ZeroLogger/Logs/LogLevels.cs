namespace Falko.Logging.Logs;

public static class LogLevels
{
    public static LogLevel TraceAndAbove =>
        LogLevel.Trace |
        LogLevel.Debug |
        LogLevel.Info |
        LogLevel.Warn |
        LogLevel.Error |
        LogLevel.Fatal;

    public static LogLevel DebugAndAbove =>
        LogLevel.Debug |
        LogLevel.Info |
        LogLevel.Warn |
        LogLevel.Error |
        LogLevel.Fatal;

    public static LogLevel InfoAndAbove =>
        LogLevel.Info |
        LogLevel.Warn |
        LogLevel.Error |
        LogLevel.Fatal;

    public static LogLevel WarnAndAbove =>
        LogLevel.Warn |
        LogLevel.Error |
        LogLevel.Fatal;

    public static LogLevel ErrorAndAbove =>
        LogLevel.Error |
        LogLevel.Fatal;

    public static LogLevel FatalAndAbove =>
        LogLevel.Fatal;

    public static LogLevel None => 0;
}
