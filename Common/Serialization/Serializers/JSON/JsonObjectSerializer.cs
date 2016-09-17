using System;
using System.Collections.Generic;
using ProceduralLevel.Common.Parsing;

namespace ProceduralLevel.Common.Serialization
{
	public class JsonObjectSerializer: IPairSerializer
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

		public void Write(string key, IPairSerializable serializable)
		{
			JsonObjectSerializer serializer = new JsonObjectSerializer();
			serializable.Serialize(serializer);
			Object.Write(key, serializer.Object);
		}

		public void Write(string key, ISerializable serializable)
		{
			JsonArraySerializer serializer = new JsonArraySerializer();
			serializable.Serialize(serializer);
			Object.Write(key, serializer.Array);
		}

		public void Write(string key, IEnumerable<IPairSerializable> serializables)
		{
			ISerializer array = WriteArray(key);
			foreach(IPairSerializable serializable in serializables)
			{
				array.Write(serializable);
			}
		}

		public void Write(string key, IEnumerable<ISerializable> serializables)
		{
			ISerializer array = WriteArray(key);
			foreach(ISerializable serializable in serializables)
			{
				array.Write(serializable);
			}
		}

		public IPairSerializer WriteObject(string key)
		{
			JsonObjectSerializer serializer = new JsonObjectSerializer();
			Object.Write(key, serializer.Object);
			return serializer;
		}

		public ISerializer WriteArray(string key)
		{
			JsonArraySerializer serializer = new JsonArraySerializer();
			Object.Write(key, serializer.Array);
			return serializer;
		}
		#endregion
	}
}
