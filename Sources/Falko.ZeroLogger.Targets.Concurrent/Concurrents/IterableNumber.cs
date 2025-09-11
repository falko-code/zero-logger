using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System.Logging.Concurrents;

// there is an explicitly defined size to avoid false sharing
[StructLayout(LayoutKind.Explicit, Size = 64)]
internal struct IterableNumber : IConcurrentIterator
{
    [FieldOffset(0)]
    public int Iterator;

    int IConcurrentIterator.Iterator
    {
        get => Iterator;
        set => Iterator = value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int Iteration() => Volatile
        .Read(ref Iterator);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Iterate(int currentIterator) => Volatile
        .Write(ref Iterator, currentIterator + 1);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TryIterate(int currentIterator) => Interlocked
        .CompareExchange(ref Iterator, currentIterator + 1, currentIterator) == currentIterator;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Exchange(int nextIterator) => Volatile
        .Write(ref Iterator, nextIterator);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TryExchange(int currentIterator, int nextIterator) => Interlocked
        .CompareExchange(ref Iterator, nextIterator, currentIterator) == currentIterator;
}
