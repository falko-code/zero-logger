namespace System.Logging.Utils;

internal static class DateTimeOffsetProvider
{
    public static readonly IDateTimeOffsetProvider Current = OperatingSystem.IsLinux()
        ? new SystemDateTimeOffsetProvider()
        : new ProcessorDateTimeOffsetProvider();
}
