namespace System.Logging.Logs;

public static partial class MicrosoftLogLevelExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static LogLevel ToLogLevel(this MicrosoftLogLevel microsoftLogLevel)
    {
        return Unsafe.As<MicrosoftLogLevel, LogLevel>(ref microsoftLogLevel);
    }
}
