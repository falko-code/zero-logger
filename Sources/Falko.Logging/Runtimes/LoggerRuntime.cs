using Falko.Logging.Builders;
using Falko.Logging.Concurrents;
using Falko.Logging.Contexts;
using Falko.Logging.Debugs;
using Falko.Logging.Factories;
using Falko.Logging.Targets;

namespace Falko.Logging.Runtimes;

public sealed partial class LoggerRuntime : IDisposable
{
    public static readonly LoggerRuntime Global = new();

#if NET9_0_OR_GREATER
    private readonly Lock _locker = new();
#else
    private readonly object _locker = new();
#endif

    private CancellationTokenSource? _contextCancellation;

    internal LoggerContext LoggerContext = LoggerContext.Empty;

    public readonly LoggerFactory LoggerFactory;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public LoggerRuntime()
    {
        LoggerFactory = new LoggerFactory(this);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public LoggerContext GetLoggerContext()
    {
        return LoggerContext;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void Initialize(LoggerContextBuilder loggerBuilder, CancellationContext cancellationContext)
    {
        lock (_locker)
        {
            Dispose(cancellationContext);

            var contextCancellation = new CancellationTokenSource();

            _contextCancellation = contextCancellation;
            var context = loggerBuilder.Build(contextCancellation.Token);
            LoggerContext = context;

            var targetsLength = context.Targets.Length;

            // ReSharper disable once ConvertIfStatementToSwitchStatement
            if (targetsLength > 1)
            {
                var targetsSpan = new ReadOnlySpan<LoggerTarget>(context.Targets);

                for (var targetIndex = 0; targetIndex < targetsLength; targetIndex++)
                {
                    InitializeTarget(targetsSpan[targetIndex], cancellationContext);
                }
            }
            else if (targetsLength is 1)
            {
                InitializeTarget(context.Targets[0], cancellationContext);
            }
        }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void Dispose(CancellationContext cancellationContext)
    {
        lock (_locker)
        {
            var loggerContext = LoggerContext;

            var loggerCancellationToken = loggerContext.CancellationToken;

            if (loggerCancellationToken.IsCancellationRequested) return;

            if (cancellationContext.IsCancellationRequested)
            {
                DisposeAndCancelTokenSource();
            }

            _ = Task.Run(() =>
            {
                var spinWait = new SpinWait();

                while (cancellationContext.IsCancellationRequested is false && loggerCancellationToken.IsCancellationRequested is false)
                {
                    spinWait.SpinOnce();
                }

                if (cancellationContext.IsCancellationRequested && loggerCancellationToken.IsCancellationRequested is false)
                {
                    DisposeAndCancelTokenSource();
                }
            }, loggerCancellationToken);

            var targets = loggerContext.Targets;

            var targetsLength = targets.Length;

            // ReSharper disable once ConvertIfStatementToSwitchStatement
            if (targetsLength > 1)
            {
                var targetsSpan = new ReadOnlySpan<LoggerTarget>(targets);

                for (var targetIndex = 0; targetIndex < targetsLength; targetIndex++)
                {
                    // ReSharper disable once PossiblyMistakenUseOfCancellationToken
                    DisposeTarget(targetsSpan[targetIndex], cancellationContext);
                }
            }
            else if (targetsLength is 1)
            {
                // ReSharper disable once PossiblyMistakenUseOfCancellationToken
                DisposeTarget(targets[0], cancellationContext);
            }

            if (cancellationContext.IsCancellationRequested)
            {
                DisposeAndCancelTokenSource();
            }

            _contextCancellation = null;
            LoggerContext = LoggerContext.Empty;

            void DisposeAndCancelTokenSource()
            {
                var cancellationTokenSource = _contextCancellation!;

                try
                {
                    cancellationTokenSource.Cancel();
                }
                catch (Exception exception)
                {
                    DebugEventLogger.Handle("Error while cancelling logger context", exception);
                }

                try
                {
                    cancellationTokenSource.Dispose();
                }
                catch (Exception exception)
                {
                    DebugEventLogger.Handle("Error while disposing logger context", exception);
                }
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void InitializeTarget(LoggerTarget target, CancellationContext cancellationContext)
    {
        try
        {
            target.Initialize(cancellationContext);
        }
        catch (Exception exception)
        {
            DebugEventLogger.Handle("Error while initializing logger target", exception);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void DisposeTarget(LoggerTarget target, CancellationContext cancellationContext)
    {
        try
        {
            target.Dispose(cancellationContext);
        }
        catch (Exception exception)
        {
            DebugEventLogger.Handle("Error while disposing logger target", exception);
        }
    }
}
