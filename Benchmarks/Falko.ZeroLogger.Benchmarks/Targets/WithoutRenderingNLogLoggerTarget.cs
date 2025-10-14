using NLog;
using NLog.Targets;

namespace Falko.Examples.Targets;

public sealed class WithoutRenderingNLogLoggerTarget : TargetWithLayout
{
    public static readonly WithoutRenderingNLogLoggerTarget Instance = new();

    private WithoutRenderingNLogLoggerTarget() { }

    protected override void Write(LogEventInfo logEvent)
    {
        _ = logEvent;
    }
}
