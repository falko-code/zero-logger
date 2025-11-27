namespace Falko.Logging.Providers;

internal interface IDateTimeOffsetProvider
{
    DateTimeOffset Now { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; }
}
