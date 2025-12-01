namespace Falko.Logging.Providers;

internal sealed class SystemDateTimeOffsetProvider : IDateTimeOffsetProvider
{
    public DateTime Now
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        get => DateTime.Now;
    }
}
