namespace Falko.Logging.Utils;

public sealed class SystemDateTimeOffsetProvider : IDateTimeOffsetProvider
{
    public DateTimeOffset Now
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => DateTimeOffset.Now;
    }
}
