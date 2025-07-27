using System.Logging.Builders;
using System.Logging.Contexts;
using System.Logging.Debugs;
using System.Logging.Factories;
using System.Logging.Targets;
using System.Runtime.CompilerServices;

namespace System.Logging.Runtimes;

public sealed partial class LoggerRuntime : IDisposable
{
    public static readonly LoggerRuntime Global = new();

#if NET9_0_OR_GREATER
    private readonly Lock _locker = new();
#else
    private readonly object _locker = new();
#endif

    private CancellationTokenSource? _contextCancellation;

    internal volatile LoggerContext LoggerContext = LoggerContext.Empty;

    public readonly LoggerFactory LoggerFactory;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public LoggerRuntime()
    {
        LoggerFactory = new LoggerFactory(this);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void Initialize(LoggerContextBuilder loggerBuilder, CancellationToken cancellationToken)
    {
        lock (_locker)
        {
            Dispose(cancellationToken);

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
                    InitializeTarget(targetsSpan[targetIndex], cancellationToken);
                }
            }
            else if (targetsLength is 1)
            {
                InitializeTarget(context.Targets[0], cancellationToken);
            }
        }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void Dispose(CancellationToken cancellationToken)
    {
        lock (_locker)
        {
            var loggerContext = LoggerContext;

            if (loggerContext.Cancellation.IsCancellationRequested) return;

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

            var targets = loggerContext.Targets;

            var targetsLength = targets.Length;

            // ReSharper disable once ConvertIfStatementToSwitchStatement
            if (targetsLength > 1)
            {
                var targetsSpan = new ReadOnlySpan<LoggerTarget>(targets);

                for (var targetIndex = 0; targetIndex < targetsLength; targetIndex++)
                {
                    // ReSharper disable once PossiblyMistakenUseOfCancellationToken
                    DisposeTarget(targetsSpan[targetIndex], cancellationToken);
                }
            }
            else if (targetsLength is 1)
            {
                // ReSharper disable once PossiblyMistakenUseOfCancellationToken
                DisposeTarget(targets[0], cancellationToken);
            }

            _contextCancellation = null;
            LoggerContext = LoggerContext.Empty;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void InitializeTarget(LoggerTarget target, CancellationToken cancellationToken)
    {
        try
        {
            target.Initialize(cancellationToken);
        }
        catch (Exception exception)
        {
            DebugEventLogger.Handle("Error while initializing logger target", exception);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void DisposeTarget(LoggerTarget target, CancellationToken cancellationToken)
    {
        try
        {
            target.Dispose(cancellationToken);
        }
        catch (Exception exception)
        {
            DebugEventLogger.Handle("Error while disposing logger target", exception);
        }
    }
}
