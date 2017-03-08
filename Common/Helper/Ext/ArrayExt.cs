﻿namespace ProceduralLevel.Common.Helper
{
	public static class ArrayExt
    {
		public static ArrayType[] Resize<ArrayType>(this ArrayType[] arr, int newSize)
		{
			ArrayType[] newArr = new ArrayType[newSize];
			int maxSize = (newSize > arr.Length? arr.Length: newSize);
			for(int x = 0; x < maxSize; x++)
			{
				newArr[x] = arr[x];
			}

			return newArr;
		}
    }
}