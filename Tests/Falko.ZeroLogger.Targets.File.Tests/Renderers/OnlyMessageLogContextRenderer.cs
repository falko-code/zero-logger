using System.Logging.Contexts;
using System.Logging.Renderers;

namespace Falko.ZeroLogger.Targets.File.Tests.Renderers;

public sealed class OnlyMessageLogContextRenderer : ILogContextRenderer
{
    public static readonly OnlyMessageLogContextRenderer Instance = new();

    private OnlyMessageLogContextRenderer() { }

    public string Render(in LogContext logContext)
    {
        return logContext.Message.Render() + "\n";
    }
}
