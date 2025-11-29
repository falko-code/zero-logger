using Falko.Logging.Contexts;

namespace Falko.Logging.Renderers;

[method: MethodImpl(MethodImplOptions.AggressiveInlining)]
internal sealed class PersistentLogContextRenderer(ILogContextRenderer renderer) : ILogContextRenderer
{
    private string? _message;

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public string Render(scoped ref readonly LogContext logContext)
    {
        var currentMessage = Volatile.Read(ref _message);
        if (currentMessage is not null) return currentMessage;

        var newMessage = renderer.Render(in logContext);
        Volatile.Write(ref _message, newMessage);
        return newMessage;
    }
}
