using Falko.Logging.Contexts;

namespace Falko.Logging.Renderers;

[method: MethodImpl(MethodImplOptions.AggressiveInlining)]
internal sealed class PersistentLogContextRenderer(ILogContextRenderer renderer) : ILogContextRenderer
{
    private volatile string? _message;

    public string Render(in LogContext logContext)
    {
        if (_message is not null) return _message;

        var message = renderer.Render(logContext);
        _message = message;
        return message;
    }
}
