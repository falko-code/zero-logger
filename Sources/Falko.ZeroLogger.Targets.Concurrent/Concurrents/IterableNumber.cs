using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System.Logging.Concurrents;

// there is an explicitly defined size to avoid false sharing
[StructLayout(LayoutKind.Explicit, Size = 64)]
internal struct IterableNumber : IConcurrentIterator
{
    [FieldOffset(0)]
    private int _iterator;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int Iteration() => Volatile
        .Read(ref _iterator);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Iterate(int currentIterator) => Volatile
        .Write(ref _iterator, currentIterator + IConcurrentIterator.ItemIterationIncrement);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TryIterate(int currentIterator) => Interlocked
        .CompareExchange(ref _iterator, currentIterator + IConcurrentIterator.ItemIterationIncrement, currentIterator) == currentIterator;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Exchange(int nextIterator) => Volatile
        .Write(ref _iterator, nextIterator);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TryExchange(int currentIterator, int nextIterator) => Interlocked
        .CompareExchange(ref _iterator, nextIterator, currentIterator) == currentIterator;
}
