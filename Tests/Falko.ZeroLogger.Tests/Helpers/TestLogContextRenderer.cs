using System.Logging.Contexts;
using System.Logging.Renderers;

namespace Falko.ZeroLogger.Tests.Helpers;

public sealed class TestLogContextRenderer : ILogContextRenderer
{
    public static readonly TestLogContextRenderer Instance = new();

    private TestLogContextRenderer() { }

    public string Render(in LogContext logContext)
    {
        return $"[{logContext.Level}] {logContext.Source}: {logContext.Message.Render()}" +
               (logContext.Exception != null ? $" | Exception: {logContext.Exception.Message}" : "");
    }
}