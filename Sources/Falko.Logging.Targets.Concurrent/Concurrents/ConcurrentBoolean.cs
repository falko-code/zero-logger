namespace Falko.Logging.Concurrents;

internal struct ConcurrentBoolean
{
    private const int TrueValue = 1;

    private const int FalseValue = 0;

    private int _value;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool IsTrue() => Volatile.Read(ref _value) == TrueValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool IsFalse() => Volatile.Read(ref _value) == FalseValue;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TrySetTrue()
    {
        var currentValue = Volatile.Read(ref _value);

        if (currentValue == TrueValue) return false;

        return Interlocked.CompareExchange(ref _value, TrueValue, currentValue) == FalseValue;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool TrySetFalse()
    {
        var currentValue = Volatile.Read(ref _value);

        if (currentValue == FalseValue) return false;

        return Interlocked.CompareExchange(ref _value, FalseValue, currentValue) == TrueValue;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WaitTrue()
    {
        if (IsTrue()) return;

        var waiter = new SpinWait();

        do waiter.SpinOnce();
        while (IsFalse());
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WaitFalse()
    {
        if (IsFalse()) return;

        var waiter = new SpinWait();

        do waiter.SpinOnce();
        while (IsTrue());
    }
}
