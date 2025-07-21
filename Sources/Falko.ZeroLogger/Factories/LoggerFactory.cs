using System.Logging.Loggers;
using System.Logging.Runtimes;
using System.Runtime.CompilerServices;

namespace System.Logging.Factories;

public readonly struct LoggerFactory(LoggerRuntime loggerRuntime)
{
    public static readonly LoggerFactory Global = LoggerRuntime.Global.LoggerFactory;

    public Logger CreateLoggerOfName(string name)
    {
        ArgumentNullException.ThrowIfNull(name);

        return new Logger(loggerRuntime, name);
    }

    public Logger CreateLoggerOfType<T>() where T : notnull
    {
        var name = typeof(T).FullName;

        ArgumentNullException.ThrowIfNull(name);

        return new Logger(loggerRuntime, name);
    }

    public Logger CreateLoggerOfType(Type type)
    {
        ArgumentNullException.ThrowIfNull(type);

        var name = type.FullName;

        ArgumentNullException.ThrowIfNull(name);

        return new Logger(loggerRuntime, name);
    }

    public Logger CreateLoggerOfClass<T>() where T : class
    {
        var name = typeof(T).Name;

        ArgumentNullException.ThrowIfNull(name);

        return new Logger(loggerRuntime, name);
    }

    public Logger CreateLoggerOfClass(Type type)
    {
        ArgumentNullException.ThrowIfNull(type);

        if (!type.IsClass)
        {
            throw new ArgumentException($"Type '{type.FullName}' is not a class.", nameof(type));
        }

        var name = type.Name;

        ArgumentNullException.ThrowIfNull(name);

        return new Logger(loggerRuntime, name);
    }

    public Logger CreateLoggerOfObject()
    {
        throw new NotImplementedException();
    }

    public Logger CreateLoggerOfMethod<T>([CallerMemberName] string member = null!) where T : notnull
    {
        ArgumentNullException.ThrowIfNull(member);

        var name = typeof(T).FullName;

        ArgumentNullException.ThrowIfNull(name);

        return new Logger(loggerRuntime, $"{name}.{member}");
    }

    public Logger CreateLoggerOfMethod(Type type, [CallerMemberName] string member = null!)
    {
        ArgumentNullException.ThrowIfNull(type);
        ArgumentNullException.ThrowIfNull(member);

        var name = type.FullName;

        ArgumentNullException.ThrowIfNull(name);

        return new Logger(loggerRuntime, $"{name}.{member}");
    }

    public static Logger CreateLoggerOfMethod([CallerMemberName] string member = null!)
    {
        ArgumentNullException.ThrowIfNull(member);

        throw new NotImplementedException();
    }
}
