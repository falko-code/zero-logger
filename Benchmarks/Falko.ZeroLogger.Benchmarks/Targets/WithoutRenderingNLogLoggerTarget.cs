using NLog;
using NLog.Targets;

namespace Falko.Examples.Targets;

public sealed class WithoutRenderingNLogLoggerTarget : TargetWithLayout
{
    public WithoutRenderingNLogLoggerTarget(int index)
    {
        Name = $"{nameof(WithoutRenderingNLogLoggerTarget)}_Instance{index}";
    }

    protected override void Write(LogEventInfo logEvent)
    {
        _ = logEvent;
    }
}
