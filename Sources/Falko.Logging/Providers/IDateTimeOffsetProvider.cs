namespace Falko.Logging.Providers;

internal interface IDateTimeOffsetProvider
{
    DateTimeOffset Now { get; }
}
