using System.Runtime.CompilerServices;

namespace System.Logging.Targets;

public static partial class LoggerTargetExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static LoggerTarget AsConcurrent(this LoggerTarget loggerTarget, int capacity = 1024, int timeoutMilliseconds = 25)
    {
        return new ConcurrentLoggerTarget(loggerTarget, capacity, timeoutMilliseconds);
    }
}
