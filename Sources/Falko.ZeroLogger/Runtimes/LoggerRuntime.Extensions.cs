using Falko.Logging.Builders;
using Falko.Logging.Concurrents;

namespace Falko.Logging.Runtimes;

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
