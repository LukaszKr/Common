using System;

namespace ProceduralLevel.Common.Ext
{
	public static class ArrayExt
	{
		public static TData[] Resize<TData>(this TData[] array, int length)
		{
			if(array == null)
			{
				return new TData[length];
			}
			int oldLength = array.Length;
			int iter = Math.Min(length, oldLength);
			TData[] newArray = new TData[length];
			for(int x = 0; x < iter; ++x)
			{
				newArray[x] = array[x];
			}
			return newArray;
		}

		public static TData[] FitInto<TData>(this TData[] array, TData[] target, int length)
		{
			if(target == null || target.Length != length)
			{
				target = new TData[length];
			}
			for(int x = 0; x < length; ++x)
			{
				target[x] = array[x];
			}
			return target;
		}

		public static TData[] Trim<TData>(this TData[] array, int length)
		{
			if(array.Length != length)
			{
				TData[] result = new TData[length];
				for(int x = 0; x < length; ++x)
				{
					result[x] = array[x];
				}
				return result;
			}
			return array;
		}
	}
}
