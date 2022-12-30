using System;
using ProceduralLevel.Common.Grid;

namespace ProceduralLevel.Common.Ext
{
	public static class ArrayExt
	{
		public static TData[][] Create<TData>(GridSize2D size)
		{
			return Create<TData>(size.X, size.Y);
		}

		public static TData[][] Create<TData>(int width, int height)
		{
			TData[][] array = new TData[width][];
			for(int x = 0; x < array.Length; ++x)
			{
				array[x] = new TData[height];
			}
			return array;
		}

		public static TData[][][] Create<TData>(GridSize3D size)
		{
			return Create<TData>(size.X, size.Y, size.Z);
		}

		public static TData[][][] Create<TData>(int width, int height, int depth)
		{
			TData[][][] array = new TData[width][][];
			for(int x = 0; x < array.Length; ++x)
			{
				TData[][] column = new TData[height][];
				array[x] = column;
				for(int y = 0; y < column.Length; ++y)
				{
					column[y] = new TData[depth];
				}
			}
			return array;
		}

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
