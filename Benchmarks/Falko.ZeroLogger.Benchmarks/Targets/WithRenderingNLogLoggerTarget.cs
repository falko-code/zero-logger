using NLog;
using NLog.Targets;

namespace Falko.Examples.Targets;

public sealed class WithRenderingNLogLoggerTarget : TargetWithLayout
{
    public WithRenderingNLogLoggerTarget(int index)
    {
        Name = $"{nameof(WithoutRenderingNLogLoggerTarget)}_Instance{index}";
        Layout = "[${time}] [${level:uppercase=true}] [${logger}] ${message}";
    }

    protected override void Write(LogEventInfo logEvent)
    {
        _ = Layout.Render(logEvent);
    }
}
