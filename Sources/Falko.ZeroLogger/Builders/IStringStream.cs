namespace Falko.Logging.Builders;

internal interface IStringStream
{
    int Position { get; set; }

    int Length { get; }

    void Write<T>(T value)
#if NET9_0_OR_GREATER
        where T : ISpanFormattable, allows ref struct;
#else
        where T : ISpanFormattable;
#endif

    void Write<T>(T value, int repeat)
#if NET9_0_OR_GREATER
        where T : ISpanFormattable, allows ref struct;
#else
        where T : ISpanFormattable;
#endif

    void Write(scoped ReadOnlySpan<char> symbols);

    void Write(string symbols);

    void Write(char symbol, int repeat);

    void Write(char symbol);

    void Write<T>(int length, in T state, SpanStringStreamAction<T> action)
#if NET9_0_OR_GREATER
        where T : allows ref struct;
#else
        ;
#endif

    ReadOnlySpan<char> AsReadOnlySpan();

    string ToString();
}
