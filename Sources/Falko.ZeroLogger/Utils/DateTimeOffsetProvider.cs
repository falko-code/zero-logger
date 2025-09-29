namespace System.Logging.Utils;

internal static class DateTimeOffsetProvider
{
    public static readonly IDateTimeOffsetProvider Current;

    static DateTimeOffsetProvider()
    {
        Current = OperatingSystem.IsLinux() || OperatingSystem.IsFreeBSD()
            ? new SystemDateTimeOffsetProvider()
            : new ProcessorDateTimeOffsetProvider();
    }
}
