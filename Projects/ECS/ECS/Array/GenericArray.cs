using System;

namespace ProceduralLevel.Common.ECS
{
	public class GenericArray<TData>
	{
		public int Count;
		public TData[] Data;

		public void Add(TData component)
		{
			Data[Count++] = component;
		}

		public void Remove(int index)
		{
			int lastIndex = --Count;
			Data[index] = Data[lastIndex];
			Data[lastIndex] = default(TData);
		}

		public void Clear(int index)
		{
			Data[index] = default(TData);
		}

		public void Resize(int newSize)
		{
			int oldSize = (Data != null? Data.Length: 0);
			if(newSize != oldSize)
			{
				TData[] oldData = Data;
				Data = new TData[newSize];
				int maxSize = Math.Min(oldSize, newSize);
				for(int x = 0; x < maxSize; ++x)
				{
					Data[x] = oldData[x];
				}
			}
		}

		public override string ToString()
		{
			return string.Format("[{0}<{1}>][Count: {2}]", GetType().Name, typeof(TData).Name, Count);
		}
	}
}
