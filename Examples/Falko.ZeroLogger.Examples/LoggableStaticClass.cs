using System.Logging.Factories;
using System.Logging.Loggers;

namespace Falko.Examples;

public static class LoggableStaticClass
{
    private static readonly Logger Logger = typeof(LoggableStaticClass).CreateLogger();

    public static void Init()
    {
        Logger.Debug(static () => "Static class Init called");
    }
}
