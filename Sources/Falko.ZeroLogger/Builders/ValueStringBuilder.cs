using System.Buffers;
using System.Runtime.CompilerServices;

namespace System.Logging.Builders;

public ref struct ValueStringBuilder : IDisposable
{
    public const int MaximumSafeStackBufferSize = 256;

    private char[]? _array;

    private Span<char> _span;

    private int _position;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ValueStringBuilder(Span<char> span)
    {
        _span = span;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ValueStringBuilder(int capacity)
    {
        _array = ArrayPool<char>.Shared.Rent(capacity);
        _span = _array.AsSpan();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public void Ensure(int length)
    {
        var newLength = length + _position;

        if (newLength <= _span.Length) return;

        var newArray = ArrayPool<char>.Shared.Rent(newLength);
        var newSpan = newArray.AsSpan();

        _span[.._position].CopyTo(newSpan);

        if (_array is not null)
        {
            ArrayPool<char>.Shared.Return(_array);
        }

        _array = newArray;
        _span = newSpan;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Append(scoped ReadOnlySpan<char> symbols)
    {
        var length = symbols.Length;

        if (length is 0) return;

        symbols.CopyTo(_span[_position..]);
        _position += length;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Append(string symbols)
    {
        var length = symbols.Length;

        if (length is 0) return;

        symbols.CopyTo(_span[_position..]);
        _position += length;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Append(char symbol, int repeat)
    {
        _span.Slice(_position, repeat).Fill(symbol);
        _position += repeat;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Append(char symbol)
    {
        _span[_position] = symbol;
        ++_position;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString()
    {
        return string.Create(_position, _span[.._position], static (span, chars) => chars.CopyTo(span));
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Dispose()
    {
        if (_array is null) return;

        ArrayPool<char>.Shared.Return(_array);
    }
}
