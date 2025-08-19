namespace System.Logging.Logs;

public static class LogLevelExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsEnabled(this LogLevel level, LogLevel logLevel)
    {
        return (level & logLevel) == logLevel;
    }
}
