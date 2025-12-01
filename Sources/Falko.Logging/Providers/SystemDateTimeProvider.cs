namespace Falko.Logging.Providers;

internal sealed class SystemDateTimeProvider : IDateTimeProvider
{
    public DateTime Now
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DateTime.Now;
    }
}
