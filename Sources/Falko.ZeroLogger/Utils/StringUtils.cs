namespace Falko.Logging.Utils;

internal static class StringUtils
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string? ToString<T>(T value)
    {
        return value is IFormattable formattable
            ? formattable.ToString(null, null)
            : value?.ToString();
    }
}
