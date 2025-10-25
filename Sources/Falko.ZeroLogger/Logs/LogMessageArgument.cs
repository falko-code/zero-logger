using Falko.Logging.Factories;
using Falko.Logging.Utils;

namespace Falko.Logging.Logs;

public static class LogMessageArgument
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static LogMessageArgument<T> Create<T>(T argument, LogMessageArgumentFactory<T> argumentFactory)
    {
        ArgumentNullException.ThrowIfNull(argumentFactory);

        return new LogMessageArgument<T>
        (
            argument: argument,
            argumentFactory: argumentFactory
        );
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static LogMessageArgument<T> Create<T>(T argument)
    {
        return new LogMessageArgument<T>
        (
            argument: argument,
            argumentFactory: static argument => StringUtils.ToString(argument)
        );
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static LogMessageArgument<LogMessageArgumentFactory> Create(LogMessageArgumentFactory argumentFactory)
    {
        ArgumentNullException.ThrowIfNull(argumentFactory);

        return new LogMessageArgument<LogMessageArgumentFactory>
        (
            argument: argumentFactory,
            argumentFactory: static argumentFactory => argumentFactory()
        );
    }
}
