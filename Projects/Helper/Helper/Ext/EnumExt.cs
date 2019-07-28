using System;

namespace ProceduralLevel.Common.Helper
{
	public static class EnumExt<EnumType>
    {
		public readonly static EnumType[] Values = (EnumType[])Enum.GetValues(typeof(EnumType));

		public static void ValueRange(out int minValue, out int maxValue)
		{
			EnumType[] values = (EnumType[])Enum.GetValues(typeof(EnumType));
			maxValue = int.MinValue;
			minValue = int.MaxValue;
			for(int x = 0; x < values.Length; x++)
			{
				EnumType value = values[x];
				int eValue = value.GetHashCode();
				maxValue = Math.Max(eValue, maxValue);
				minValue = Math.Min(eValue, minValue);
			}
		}

		public static int MinValue()
		{
			ValueRange(out int minValue, out int maxValue);
			return minValue;
		}

		public static int MaxValue()
		{
			ValueRange(out int minValue, out int maxValue);
			return maxValue;
		}
	}
}
