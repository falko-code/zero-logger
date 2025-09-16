using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System.Logging.Concurrents;

[StructLayout(LayoutKind.Sequential)]
internal struct ConcurrentItemIterator<T> : IConcurrentIterator
{
    // need this declared this field before 'Iterator' for struct layout reasons
    public T Item;

    private int _iterator;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public T Clear()
    {
        var item = Item;

        Item = default!;

        return item;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int Iteration() => Volatile
        .Read(ref _iterator);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Iterate(int currentIterator) => Volatile
        .Write(ref _iterator, currentIterator + IConcurrentIterator.ItemIterationIncrement);

    public void Iterate(int currentIterator, int iterations) => Volatile
        .Write(ref _iterator, currentIterator + iterations);

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
