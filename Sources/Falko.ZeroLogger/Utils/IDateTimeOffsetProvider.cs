using System.Runtime.CompilerServices;

namespace System.Logging.Utils;

internal interface IDateTimeOffsetProvider
{
    DateTimeOffset Now { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; }
}
