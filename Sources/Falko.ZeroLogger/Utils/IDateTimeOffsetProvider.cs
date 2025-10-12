namespace Falko.Logging.Utils;

internal interface IDateTimeOffsetProvider
{
    DateTimeOffset Now { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; }
}
