namespace System.Logging.Renderers;

[method: MethodImpl(MethodImplOptions.AggressiveInlining)]
internal sealed class SingleMessageLogMessageRenderer(string? message) : ILogMessageRenderer
{
    public string Render()
    {
        return message ?? string.Empty;
    }
}
