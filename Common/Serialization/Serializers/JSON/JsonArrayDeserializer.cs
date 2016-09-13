using ProceduralLevel.Common.Parsing;
using System;

namespace ProceduralLevel.Common.Serialization
{
	public class JsonArrayDeserializer: IDeserializer
	{
		private JsonArray m_Array;
		private int m_Head = 0;

		public int Count { get { return m_Array.Count; } }

		public JsonArrayDeserializer()
		{
			m_Array = new JsonArray(4);
		}

		public JsonArrayDeserializer(JsonArray array)
		{
			m_Array = array;
		}

		public void Clear()
		{
			m_Array = new JsonArray(4);
			m_Head = 0;
		}

		public void FromString(string str)
		{
			throw new Exception("Array cannot be a root of JSON file.");
		}

		public void Load(IDataReader reader)
		{
			JsonParser parser =  new JsonParser();
			string text = reader.ReadString();
			throw new NotImplementedException();
		}

		public void ReadObject(IPairSerializable obj)
		{
			ReadObject(m_Head++, obj);
		}

		public void ReadArray(ISerializable obj)
		{
			ReadArray(m_Head++, obj);
		}

		public IPairDeserializer ReadObject()
		{
			return ReadObject(m_Head++);
		}

		public IDeserializer ReadArray()
		{
			return ReadArray(m_Head++);
		}

		public bool ReadBool()
		{
			return m_Array.ReadBool(m_Head++);
		}

		public byte ReadByte()
		{
			return m_Array.ReadByte(m_Head++);
		}

		public short ReadShort()
		{
			return m_Array.ReadShort(m_Head++);
		}

		public int ReadInt()
		{
			return m_Array.ReadInt(m_Head++);
		}

		public long ReadLong()
		{
			return m_Array.ReadLong(m_Head++);
		}

		public float ReadFloat()
		{
			return m_Array.ReadFloat(m_Head++);
		}

		public double ReadDouble()
		{
			return m_Array.ReadDouble(m_Head++);
		}

		public string ReadString()
		{
			return m_Array.ReadString(m_Head++);
		}

		public void ReadObject(int index, IPairSerializable obj)
		{
			obj.Deserialize(ReadObject(index));
		}

		public void ReadArray(int index, ISerializable obj)
		{
			obj.Deserialize(ReadArray(index));
		}

		public IPairDeserializer ReadObject(int index)
		{
			return new JsonObjectDeserializer(m_Array.ReadObject(index));
		}

		public IDeserializer ReadArray(int index)
		{
			return new JsonArrayDeserializer(m_Array.ReadArray(index));
		}

		public bool ReadBool(int index)
		{
			return m_Array.ReadBool(index);
		}

		public byte ReadByte(int index)
		{
			return m_Array.ReadByte(index);
		}

		public short ReadShort(int index)
		{
			return m_Array.ReadShort(index);
		}

		public int ReadInt(int index)
		{
			return m_Array.ReadInt(index);
		}

		public long ReadLong(int index)
		{
			return m_Array.ReadLong(index);
		}

		public float ReadFloat(int index)
		{
			return m_Array.ReadFloat(index);
		}

		public double ReadDouble(int index)
		{
			return m_Array.ReadDouble(index);
		}

		public string ReadString(int index)
		{
			return m_Array.ReadString(index);
		}
	}
}
