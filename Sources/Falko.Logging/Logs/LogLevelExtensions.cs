namespace Falko.Logging.Logs;

public static partial class LogLevelExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsEnabled(this LogLevel level, LogLevel logLevel)
    {
        return (level & logLevel) == logLevel;
    }
}
