namespace System.Logging.Utils;

[method: MethodImpl(MethodImplOptions.AggressiveInlining)]
internal sealed class SystemDateTimeOffsetProvider() : IDateTimeOffsetProvider
{
    public DateTimeOffset Now
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => DateTimeOffset.Now;
    }
}
