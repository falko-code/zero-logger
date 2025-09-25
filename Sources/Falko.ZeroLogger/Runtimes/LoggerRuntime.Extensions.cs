using System.Logging.Builders;
using System.Logging.Concurrents;

namespace System.Logging.Runtimes;

public sealed partial class LoggerRuntime
{
    #region Initialize

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Initialize(LoggerContextBuilder loggerBuilder)
    {
        Initialize(loggerBuilder, CancellationContext.None);
    }

    #endregion

    #region Dispose

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Dispose()
    {
        Dispose(CancellationContext.None);
    }

    #endregion
}
