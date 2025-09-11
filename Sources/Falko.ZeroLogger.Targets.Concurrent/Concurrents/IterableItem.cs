using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System.Logging.Concurrents;

[StructLayout(LayoutKind.Sequential)]
internal struct IterableItem<T> : IConcurrentIterator
{
    // need this declared this field before 'Iterator' for struct layout reasons
    public T Item;

    public int Iterator;

    int IConcurrentIterator.Iterator
    {
        get => Iterator;
        set => Iterator = value;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T Clear()
    {
        var item = Item;

        Item = default!;

        return item;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int Iteration() => Volatile
        .Read(ref Iterator);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Iterate(int currentIterator) => Volatile
        .Write(ref Iterator, currentIterator + IConcurrentIterator.ItemIterationIncrement);

    public void Iterate(int currentIterator, int iterations) => Volatile
        .Write(ref Iterator, currentIterator + iterations);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TryIterate(int currentIterator) => Interlocked
        .CompareExchange(ref Iterator, currentIterator + IConcurrentIterator.ItemIterationIncrement, currentIterator) == currentIterator;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Exchange(int nextIterator) => Volatile
        .Write(ref Iterator, nextIterator);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TryExchange(int currentIterator, int nextIterator) => Interlocked
        .CompareExchange(ref Iterator, nextIterator, currentIterator) == currentIterator;
}
