using ProceduralLevel.Common.Parsing;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ProceduralLevel.Common.Serialization
{
	public class JsonArraySerializer: IArraySerializer
	{
		private JsonArray m_Array;
		private int m_Head = 0;


		public JsonArray Array { get { return m_Array; } }

		public int Count { get { return m_Array.Count; } }

		public JsonArraySerializer()
		{
			m_Array = new JsonArray(4);
		}

		public JsonArraySerializer(JsonArray array)
		{
			m_Array = array;
		}

		public void Load(string rawData)
		{
			throw new Exception("Array cannot be a root of JSON file.");
		}

		public void Load(IDataReader reader)
		{
			throw new Exception("Array cannot be a root of JSON file.");
		}

		public void Save(IDataWriter writer)
		{
			writer.Write(Array.ToString());
		}

		public void Clear()
		{
			m_Array = new JsonArray(4);
			m_Head = 0;
		}

		public override string ToString()
		{
			return m_Array.ToString();
		}

		#region Write
		public void Write(IObjectSerializable serializable)
		{
			JsonObjectSerializer serializer = new JsonObjectSerializer();
			serializable.Serialize(serializer);
			m_Array.Write(serializer.Object);
		}

		public void Write(IArraySerializable serializable)
		{
			JsonArraySerializer serializer = new JsonArraySerializer();
			serializable.Serialize(serializer);
			m_Array.Write(serializer.Array);
		}

		public void Write(string data)
		{
			m_Array.Write(data);
		}

		public void Write(object data)
		{
			m_Array.WriteObject(data);
		}

		public IObjectSerializer WriteObject()
		{
			JsonObjectSerializer serializer = new JsonObjectSerializer();
			m_Array.Write(serializer.Object);
			return serializer;
		}

		public IArraySerializer WriteArray()
		{
			JsonArraySerializer serializer = new JsonArraySerializer();
			m_Array.Write(serializer.Array);
			return serializer;
		}

		public void WriteArray(object[] data)
		{
			for(int x = 0; x < data.Length; x++)
			{
				object item = data[x];
				IArraySerializable arrItem = item as IArraySerializable;
				if(arrItem != null)
				{
					Write(arrItem);
					continue;
				}

				IObjectSerializable objItem = item as IObjectSerializable;
				if(objItem != null)
				{
					Write(objItem);
					continue;
				}

				Write(item);
			}
		}
		#endregion

		#region Read
		public void ReadObject(IObjectSerializable obj)
		{
			ReadObject(m_Head++, obj);
		}

		public void ReadArray(IArraySerializable obj)
		{
			ReadArray(m_Head++, obj);
		}

		public IObjectSerializer ReadObject()
		{
			return ReadObject(m_Head++);
		}

		public IArraySerializer ReadArray()
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

		public object Read()
		{
			return m_Array.Read(m_Head++);
		}
		public void ReadObject(int index, IObjectSerializable obj)
		{
			obj.Deserialize(ReadObject(index));
		}

		public void ReadArray(int index, IArraySerializable obj)
		{
			obj.Deserialize(ReadArray(index));
		}

		public IObjectSerializer ReadObject(int index)
		{
			return new JsonObjectSerializer(m_Array.ReadObject(index));
		}

		public IArraySerializer ReadArray(int index)
		{
			return new JsonArraySerializer(m_Array.ReadArray(index));
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

		public object Read(int index)
		{
			return m_Array.Read(index);
		}
		#endregion
	}
}
