using System;
using System.Collections.Generic;

namespace ProceduralLevel.Common.Serialization
{
	public abstract partial class AArray
	{
		protected int m_Index = 0;

		public abstract int Count { get; }

		public virtual void Clear()
		{
			m_Index = 0;
		}

		public void Seek(int index)
		{
			if(index < 0 || index >= Count)
			{
				throw new ArgumentOutOfRangeException();
			}
			m_Index = index;
		}

		public abstract AObject WriteObject();
		public abstract AArray WriteArray();
		public abstract AObject ReadObject();
		public abstract AArray ReadArray();
		public abstract AObject ReadObject(int index);
		public abstract AArray ReadArray(int index);

		public void Write(IObjectSerializable data)
		{
			AObject obj = WriteObject();
			data.Serialize(obj);
		}

		public void Write(IArraySerializable data)
		{
			AArray arr = WriteArray();
			data.Serialize(arr);
		}

		public void Write<TSerializable>(TSerializable[] data)
	where TSerializable : IObjectSerializable
		{
			AArray arr = WriteArray();
			int count = data.Length;
			for(int x = 0; x < count; ++x)
			{
				arr.Write(data[x]);
			}
		}

		public void Write<TSerializable>(ICollection<TSerializable> data)
			where TSerializable : IObjectSerializable
		{
			AArray arr = WriteArray();
			foreach(TSerializable item in data)
			{
				arr.Write(item);
			}
		}

		public abstract string ToString(bool formatted);
	}
}
