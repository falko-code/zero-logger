using System.Logging.Logs;
using System.Logging.Renderers;

namespace System.Logging.Contexts;

[method: MethodImpl(MethodImplOptions.AggressiveInlining)]
public readonly struct LogContext(string source, LogLevel level, DateTimeOffset time, ILogMessageRenderer message)
{
    public string Source => source;

    public LogLevel Level => level;

    public DateTimeOffset Time => time;

    public ILogMessageRenderer Message => message;

    public Exception? Exception { get; init; }
}
