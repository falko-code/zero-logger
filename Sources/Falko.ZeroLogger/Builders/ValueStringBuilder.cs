using System.Buffers;

namespace Falko.Logging.Builders;

public ref struct ValueStringBuilder : IDisposable
{
    public const int MaximumSafeStackBufferSize = 256;

    private char[]? _buffer;

    private ValueStringStream _stream;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ValueStringBuilder(Span<char> span)
    {
        _stream = span;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ValueStringBuilder(int capacity)
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

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Append(scoped ReadOnlySpan<char> chars)
    {
        _stream.Next(chars);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Append(string chars)
    {
        _stream.Next(chars);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Append(char @char, int repeat)
    {
        _stream.Next(@char, repeat);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Append(char @char)
    {
        _stream.Next(@char);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Append<T>(int length, T state, SpanAction<char, T> fill)
    {
        _stream.Next(length, state, fill);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString()
    {
        return _stream.ToString();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Dispose()
    {
        if (_buffer is null) return;

        ArrayPool<char>.Shared.Return(_buffer);
    }

    public static string Create<T>(int capacity, T argument, ValueStringBuilderAction<T> build)
#if NET9_0_OR_GREATER
        where T : allows ref struct
#endif
    {
        scoped var builder = capacity > MaximumSafeStackBufferSize
            ? new ValueStringBuilder(capacity)
            : new ValueStringBuilder(stackalloc char[MaximumSafeStackBufferSize]);

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
