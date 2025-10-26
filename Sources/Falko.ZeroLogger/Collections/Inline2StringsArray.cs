namespace Falko.Logging.Collections;

[InlineArray(2)]
internal struct Inline2StringsArray : IInlineArray<string?>
{
    private string? _value;
}
