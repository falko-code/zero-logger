using System.Collections.Concurrent;
using System.Logging.Concurrents;
using System.Logging.Contexts;
using System.Logging.Renderers;
using System.Logging.Targets;

namespace Falko.ZeroLogger.Tests.Helpers;

public class TestLoggerTarget : LoggerTarget
{
    private readonly ConcurrentQueue<string> _logMessages = new();
    private volatile bool _isInitialized;
    private volatile bool _isDisposed;

    public override bool RequiresSynchronization => false;

    public IReadOnlyList<string> LogMessages => _logMessages.ToArray();
    public bool IsInitialized => _isInitialized;
    public bool IsDisposed => _isDisposed;

    public override void Initialize(CancellationContext cancellationContext)
    {
        _isInitialized = true;
    }

    public override void Publish(in LogContext context, ILogContextRenderer renderer, CancellationToken cancellationToken)
    {
        if (_isDisposed) return;

        var renderedMessage = renderer.Render(context);
        _logMessages.Enqueue(renderedMessage);
    }

    public override void Dispose(CancellationContext cancellationContext)
    {
        _isDisposed = true;
    }

    public void Clear() => _logMessages.Clear();
}