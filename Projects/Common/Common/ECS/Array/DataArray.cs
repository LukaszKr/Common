using System;

namespace ProceduralLevel.ECS
{
	public class DataArray<DataType>
	{
		public int Count;
		public DataType[] Data;

		public void Add(DataType component)
		{
			Data[Count++] = component;
		}

		public void Remove(int index)
		{
			int lastIndex = --Count;
			Data[index] = Data[lastIndex];
			Data[lastIndex] = default(DataType);
		}

		public void Clear(int index)
		{
			Data[index] = default(DataType);
		}

		public void Resize(int newSize)
		{
			int oldSize = (Data != null? Data.Length: 0);
			if(newSize != oldSize)
			{
				DataType[] oldData = Data;
				Data = new DataType[newSize];
				int maxSize = Math.Min(oldSize, newSize);
				for(int x = 0; x < maxSize; ++x)
				{
					Data[x] = oldData[x];
				}
			}
		}

		public override string ToString()
		{
			return string.Format("[{0}][Count: {1}]", GetType().Name, Count);
		}
	}
}
