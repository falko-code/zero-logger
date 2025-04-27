namespace System.Logging.Renderers;

internal abstract class PersistentLogMessageRenderer : ILogMessageRenderer
{
    private string? _message;

    public string Render()
    {
        if (_message is not null) return _message;

        var message = RenderCore();
        _message = message;
        return message;
    }

    protected abstract string RenderCore();
}
