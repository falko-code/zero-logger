using System.Buffers;

namespace Falko.Logging.Builders;

public ref struct ValueStringStream : IStringStream, IDisposable
{
    public const int MaximumSafeStackBufferSize = 256;

    private char[]? _buffer;

    private SpanStringStream _stream;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ValueStringStream(Span<char> span)
    {
        _stream = span;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ValueStringStream(int capacity)
    {
        _buffer = ArrayPool<char>.Shared.Rent(capacity);
        _stream = _buffer;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void Ensure(int length)
    {
        var newLength = length + _stream.Position;

        if (newLength <= _stream.Length) return;

        var newArray = ArrayPool<char>.Shared.Rent(newLength);
        var newSpan = newArray.AsSpan();

        _stream.AsReadOnlySpan().CopyTo(newSpan);

        if (_buffer is not null)
        {
            ArrayPool<char>.Shared.Return(_buffer);
        }

        _buffer = newArray;
        _stream = newSpan;
    }

    public int Position
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => _stream.Position;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => _stream.Position = value;
    }

    public int Length
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => _stream.Length;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Write<T>(T value)
#if NET9_0_OR_GREATER
        where T : ISpanFormattable, allows ref struct
#else
        where T : ISpanFormattable
#endif
    {
        _stream.Write(value);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Write<T>(T value, int repeat)
#if NET9_0_OR_GREATER
        where T : ISpanFormattable, allows ref struct
#else
        where T : ISpanFormattable
#endif
    {
        _stream.Write(value, repeat);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Write(scoped ReadOnlySpan<char> symbols)
    {
        _stream.Write(symbols);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Write(string symbols)
    {
        _stream.Write(symbols);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Write(char symbol, int repeat)
    {
        _stream.Write(symbol, repeat);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Write(char symbol)
    {
        _stream.Write(symbol);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Write<T>(int length, in T state, SpanStringStreamAction<T> action)
#if NET9_0_OR_GREATER
        where T : allows ref struct
#endif
    {
        _stream.Write(length, in state, action);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ReadOnlySpan<char> AsReadOnlySpan() => _stream.AsReadOnlySpan();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString() => _stream.ToString();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Dispose()
    {
        if (_buffer is null) return;

        ArrayPool<char>.Shared.Return(_buffer);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string Create<T>(int capacity, T argument, ValueStringStreamAction<T> build)
#if NET9_0_OR_GREATER
        where T : allows ref struct
#endif
    {
        scoped var builder = capacity > MaximumSafeStackBufferSize
            ? new ValueStringStream(capacity)
            : new ValueStringStream(stackalloc char[MaximumSafeStackBufferSize]);

        try
        {
            build(ref builder, argument);
            return builder.ToString();
        }
        finally
        {
            builder.Dispose();
        }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string Create<T>(T argument, ValueStringStreamAction<T> build)
#if NET9_0_OR_GREATER
        where T : allows ref struct
#endif
    {
        scoped var builder = new ValueStringStream(stackalloc char[MaximumSafeStackBufferSize]);

        try
        {
            build(ref builder, argument);
            return builder.ToString();
        }
        finally
        {
            builder.Dispose();
        }
    }
}
