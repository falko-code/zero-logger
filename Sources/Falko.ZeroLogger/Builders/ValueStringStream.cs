using System.Buffers;

namespace Falko.Logging.Builders;

[method: MethodImpl(MethodImplOptions.AggressiveInlining)]
public ref struct ValueStringStream(Span<char> buffer)
{
    private Span<char> _buffer = buffer;

    private int _position;
    public int Position
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => _position;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set => _position = value;
    }

    public int Length
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => _buffer.Length;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Next(scoped ReadOnlySpan<char> chars)
    {
        var length = chars.Length;

        if (length is 0) return;

        chars.CopyTo(_buffer[_position..]);
        _position += length;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Next(string chars)
    {
        var length = chars.Length;

        if (length is 0) return;

        chars.CopyTo(_buffer[_position..]);
        _position += length;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Next(char @char, int repeat)
    {
        _buffer.Slice(_position, repeat).Fill(@char);
        _position += repeat;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Next(char @char)
    {
        _buffer[_position] = @char;
        ++_position;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Next<T>(int length, T state, SpanAction<char, T> fill)
    {
        fill(_buffer.Slice(_position, length), state);

        _position += length;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public override string ToString() => new(_buffer[.._position]);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public readonly ReadOnlySpan<char> AsReadOnlySpan() => _buffer[.._position];

    public static implicit operator string(ValueStringStream stream) => stream.ToString();

    public static implicit operator ReadOnlySpan<char>(ValueStringStream stream) => stream.AsReadOnlySpan();

    public static implicit operator ValueStringStream(Span<char> span) => new(span);
}
