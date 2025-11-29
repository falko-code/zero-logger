using Falko.Logging.Contexts;

namespace Falko.Logging.Renderers;

public interface ILogContextRenderer
{
    string Render(scoped ref readonly LogContext logContext);
}
