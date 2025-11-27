using Falko.Logging.Contexts;

namespace Falko.Logging.Renderers;

public interface ILogContextRenderer
{
    string Render(in LogContext logContext);
}
