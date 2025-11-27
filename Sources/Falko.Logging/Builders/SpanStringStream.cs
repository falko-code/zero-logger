namespace Falko.Logging.Builders;

[method: MethodImpl(MethodImplOptions.AggressiveInlining)]
public ref struct SpanStringStream(Span<char> buffer) : IStringStream
{
    private Span<char> _buffer = buffer;

    private int _position;

    public int Position
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => _position;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            ArgumentOutOfRangeException.ThrowIfNegative(value);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(value, _buffer.Length);

            _position = value;
        }
    }

    public int Length
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => _buffer.Length;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Write<T>(T value)
#if NET9_0_OR_GREATER
        where T : ISpanFormattable, allows ref struct
#else
        where T : ISpanFormattable
#endif
    {
        scoped ref var positionRef = ref _position;
        var position = positionRef;

        scoped ref var bufferRef = ref _buffer;

        var bufferSlice = bufferRef.Slice(position, bufferRef.Length - position);

        if (value.TryFormat(bufferSlice, out var count, format: default, provider: null) is false)
        {
            throw new InvalidOperationException($"The type '{typeof(T)}' could not be formatted to the string stream.");
        }

        positionRef = position + count;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void Write<T>(T value, int repeat)
#if NET9_0_OR_GREATER
        where T : ISpanFormattable, allows ref struct
#else
        where T : ISpanFormattable
#endif
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(repeat);

        if (repeat is 1)
        {
            Write(value);
            return;
        }

        scoped ref var positionRef = ref _position;
        var position = positionRef;

        scoped ref var bufferRef = ref _buffer;

        var bufferSlice = bufferRef.Slice(position, bufferRef.Length - position);

        if (value.TryFormat(bufferSlice, out var count, format: default, provider: null) is false)
        {
            throw new InvalidOperationException($"The type '{typeof(T)}' could not be formatted to the string stream.");
        }

        var symbols = bufferRef.Slice(position, count);
        scoped ref var symbolsRef = ref symbols;
        position += count;

        for (var i = 1; i < repeat; i++)
        {
            symbolsRef.CopyTo(bufferRef.Slice(position, count));
            position += count;
        }

        positionRef = position;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Write(scoped ReadOnlySpan<char> symbols)
    {
        var position = _position;
        ref var symbolsRef = ref symbols;
        var symbolsLength = symbolsRef.Length;
        symbolsRef.CopyTo(_buffer.Slice(position, symbolsLength));
        _position = position + symbolsLength;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Write(string symbols)
    {
        scoped ref var positionRef = ref _position;
        var position = positionRef;
        scoped ref var symbolsRef = ref symbols;
        var symbolsLength = symbolsRef.Length;
        symbolsRef.CopyTo(_buffer.Slice(position, symbolsLength));
        positionRef = position + symbolsLength;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Write(char symbol, int repeat)
    {
        scoped ref var positionRef = ref _position;
        var position = positionRef;
        _buffer.Slice(position, repeat).Fill(symbol);
        positionRef = position + repeat;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Write(char symbol)
    {
        scoped ref var positionRef = ref _position;
        var position = positionRef;
        _buffer[position] = symbol;
        positionRef = position + 1;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Write<T>(int length, in T state, SpanStringStreamAction<T> action)
#if NET9_0_OR_GREATER
        where T : allows ref struct
#endif
    {
        scoped ref var positionRef = ref _position;
        var position = positionRef;
        scoped var bufferSlice = _buffer.Slice(position, length);
        scoped var bufferStream = new SpanStringStream(bufferSlice);
        action(ref bufferStream, in state);
        positionRef = position + length;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Span<char> GetBuffer() => _buffer;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly ReadOnlySpan<char> AsReadOnlySpan() => _buffer[.._position];

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString() => new(_buffer[.._position]);

    public static implicit operator SpanStringStream(Span<char> span) => new(span);
}
