using System.Collections.Generic;
using ProceduralLevel.Common.Parsing;

namespace ProceduralLevel.Common.Serialization
{
	public class JsonObjectSerializer: IObjectSerializer
	{
		public JsonObject Object { get; private set; }

		public JsonObjectSerializer()
		{
			Object = new JsonObject();
		}

		public void Save(IDataWriter writer)
		{
			writer.Write(Object.ToString());
		}

		public void Clear()
		{
			Object = new JsonObject();
		}

		public override string ToString()
		{
			return Object.ToString();
		}

		#region Write
		public void Write(string key, bool data)
		{
			Object.Write(key, data);
		}

		public void Write(string key, byte data)
		{
			Object.Write(key, data);
		}

		public void Write(string key, short data)
		{
			Object.Write(key, data);
		}

		public void Write(string key, int data)
		{
			Object.Write(key, data);
		}

		public void Write(string key, long data)
		{
			Object.Write(key, data);
		}

		public void Write(string key, float data)
		{
			Object.Write(key, data);
		}

		public void Write(string key, double data)
		{
			Object.Write(key, data);
		}

		public void Write(string key, string data)
		{
			Object.Write(key, data);
		}

		public void Write(string key, IObjectSerializable serializable)
		{
			JsonObjectSerializer serializer = new JsonObjectSerializer();
			serializable.Serialize(serializer);
			Object.Write(key, serializer.Object);
		}

		public void Write(string key, IArraySerializable serializable)
		{
			JsonArraySerializer serializer = new JsonArraySerializer();
			serializable.Serialize(serializer);
			Object.Write(key, serializer.Array);
		}

		public void Write(string key, IEnumerable<IObjectSerializable> serializables)
		{
			IArraySerializer array = WriteArray(key);
			foreach(IObjectSerializable serializable in serializables)
			{
				array.Write(serializable);
			}
		}

		public void Write(string key, IEnumerable<IArraySerializable> serializables)
		{
			IArraySerializer array = WriteArray(key);
			foreach(IArraySerializable serializable in serializables)
			{
				array.Write(serializable);
			}
		}

		public IObjectSerializer WriteObject(string key)
		{
			JsonObjectSerializer serializer = new JsonObjectSerializer();
			Object.Write(key, serializer.Object);
			return serializer;
		}

		public IArraySerializer WriteArray(string key)
		{
			JsonArraySerializer serializer = new JsonArraySerializer();
			Object.Write(key, serializer.Array);
			return serializer;
		}
		#endregion
	}
}
