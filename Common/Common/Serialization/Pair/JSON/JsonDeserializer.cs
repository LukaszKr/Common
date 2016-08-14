using Common.Parsing;

namespace Common.Serialization
{
	public class JsonDeserializer: IPairDeserializer
	{
		protected JsonObject m_Object;

		public JsonDeserializer()
		{
			m_Object = new JsonObject();
		}

		public JsonDeserializer(JsonObject obj)
		{
			m_Object = obj;
		}

		public void Load(IDataReader reader)
		{
			m_Object = new JsonObject();
			string text = reader.ReadString();
			JsonParser parser = new JsonParser();
			m_Object = parser.Parse(text);
		}

		public void Clear()
		{
			m_Object = null;
		}

		private enum ParseState
		{
			Key,
			KeyValueSeparator,
			Value,
			PostValue
		}

		#region Read
		public IPairDeserializer ReadObject(string key)
		{
			return new JsonDeserializer(m_Object.ReadObject(key));
		}

		public void ReadObject(string key, IPairSerializable obj)
		{
			IPairDeserializer deserializer = ReadObject(key);
			obj.Deserialize(deserializer);
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
		public IPairDeserializer TryReadObject(string key)
		{
			JsonObject json = m_Object.TryReadObject(key);
			if(json == null)
			{
				return new JsonDeserializer(json);
			}
			return null;
		}

		public bool TryReadObject(string key, IPairSerializable obj) 
		{
			IPairDeserializer deserializer = TryReadObject(key);
			if(deserializer != null)
			{
				obj.Deserialize(deserializer);
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
		#endregion
	}
}
