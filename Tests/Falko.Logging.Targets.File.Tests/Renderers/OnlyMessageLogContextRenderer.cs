using Falko.Logging.Contexts;
using Falko.Logging.Renderers;

namespace Falko.Logging.Targets.File.Tests.Renderers;

public sealed class OnlyMessageLogContextRenderer : ILogContextRenderer
{
    public static readonly OnlyMessageLogContextRenderer Instance = new();

    private OnlyMessageLogContextRenderer() { }

    public string Render(in LogContext logContext)
    {
        return logContext.Message.Render() + '\n';
    }
}
