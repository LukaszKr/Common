using System.Collections.Generic;

namespace ProceduralLevel.Common.Serialization
{
	public abstract partial class AObject
	{
		public abstract int Count { get; }

		public abstract string[] Keys();
		public abstract void Clear();
		
		public abstract bool ContainsKey(string key);
		public abstract bool DeleteKey(string key);

		public abstract AObject WriteObject(string key);
		public abstract AArray WriteArray(string key);
		public abstract AObject ReadObject(string key);
		public abstract AArray ReadArray(string key);

		public void Write(string key, IObjectSerializable data)
		{
			AObject obj = WriteObject(key);
			data.Serialize(obj);
		}

		public void Write(string key, IArraySerializable data)
		{
			AArray arr = WriteArray(key);
			data.Serialize(arr);
		}

		public void Write<TSerializable>(string key, TSerializable[] data)
			where TSerializable : IObjectSerializable
		{
			AArray arr = WriteArray(key);
			int count = data.Length;
			for(int x = 0; x < count; ++x)
			{
				arr.Write(data[x]);
			}
		}

		public void Write<TSerializable>(string key, ICollection<TSerializable> data)
			where TSerializable : IObjectSerializable
		{
			AArray arr = WriteArray(key);
			foreach(TSerializable item in data)
			{
				arr.Write(item);
			}
		}

		public AObject TryReadObject(string key)
		{
			try
			{
				AObject value = ReadObject(key);
				return value;
			}
			catch { }
			return null;
		}

		public AArray TryReadArray(string key)
		{
			try
			{
				AArray value = ReadArray(key);
				return value;
			}
			catch { }
			return null;
		}

		public abstract string ToString(bool formatted);
	}
}
