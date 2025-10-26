namespace Falko.Logging.Collections;

internal static class InlineArrayMarshal
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ref TValue GetArrayDataReference<TType, TValue>(ref TType inlineArray)
        where TType : struct, IInlineArray<TValue>
    {
        return ref Unsafe.As<TType, TValue>(ref inlineArray);
    }
}
