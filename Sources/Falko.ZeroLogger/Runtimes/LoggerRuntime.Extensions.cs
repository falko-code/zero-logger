using System.Logging.Builders;

namespace System.Logging.Runtimes;

public sealed partial class LoggerRuntime
{
    private static TimeSpan DefaultTimeout => TimeSpan.FromSeconds(30);

    #region Initialize

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Initialize(LoggerContextBuilder loggerBuilder)
    {
        Initialize(loggerBuilder, CancellationToken.None);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Initialize(LoggerContextBuilder loggerBuilder, TimeSpan timeout)
    {
        using var source = CreateTimeoutCancellationSource(timeout);

        Initialize(loggerBuilder, source.Token);
    }

    #endregion

    #region Dispose

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Dispose()
    {
        using var source = CreateTimeoutCancellationSource();

        Dispose(source.Token);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Dispose(TimeSpan timeout)
    {
        using var source = CreateTimeoutCancellationSource(timeout);

        Dispose(source.Token);
    }

    #endregion

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static CancellationTokenSource CreateTimeoutCancellationSource()
    {
        return CreateTimeoutCancellationSource(DefaultTimeout);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static CancellationTokenSource CreateTimeoutCancellationSource(TimeSpan timeout)
    {
        var source = new CancellationTokenSource();

        source.CancelAfter(timeout);

        return source;
    }
}
