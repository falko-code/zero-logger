using System.Logging.Loggers;
using System.Logging.Runtimes;
using System.Logging.Utils;

namespace System.Logging.Factories;

[method: MethodImpl(MethodImplOptions.AggressiveInlining)]
public readonly struct LoggerFactory(LoggerRuntime loggerRuntime)
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Logger CreateLogger(string name)
    {
        ArgumentNullException.ThrowIfNull(name);

        return new Logger(loggerRuntime, name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Logger CreateLogger<T>() where T : notnull
    {
        var name = TypeUtils.GetTypeName(typeof(T));

        ArgumentNullException.ThrowIfNull(name);

        return new Logger(loggerRuntime, name);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Logger CreateLogger(Type type)
    {
        ArgumentNullException.ThrowIfNull(type);

        var name = TypeUtils.GetTypeName(type);

        ArgumentNullException.ThrowIfNull(name);

        return new Logger(loggerRuntime, name);
    }
}
