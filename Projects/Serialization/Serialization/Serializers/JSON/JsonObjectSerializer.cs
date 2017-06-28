using ProceduralLevel.Parsing;
using System.Collections.Generic;

namespace ProceduralLevel.Serialization
{
	public class JsonObjectSerializer: IObjectSerializer
	{
		private JsonObject m_Object;
		public JsonObject Object { get { return m_Object; } }

		public JsonObjectSerializer()
		{
			m_Object = new JsonObject();
		}

		public JsonObjectSerializer(JsonObject obj)
		{
			m_Object = obj;
		}

		public void Load(string rawJson)
		{
			JsonParser parser = new JsonParser();
			parser.Parse(rawJson);
			m_Object = parser.Flush();
		}

		public void Clear()
		{
			m_Object = new JsonObject();
		}

		public override string ToString()
		{
			return m_Object.ToString();
		}

		public string[] Keys()
		{
			return m_Object.Keys();
		}

		#region Write
		public void Write(string key, bool data)
		{
			m_Object.Write(key, data);
		}

		public void Write(string key, byte data)
		{
			m_Object.Write(key, data);
		}

		public void Write(string key, short data)
		{
			m_Object.Write(key, data);
		}

		public void Write(string key, int data)
		{
			m_Object.Write(key, data);
		}

		public void Write(string key, long data)
		{
			m_Object.Write(key, data);
		}

		public void Write(string key, float data)
		{
			m_Object.Write(key, data);
		}

		public void Write(string key, double data)
		{
			m_Object.Write(key, data);
		}

		public void Write(string key, string data)
		{
			m_Object.Write(key, data);
		}

		public void Write(string key, IObjectSerializable serializable)
		{
			JsonObjectSerializer serializer = new JsonObjectSerializer();
			serializable.Serialize(serializer);
			m_Object.Write(key, serializer.Object);
		}

		public void Write(string key, IArraySerializable serializable)
		{
			JsonArraySerializer serializer = new JsonArraySerializer();
			serializable.Serialize(serializer);
			m_Object.Write(key, serializer.Array);
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

		public void Write(string key, object data)
		{
			m_Object.WriteObject(key, data);
		}

		public void Write(string key, IObjectSerializer obj)
		{
			JsonObjectSerializer serializer = new JsonObjectSerializer();
			m_Object.Write(key, serializer.Object);
			string[] keys = obj.Keys();
			for(int x = 0; x < keys.Length; x++)
			{
				m_Object.WriteObject(key, obj.TryRead(keys[x]));
			}
		}

		public IObjectSerializer WriteObject(string key)
		{
			JsonObjectSerializer serializer = new JsonObjectSerializer();
			m_Object.Write(key, serializer.Object);
			return serializer;
		}

		public IArraySerializer WriteArray(string key)
		{
			JsonArraySerializer serializer = new JsonArraySerializer();
			m_Object.Write(key, serializer.Array);
			return serializer;
		}

		public IArraySerializer WriteArray(string key, object[] data)
		{
			JsonArraySerializer serializer = new JsonArraySerializer();
			m_Object.Write(key, serializer.Array);
			serializer.WriteArray(data);
			return serializer;
		}
		#endregion

		#region Read
		public IObjectSerializer ReadObject(string key)
		{
			return new JsonObjectSerializer(m_Object.ReadObject(key));
		}

		public IArraySerializer ReadArray(string key)
		{
			return new JsonArraySerializer(m_Object.ReadArray(key));
		}

		public void ReadObject(string key, IObjectSerializable obj)
		{
			IObjectSerializer serializer = ReadObject(key);
			obj.Deserialize(serializer);
		}

		public void ReadArray(string key, IArraySerializable array)
		{
			IArraySerializer deserializer = ReadArray(key);
			array.Deserialize(deserializer);
		}

		public bool ReadBool(string key)
		{
			return m_Object.ReadBool(key);
		}

		public byte ReadByte(string key)
		{
			return m_Object.ReadByte(key);
		}

		public short ReadShort(string key)
		{
			return m_Object.ReadShort(key);
		}

		public int ReadInt(string key)
		{
			return m_Object.ReadInt(key);
		}

		public long ReadLong(string key)
		{
			return m_Object.ReadLong(key);
		}

		public float ReadFloat(string key)
		{
			return m_Object.ReadFloat(key);
		}

		public double ReadDouble(string key)
		{
			return m_Object.ReadDouble(key);
		}

		public string ReadString(string key)
		{
			return m_Object.ReadString(key);
		}
		#endregion

		#region TryRead
		public IObjectSerializer TryReadObject(string key)
		{
			JsonObject json = m_Object.TryReadObject(key);
			if(json != null)
			{
				return new JsonObjectSerializer(json);
			}
			return null;
		}

		public IArraySerializer TryReadArray(string key)
		{
			JsonArray array = m_Object.TryReadArray(key);
			if(array != null)
			{
				return new JsonArraySerializer(array);
			}
			return null;
		}

		public bool TryReadObject(string key, IObjectSerializable obj)
		{
			IObjectSerializer serializer = TryReadObject(key);
			if(serializer != null)
			{
				obj.Deserialize(serializer);
				return true;
			}
			return false;
		}

		public bool TryReadArray(string key, IArraySerializable array)
		{
			IArraySerializer serializer = TryReadArray(key);
			if(serializer != null)
			{
				array.Deserialize(serializer);
				return true;
			}
			return false;
		}

		public bool TryReadBool(string key, bool defaultValue = false)
		{
			return m_Object.TryReadBool(key, defaultValue);
		}

		public byte TryReadByte(string key, byte defaultValue = 0)
		{
			return m_Object.TryReadByte(key, defaultValue);

		}

		public short TryReadShort(string key, short defaultValue = 0)
		{
			return m_Object.TryReadShort(key, defaultValue);

		}

		public int TryReadInt(string key, int defaultValue = 0)
		{
			return m_Object.TryReadInt(key, defaultValue);

		}

		public long TryReadLong(string key, long defaultValue = 0)
		{
			return m_Object.TryReadLong(key, defaultValue);

		}

		public float TryReadFloat(string key, float defaultValue = 0)
		{
			return m_Object.TryReadFloat(key, defaultValue);

		}

		public double TryReadDouble(string key, double defaultValue = 0)
		{
			return m_Object.TryReadDouble(key, defaultValue);

		}

		public string TryReadString(string key, string defaultValue = null)
		{
			return m_Object.TryReadString(key, defaultValue);

		}

		public object TryRead(string key, object defaultValue = null)
		{
			return m_Object.TryRead(key);
		}
		#endregion
	}
}
