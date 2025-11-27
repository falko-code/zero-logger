using Falko.Logging.Builders;

namespace Falko.Logging.Utils;

internal static class TypeUtils
{
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static string GetTypeName(Type type)
    {
        return ValueStringStream.Create(ValueStringStream.MaximumSafeStackBufferSize, type, GetTypeName);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void GetTypeName(scoped ref ValueStringStream nameStream, in Type type)
    {
        var name = type.FullName ?? type.Name;
        var nameLength = name.Length;

        if (type.IsGenericType is false)
        {
            nameStream.Ensure(nameLength);
            nameStream.Write(name);

            return;
        }

        var index = name.IndexOf('`');

        if (index <= 0)
        {
            nameStream.Ensure(nameLength);
            nameStream.Write(name);

            return;
        }

        scoped ReadOnlySpan<char> shortName = name.AsSpan(0, index);

        nameStream.Ensure(shortName.Length + 2);
        nameStream.Write(shortName);
        nameStream.Write('<');

        scoped ReadOnlySpan<Type> genericArguments = type.GetGenericArguments();

        for (var i = 0; i < genericArguments.Length; i++)
        {
            if (i > 0)
            {
                nameStream.Write(',');
                nameStream.Write(' ');
            }

            GetTypeName(ref nameStream, genericArguments[i]);
        }

        nameStream.Write('>');
    }
}
