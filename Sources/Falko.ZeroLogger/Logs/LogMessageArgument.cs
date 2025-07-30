using System.Logging.Factories;
using System.Logging.Utils;
using System.Runtime.CompilerServices;

namespace System.Logging.Logs;

public static class LogMessageArgument
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static LogMessageArgument<T> Create<T>(T argument, LogMessageArgumentFactory<T> argumentFactory)
    {
        ArgumentNullException.ThrowIfNull(argumentFactory, nameof(argumentFactory));

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
        ArgumentNullException.ThrowIfNull(argumentFactory, nameof(argumentFactory));

        return new LogMessageArgument<LogMessageArgumentFactory>
        (
            argument: argumentFactory,
            argumentFactory: static argumentFactory => argumentFactory()
        );
    }
}
