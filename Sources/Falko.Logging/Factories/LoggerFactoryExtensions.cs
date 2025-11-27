using Falko.Logging.Loggers;
using Falko.Logging.Runtimes;

namespace Falko.Logging.Factories;

public static partial class LoggerFactoryExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Logger CreateLogger(this Type type)
    {
        return LoggerRuntime.Global.LoggerFactory.CreateLogger(type);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Logger CreateLogger(this Type type, LoggerRuntime runtime)
    {
        ArgumentNullException.ThrowIfNull(runtime);

        return runtime.LoggerFactory.CreateLogger(type);
    }
}
