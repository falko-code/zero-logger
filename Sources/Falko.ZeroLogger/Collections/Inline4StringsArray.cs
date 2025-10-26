namespace Falko.Logging.Collections;

[InlineArray(4)]
internal struct Inline4StringsArray : IInlineArray<string?>
{
    private string? _value;
}
