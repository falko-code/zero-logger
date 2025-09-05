using System.Logging.Collections;
using System.Logging.Common;
using System.Logging.Contexts;
using System.Logging.Debugs;
using System.Logging.Renderers;
using System.Runtime.CompilerServices;

namespace System.Logging.Targets;

public sealed class ConcurrentLoggerTarget : LoggerTarget
{
    private readonly SingleConsumerQueue<RenderableLogContext> _logsQueue;

    private readonly int _timeoutMilliseconds;

    private readonly LoggerTarget _loggerTarget;

    private readonly CancellationTokenSource _cancellationSource;

    private readonly CancellationToken _cancellationToken;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public ConcurrentLoggerTarget(LoggerTarget loggerTarget, int capacity = 1024, int timeoutMilliseconds = 25)
    {
        ArgumentNullException.ThrowIfNull(loggerTarget);
        CancellationTimeout.ThrowIfInvalid(timeoutMilliseconds);

        _logsQueue = new SingleConsumerQueue<RenderableLogContext>(capacity);
        _timeoutMilliseconds = timeoutMilliseconds;
        _loggerTarget = loggerTarget;
        _cancellationSource = new CancellationTokenSource();
        _cancellationToken = _cancellationSource.Token;
    }

    public override void Initialize(CancellationToken cancellationToken)
    {
        _loggerTarget.Initialize(cancellationToken);
    }

    public override void Publish
    (
        in LogContext context,
        ILogContextRenderer renderer,
        CancellationToken cancellationToken
    )
    {
        if (_cancellationToken.IsCancellationRequested)
        {
            DebugEventLogger.Handle
            (
                message: "An attempt was made to publish a log context to a disposed concurrent logger target"
            );

            return;
        }

        var logEnqueued = _logsQueue.Enqueue
        (
            item: new RenderableLogContext(context, renderer),
            cancellationToken: cancellationToken
        );

        if (logEnqueued is false)
        {
            DebugEventLogger.Handle
            (
                message: "An attempt was made to publish a log context that was canceled due upper code cancellation token"
            );

            return;
        }

        // TODO: do we need there?
    }

    public override void Dispose(CancellationToken cancellationToken)
    {
        if (_cancellationToken.IsCancellationRequested)
        {
            DebugEventLogger.Handle
            (
                message: "An attempt was made to dispose the concurrent logger target more than once"
            );

            return;
        }

        try
        {
            _cancellationSource.Cancel();
        }
        catch (Exception exception)
        {
            DebugEventLogger.Handle
            (
                message: "An exception occurred while disposing the concurrent logger target",
                exception: exception
            );
        }

        try
        {
            _cancellationSource.Dispose();
        }
        catch (Exception exception)
        {
            DebugEventLogger.Handle
            (
                message: "An exception occurred while disposing the concurrent logger target",
                exception: exception
            );
        }

        try
        {
            // _completionSource.Task.Wait(cancellationToken);
        }
        catch (Exception exception)
        {
            DebugEventLogger.Handle
            (
                message: "An exception occurred while disposing the concurrent logger target",
                exception: exception
            );
        }

        try
        {
            _loggerTarget.Dispose(cancellationToken);
        }
        catch (Exception exception)
        {
            DebugEventLogger.Handle
            (
                message: "An exception occurred while disposing the inner logger target of the concurrent logger target",
                exception: exception
            );
        }
    }

    private readonly struct RenderableLogContext
    {
        public readonly LogContext Context;

        public readonly ILogContextRenderer Renderer;

        // ReSharper disable once ConvertToPrimaryConstructor
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public RenderableLogContext(in LogContext context, ILogContextRenderer renderer)
        {
            Context = context;
            Renderer = renderer;
        }
    }
}
