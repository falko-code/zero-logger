namespace Falko.Logging.Renderers;

internal abstract class PersistentLogMessageRenderer : ILogMessageRenderer
{
    private string? _message;

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public string Render()
    {
        var currentMessage = _message;
        if (currentMessage is not null) return currentMessage;

        var newMessage = RenderCore();
        _message = newMessage;
        return newMessage;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    protected abstract string RenderCore();
}
