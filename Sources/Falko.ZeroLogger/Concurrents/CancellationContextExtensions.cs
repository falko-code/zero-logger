namespace System.Logging.Concurrents;

public static partial class CancellationContextExtensions
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static CancellationContext ToCancellationContext(this CancellationToken cancellationToken)
    {
        return new CancellationContext(cancellationToken);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static CancellationContext ToCancellationContext(this CancellationTimeout cancellationTimeout)
    {
        return new CancellationContext(cancellationTimeout);
    }
}
