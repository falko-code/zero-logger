namespace Falko.ZeroLogger.Microsoft.Logging.Extensions;

internal static class MicrosoftLogLevelExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static LogLevel ToLogLevel(this MicrosoftLogLevel microsoftLogLevel)
    {
        return Unsafe.As<MicrosoftLogLevel, LogLevel>(ref microsoftLogLevel);
    }
}
