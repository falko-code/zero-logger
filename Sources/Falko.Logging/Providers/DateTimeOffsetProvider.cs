namespace Falko.Logging.Providers;

internal static class DateTimeOffsetProvider
{
    public static readonly IDateTimeProvider Current;

    static DateTimeOffsetProvider()
    {
        Current = OperatingSystem.IsLinux() || OperatingSystem.IsFreeBSD()
            ? new SystemDateTimeProvider()
            : new ProcessorDateTimeProvider();
    }
}
