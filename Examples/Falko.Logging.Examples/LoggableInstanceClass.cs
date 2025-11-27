using Falko.Logging.Factories;
using Falko.Logging.Loggers;

namespace Falko.Examples;

public sealed class LoggableInstanceClass
{
    private static readonly Logger Logger = typeof(LoggableInstanceClass).CreateLogger();

    public void Init()
    {
        Logger.Debug(static () => "Instance class Init called");
    }
}
