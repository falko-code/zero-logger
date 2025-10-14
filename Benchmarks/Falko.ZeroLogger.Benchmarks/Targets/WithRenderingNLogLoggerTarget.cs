using NLog;
using NLog.Targets;

namespace Falko.Examples.Targets;

public sealed class WithRenderingNLogLoggerTarget : TargetWithLayout
{
    public static readonly WithRenderingNLogLoggerTarget Instance = new()
    {
        Layout = "[${time}] [${level:uppercase=true}] [${logger}] ${message}",
    };

    private WithRenderingNLogLoggerTarget() { }

    protected override void Write(LogEventInfo logEvent)
    {
        _ = Layout.Render(logEvent);
    }
}
