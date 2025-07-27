using System.Logging.Loggers;
using System.Logging.Runtimes;
using System.Runtime.CompilerServices;

namespace System.Logging.Factories;

public static class LoggerFactoryExtensions
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
