using Falko.Logging.Logs;
using Falko.Logging.Targets;

namespace Falko.Logging.Contexts;

public sealed class LoggerContext
{
    public static readonly LoggerContext Empty = new(LogLevels.None, [], [], CancellationToken.None);

    public readonly LogLevel Level;

    internal readonly LoggerTarget[] Targets;

    internal readonly LogContextRendererSpan[] Renderers;

    public readonly CancellationToken CancellationToken;

    public readonly bool IsTraceLevelEnabled;

    public readonly bool IsDebugLevelEnabled;

    public readonly bool IsInfoLevelEnabled;

    public readonly bool IsWarnLevelEnabled;

    public readonly bool IsErrorLevelEnabled;

    public readonly bool IsFatalLevelEnabled;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal LoggerContext
    (
        LogLevel level,
        LoggerTarget[] targets,
        LogContextRendererSpan[] renderers,
        CancellationToken cancellationToken
    )
    {
        Level = level;
        Targets = targets;
        Renderers = renderers;
        CancellationToken = cancellationToken;

        IsTraceLevelEnabled = level.IsEnabled(LogLevel.Trace);
        IsDebugLevelEnabled = level.IsEnabled(LogLevel.Debug);
        IsInfoLevelEnabled = level.IsEnabled(LogLevel.Info);
        IsWarnLevelEnabled = level.IsEnabled(LogLevel.Warn);
        IsErrorLevelEnabled = level.IsEnabled(LogLevel.Error);
        IsFatalLevelEnabled = level.IsEnabled(LogLevel.Fatal);
    }
}
