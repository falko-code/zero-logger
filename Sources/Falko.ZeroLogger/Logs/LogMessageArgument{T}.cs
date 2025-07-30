using System.Logging.Factories;
using System.Runtime.CompilerServices;

namespace System.Logging.Logs;

[method: MethodImpl(MethodImplOptions.AggressiveInlining)]
public readonly struct LogMessageArgument<T>(T argument, LogMessageArgumentFactory<T> argumentFactory)
{
    public readonly T Argument = argument;

    public readonly LogMessageArgumentFactory<T> ArgumentFactory = argumentFactory;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string? ToString() => ArgumentFactory(Argument);
}
