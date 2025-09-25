using System.Logging.Collections;
using System.Logging.Concurrents;
using System.Logging.Contexts;
using System.Logging.Debugs;
using System.Logging.Renderers;

namespace System.Logging.Targets;

public sealed partial class ConcurrentLoggerTarget : LoggerTarget, IThreadPoolWorkItem
{
    private static readonly Action<LoggerTarget, RenderableLogContext> PublishLogDelegate = PublishLog;

    private readonly SingleConsumerQueue<RenderableLogContext> _logsQueue;

    private readonly int _timeoutMilliseconds;

    private readonly LoggerTarget _loggerTarget;

    private ConcurrentBoolean _initialized;

    private ConcurrentBoolean _executing;

    private ConcurrentBoolean _disposed;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public ConcurrentLoggerTarget(LoggerTarget loggerTarget, int capacity = 1024, int timeoutMilliseconds = 24)
    {
        ArgumentNullException.ThrowIfNull(loggerTarget);
        CancellationTimeout.ThrowIfInvalid(timeoutMilliseconds);

        _logsQueue = new SingleConsumerQueue<RenderableLogContext>(capacity);
        _timeoutMilliseconds = timeoutMilliseconds;
        _loggerTarget = loggerTarget;
    }

    public override bool RequiresSynchronization => false;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void Initialize(CancellationContext cancellationContext)
    {
        if (_disposed.IsTrue()) return;

        if (_initialized.IsTrue()) return;

        _loggerTarget.Initialize(cancellationContext);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void Publish
    (
        in LogContext context,
        ILogContextRenderer renderer,
        CancellationToken cancellationToken
    )
    {
        if (_disposed.IsTrue()) return;

        var enqueued = _logsQueue.Enqueue
        (
            item: new RenderableLogContext(context, renderer, cancellationToken),
            cancellationToken: cancellationToken
        );

        if (enqueued is false) return;

        TryQueueWorkItem();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void Execute()
    {
        var cancellationTimeout = new CancellationTimeout(_timeoutMilliseconds);

        var all = _logsQueue.Dequeue
        (
            argument: _loggerTarget,
            iteration: PublishLogDelegate,
            cancellationTimeout: cancellationTimeout
        );

        if (all is false) QueueWorkItem();
        else if (_executing.TrySetFalse()) TryQueueWorkItem();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void Dispose(CancellationContext cancellationContext)
    {
        if (_disposed.TrySetTrue() is false) return;

        _executing.WaitFalse();

        try
        {
            _loggerTarget.Dispose(cancellationContext);
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

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void TryQueueWorkItem()
    {
        if (_disposed.IsTrue()) return;

        if (_logsQueue.IsEmpty) return;

        if (_executing.TrySetTrue() is false) return;

        QueueWorkItem();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void QueueWorkItem()
    {
        ThreadPool.UnsafeQueueUserWorkItem(this, preferLocal: false);
    }

    private static void PublishLog(LoggerTarget loggerTarget, RenderableLogContext logContext)
    {
        try
        {
            loggerTarget.Publish(context: logContext.Context, renderer: logContext.Renderer, cancellationToken: logContext.CancellationToken);
        }
        catch (Exception exception)
        {
            DebugEventLogger.Handle
            (
                message: "An exception occurred while publishing a log context from the concurrent logger target to the inner logger target",
                exception: exception
            );
        }
    }
}
