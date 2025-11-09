using System.Buffers;

namespace Falko.Logging.Builders;

internal interface IStringStream
{
    int Position { get; set; }

    int Length { get; }

    void Next<T>(T value)
#if NET9_0_OR_GREATER
        where T : ISpanFormattable, allows ref struct;
#else
        where T : ISpanFormattable;
#endif

    void Next<T>(T value, int repeat)
#if NET9_0_OR_GREATER
        where T : ISpanFormattable, allows ref struct;
#else
        where T : ISpanFormattable;
#endif

    void Next(scoped ReadOnlySpan<char> symbols);

    void Next(string symbols);

    void Next(char symbol, int repeat);

    void Next(char symbol);

    void Next<T>(int length, in T state, StringStreamAction<T> action)
#if NET9_0_OR_GREATER
        where T : allows ref struct;
#else
        ;
#endif

    ReadOnlySpan<char> AsReadOnlySpan();

    string ToString();
}
