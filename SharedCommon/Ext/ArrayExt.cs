namespace ProceduralLevel.Common.Ext
{
	public static class ArrayExt
    {
		public static ArrayType[] Resize<ArrayType>(this ArrayType[] arr, int newSize)
		{
			if(arr.Length == newSize)
			{
				return arr;
			}

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
