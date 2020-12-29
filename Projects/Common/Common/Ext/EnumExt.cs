using System;

namespace ProceduralLevel.Common.Ext
{
	public class EnumExt<TEnum>
		where TEnum : Enum
	{
		public readonly TEnum[] Values = (TEnum[])Enum.GetValues(typeof(TEnum));
		public readonly int MinValue;
		public readonly int MaxValue;

		public EnumExt()
		{
			MinValue = GetMinValue();
			MaxValue = GetMaxValue();
		}

		private int GetMinValue()
		{
			TEnum[] values = Values;
			int length = values.Length;

			if(length == 0)
			{
				return 0;
			}

			int value = int.MaxValue;
			for(int x = 0; x < length; ++x)
			{
				value = Math.Min(values[x].GetHashCode(), value);
			}
			return value;
		}

		private int GetMaxValue()
		{
			TEnum[] values = Values;
			int length = values.Length;

			if(length == 0)
			{
				return 0;
			}

			int value = int.MinValue;
			for(int x = 0; x < length; ++x)
			{
				value = Math.Max(values[x].GetHashCode(), value);
			}
			return value;
		}
	}
}
