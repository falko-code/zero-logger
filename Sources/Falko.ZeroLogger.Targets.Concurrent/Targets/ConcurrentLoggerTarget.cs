using System.Logging.Collections;
using System.Logging.Common;
using System.Logging.Contexts;
using System.Logging.Debugs;
using System.Logging.Renderers;
using System.Runtime.CompilerServices;

namespace System.Logging.Targets;

public sealed class ConcurrentLoggerTarget : LoggerTarget, IThreadPoolWorkItem
{
    private readonly SingleConsumerQueue<RenderableLogContext> _logsQueue;

    private readonly int _timeoutMilliseconds;

    private readonly LoggerTarget _loggerTarget;

    private volatile int _initialized;

    private volatile int _executing;

    private volatile int _disposed;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public ConcurrentLoggerTarget(LoggerTarget loggerTarget, int capacity = 1024, int timeoutMilliseconds = 25)
    {
        ArgumentNullException.ThrowIfNull(loggerTarget);
        CancellationTimeout.ThrowIfInvalid(timeoutMilliseconds);

        _logsQueue = new SingleConsumerQueue<RenderableLogContext>(capacity);
        _timeoutMilliseconds = timeoutMilliseconds;
        _loggerTarget = loggerTarget;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void Initialize(CancellationToken cancellationToken)
    {
        if (_disposed is 1) return;

        var initialized = _initialized;

        if (initialized is 1 || Interlocked.CompareExchange(ref _initialized, 1, initialized) is 1)
        {
            return;
        }

        _loggerTarget.Initialize(cancellationToken);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void Publish
    (
        in LogContext context,
        ILogContextRenderer renderer,
        CancellationToken cancellationToken
    )
    {
        if (_disposed is 1) return;

        var enqueued = _logsQueue.Enqueue
        (
            item: new RenderableLogContext(context, renderer),
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
            iteration: static (loggerTarget, log) =>
            {
                try
                {
                    loggerTarget.Publish
                    (
                        context: log.Context,
                        renderer: log.Renderer,
                        cancellationToken: CancellationToken.None
                    );
                }
                catch (Exception exception)
                {
                    DebugEventLogger.Handle
                    (
                        message: "An exception occurred while publishing a log context from the concurrent logger target to the inner logger target",
                        exception: exception
                    );
                }
            },
            cancellationTimeout: cancellationTimeout
        );

        if (all is false) QueueWorkItem();
        else Interlocked.CompareExchange(ref _executing, 0, 1);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public override void Dispose(CancellationToken cancellationToken)
    {
        var disposed = _disposed;

        if (disposed is 1 || Interlocked.CompareExchange(ref _disposed, 1, disposed) is 1)
        {
            return;
        }

        if (_executing is 1)
        {
            var waiter = new SpinWait();

            do waiter.SpinOnce();
            while (_executing is 1);
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

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void TryQueueWorkItem()
    {
        if (_disposed is 1) return;

        var executing = _executing;

        if (executing is not 0 || Interlocked.CompareExchange(ref _executing, 1, executing) is 1)
        {
            return;
        }

        QueueWorkItem();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void QueueWorkItem()
    {
        ThreadPool.UnsafeQueueUserWorkItem(this, preferLocal: false);
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
