using System.Logging.Common;
using System.Logging.Iterables;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System.Logging.Collections;

internal sealed class SingleConsumerQueue<T>
{
    private const int PrimaryIterationDelta = 0;

    private readonly IterableItem<T>[] _items;

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

    public int Capacity
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => _itemsCapacity;
    }

    public int Count
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => _writeNumber.Iteration() - _readNumber.Iterator;
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
            var readIterationDelta = readNumberIteration - readItemIteration + IConcurrentIterator.ItemIterationIncrement;

            if (readIterationDelta is not PrimaryIterationDelta) return true;

            _readNumber.Iterator = readNumberIteration + IConcurrentIterator.ItemIterationIncrement;

            var clearedReadItem = readItem.Clear();

            iteration(argument, clearedReadItem);

            readItem.Exchange(readNumberIteration + _itemsCapacity);
        }

        return false;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private ref IterableItem<T> GetItemsReference()
    {
        return ref MemoryMarshal.GetArrayDataReference(_items);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private ref IterableItem<T> GetIterationItem(ref IterableItem<T> itemsReference, int iteration)
    {
        return ref Unsafe.Add(ref itemsReference, GetIterationIndex(iteration));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private int GetIterationIndex(int currentIteration)
    {
        return currentIteration & _iterationIndexMask;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static IterableItem<T>[] InitializeItems(int itemsCapacity)
    {
        var items = new IterableItem<T>[itemsCapacity];

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
}
