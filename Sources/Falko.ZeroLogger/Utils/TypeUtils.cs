using Falko.Logging.Builders;

namespace Falko.Logging.Utils;

internal static class TypeUtils
{
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string GetTypeName(Type type)
    {
        var nameBuilder = new ValueStringBuilder(stackalloc char[128]);

        try
        {
            GetTypeName(type, ref nameBuilder);
            return nameBuilder.ToString();
        }
        finally
        {
            nameBuilder.Dispose();
        }
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void GetTypeName(Type type, ref ValueStringBuilder nameBuilder)
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

            GetTypeName(genericArguments[i], ref nameBuilder);
        }

        nameBuilder.Append('>');
    }
}
