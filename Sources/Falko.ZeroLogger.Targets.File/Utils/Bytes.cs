namespace Falko.Logging.Utils;

internal static class Bytes
{
	private const int Multiplier = 1024;

	public static int FromKilobytes(int kilobytes)
	{
		ArgumentOutOfRangeException.ThrowIfLessThan(kilobytes, 0, nameof(kilobytes));

		return kilobytes * Multiplier;
	}

	public static int FromMegabytes(int megabytes)
	{
		ArgumentOutOfRangeException.ThrowIfLessThan(megabytes, 0, nameof(megabytes));

		return megabytes * Multiplier * Multiplier;
	}
}
