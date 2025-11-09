using Falko.Logging.Builders;

namespace Falko.Logging.Utils;

internal static class TypeUtils
{
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string GetTypeName(Type type)
    {
        return ValueStringBuilder.Create(ValueStringBuilder.MaximumSafeStackBufferSize, type, GetTypeName);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void GetTypeName(ref ValueStringBuilder nameBuilder, Type type)
    {
        var name = type.FullName ?? type.Name;
        var nameLength = name.Length;

        if (type.IsGenericType is false)
        {
            nameBuilder.Ensure(nameLength);
            nameBuilder.Append(name);

            return;
        }

        var index = name.IndexOf('`');

        if (index <= 0)
        {
            nameBuilder.Ensure(nameLength);
            nameBuilder.Append(name);

            return;
        }

        scoped ReadOnlySpan<char> shortName = name.AsSpan(0, index);

        nameBuilder.Ensure(shortName.Length + 2);
        nameBuilder.Append(shortName);
        nameBuilder.Append('<');

        scoped ReadOnlySpan<Type> genericArguments = type.GetGenericArguments();

        for (var i = 0; i < genericArguments.Length; i++)
        {
            if (i > 0)
            {
                nameBuilder.Append(',');
                nameBuilder.Append(' ');
            }

            GetTypeName(ref nameBuilder, genericArguments[i]);
        }

        nameBuilder.Append('>');
    }
}
