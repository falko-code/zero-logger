using Falko.Logging.Factories;

namespace Falko.Logging.Logs;

[method: MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
public readonly struct LogMessageArgument<T>(T argument, LogMessageArgumentFactory<T> argumentFactory)
{
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public override string? ToString() => argumentFactory(argument);
}
