using System.Logging.Common;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System.Logging.Collections;

internal sealed class SingleConsumerQueue<T>
{
    private const int PrimaryIterationDelta = 0;

    private const int ItemIterationIncrement = 1;

    private readonly IterableItem[] _items;

    private readonly int _itemsCapacity;

    private readonly int _iterationIndexMask;

    private IterableNumber _writeNumber;

    private IterableNumber _readNumber;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public SingleConsumerQueue(int itemsCapacity)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(itemsCapacity);
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(itemsCapacity, Array.MaxLength);

        itemsCapacity = RoundItemsCapacity(itemsCapacity);

        _itemsCapacity = itemsCapacity;
        _iterationIndexMask = GetIterationIndexMask(itemsCapacity);

        _items = InitializeItems(itemsCapacity);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool Enqueue
    (
        T item,
        CancellationToken cancellationToken = default
    )
    {
        var queueFullSpin = new SpinWait();

        scoped ref var itemsReference = ref GetItemsReference();

        while (cancellationToken.IsCancellationRequested is false)
        {
            var writeNumberIteration = _writeNumber.Iteration();

            scoped ref var writeItem = ref GetIterationItem(ref itemsReference, writeNumberIteration);

            var writeItemIteration = writeItem.Iteration();
            var writeIterationDelta = writeItemIteration - writeNumberIteration;

            if (writeIterationDelta is PrimaryIterationDelta)
            {
                if (_writeNumber.TryIterate(writeNumberIteration) is false) continue;

                writeItem.Item = item;
                writeItem.Iterate(writeNumberIteration);

                return true;
            }

            if (writeIterationDelta < PrimaryIterationDelta) queueFullSpin.SpinOnce();
        }

        return false;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public bool Dequeue<TArgument>
    (
        TArgument argument,
        Action<TArgument, T> iteration,
        CancellationTimeout cancellationTimeout = default
    )
    {
        scoped ref var itemsReference = ref GetItemsReference();

        while (cancellationTimeout.IsExpired is false)
        {
            var readNumberIteration = _readNumber.Iterator;

            ref var readItem = ref GetIterationItem(ref itemsReference, readNumberIteration);

            var readItemIteration = readItem.Iteration();
            var readIterationDelta = readNumberIteration - readItemIteration + ItemIterationIncrement;

            if (readIterationDelta is not PrimaryIterationDelta) return true;

            _readNumber.Iterator = readNumberIteration + ItemIterationIncrement;

            var clearedReadItem = readItem.Clear();

            iteration(argument, clearedReadItem);

            readItem.Exchange(readNumberIteration + _itemsCapacity);
        }

        return false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private ref IterableItem GetItemsReference()
    {
        return ref MemoryMarshal.GetArrayDataReference(_items);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private ref IterableItem GetIterationItem(ref IterableItem itemsReference, int iteration)
    {
        return ref Unsafe.Add(ref itemsReference, GetIterationIndex(iteration));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private int GetIterationIndex(int currentIteration)
    {
        return currentIteration & _iterationIndexMask;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static IterableItem[] InitializeItems(int itemsCapacity)
    {
        var items = new IterableItem[itemsCapacity];

        scoped ref var itemsReference = ref MemoryMarshal.GetArrayDataReference(items);

        for (var itemIndex = 0; itemIndex < itemsCapacity; itemIndex++)
        {
            Unsafe.Add(ref itemsReference, itemIndex).Iterator = itemIndex;
        }

        return items;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int GetIterationIndexMask(int itemsCapacity)
    {
        return itemsCapacity - 1;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static int RoundItemsCapacity(int itemsCapacity)
    {
        if (itemsCapacity > 1 << 30)
        {
            throw new ArgumentOutOfRangeException
            (
                paramName: nameof(itemsCapacity),
                message: "Capacity is too large for power-of-two rounding."
            );
        }

        itemsCapacity--;
        itemsCapacity |= itemsCapacity >> 1;
        itemsCapacity |= itemsCapacity >> 2;
        itemsCapacity |= itemsCapacity >> 4;
        itemsCapacity |= itemsCapacity >> 8;
        itemsCapacity |= itemsCapacity >> 16;
        itemsCapacity++;

        return itemsCapacity;
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct IterableItem : IConcurrentIterator
    {
        // need this declared this field before '_iterator' for struct layout reasons
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
            .Write(ref Iterator, currentIterator + ItemIterationIncrement);

        public void Iterate(int currentIterator, int iterations) => Volatile
            .Write(ref Iterator, currentIterator + iterations);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool TryIterate(int currentIterator) => Interlocked
            .CompareExchange(ref Iterator, currentIterator + ItemIterationIncrement, currentIterator) == currentIterator;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Exchange(int nextIterator) => Volatile
            .Write(ref Iterator, nextIterator);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool TryExchange(int currentIterator, int nextIterator) => Interlocked
            .CompareExchange(ref Iterator, nextIterator, currentIterator) == currentIterator;
    }

    // There is an explicitly defined size to avoid false sharing
    [StructLayout(LayoutKind.Explicit, Size = 64)]
    private struct IterableNumber : IConcurrentIterator
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
            .Write(ref Iterator, currentIterator + ItemIterationIncrement);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool TryIterate(int currentIterator) => Interlocked
            .CompareExchange(ref Iterator, currentIterator + ItemIterationIncrement, currentIterator) == currentIterator;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Exchange(int nextIterator) => Volatile
            .Write(ref Iterator, nextIterator);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool TryExchange(int currentIterator, int nextIterator) => Interlocked
            .CompareExchange(ref Iterator, nextIterator, currentIterator) == currentIterator;
    }

    private interface IConcurrentIterator
    {
        int Iterator { get; set; }

        int Iteration();

        void Iterate(int currentIterator);

        bool TryIterate(int currentIterator);

        void Exchange(int nextIterator);

        bool TryExchange(int currentIterator, int nextIterator);
    }
}
