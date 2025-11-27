using System.Runtime.InteropServices;
using Falko.Logging.Concurrents;

namespace Falko.Logging.Collections;

internal sealed class SingleConsumerQueue<T>
{
    private const int PrimaryIterationDelta = 0;

    private readonly ConcurrentItemIterator<T>[] _items;

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

    public bool IsEmpty
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => _writeNumber.Iteration() == _readNumber.Iteration();
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

        ItemEnqueuing:

        var writeNumberIteration = _writeNumber.Iteration();

        scoped ref var writeItem = ref GetIterationItem(ref itemsReference, writeNumberIteration);

        var writeItemIteration = writeItem.Iteration();
        var writeIterationDelta = writeItemIteration - writeNumberIteration;

        if (writeIterationDelta is PrimaryIterationDelta)
        {
            if (_writeNumber.TryIterate(writeNumberIteration) is false) goto ItemEnqueuing;

            writeItem.Item = item;
            writeItem.Iterate(writeNumberIteration);

            return true;
        }

        if (cancellationToken.IsCancellationRequested || writeIterationDelta >= PrimaryIterationDelta) return false;

        queueFullSpin.SpinOnce();

        goto ItemEnqueuing;
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

        ItemDequeuing:

        var readNumberIteration = _readNumber.Iteration();

        scoped ref var readItem = ref GetIterationItem(ref itemsReference, readNumberIteration);

        var readItemIteration = readItem.Iteration();
        var readIterationDelta = readNumberIteration - readItemIteration + 1;

        if (readIterationDelta is not PrimaryIterationDelta) return true;

        _readNumber.Iterate(readNumberIteration);

        var clearedReadItem = readItem.Clear();

        iteration(argument, clearedReadItem);

        readItem.Exchange(readNumberIteration + _itemsCapacity);

        if (cancellationTimeout.IsCancellationRequested) return false;

        goto ItemDequeuing;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private ref ConcurrentItemIterator<T> GetItemsReference()
    {
        return ref MemoryMarshal.GetArrayDataReference(_items);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private ref ConcurrentItemIterator<T> GetIterationItem(ref ConcurrentItemIterator<T> itemsReference, int iteration)
    {
        return ref Unsafe.Add(ref itemsReference, GetIterationIndex(iteration));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private int GetIterationIndex(int currentIteration)
    {
        return currentIteration & _iterationIndexMask;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static ConcurrentItemIterator<T>[] InitializeItems(int itemsCapacity)
    {
        var items = new ConcurrentItemIterator<T>[itemsCapacity];

        scoped ref var itemsReference = ref MemoryMarshal.GetArrayDataReference(items);

        for (var itemIndex = 0; itemIndex < itemsCapacity; itemIndex++)
        {
            Unsafe.Add(ref itemsReference, itemIndex).Exchange(itemIndex);
        }

        return items;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int GetIterationIndexMask(int itemsCapacity)
    {
        return itemsCapacity - 1;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
