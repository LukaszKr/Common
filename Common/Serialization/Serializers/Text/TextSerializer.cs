using System;
using System.Text;

namespace ProceduralLevel.Common.Serialization
{
	public class TextSerializer: TextPersistence, IArraySerializer
	{
		private int m_BufferedData = 0;
		private int m_Head = 0;

		public int Head { get { return m_Head; } }

		public TextSerializer(char separator = ';', char stringMarker = '"') : base(separator, stringMarker)
		{
		}

		public override void Clear()
		{
			base.Clear();
			m_BufferedData = 0;
			m_Head = 0;
		}

		public void Load(IDataReader reader)
		{
			string text = reader.ReadString();
			Load(text);
		}

		public void Load(string str)
		{
			bool isString = false, field = false;
			int lastIndex = 0;
			for(int x = 0; x < str.Length; x++)
			{
				if(str[x] == Separator)
				{
					if(isString)
					{
						m_Buffer.Add(str.Substring(lastIndex+1, x-lastIndex-1));
					}
					else
					{
						m_Buffer.Add(str.Substring(lastIndex, x-lastIndex));
					}
					lastIndex = x+1;
					isString = false;
				}
				else if(str[x] == StringMarker)
				{
					isString = true;
					field = !field;
				}
			}
			if(lastIndex < str.Length)
			{
				m_Buffer.Add(str.Substring(lastIndex));
			}
		}

		public void Save(IDataWriter writer)
		{
			writer.Write(ToString());
		}

		public override string ToString()
		{
			StringBuilder builder = new StringBuilder(m_BufferedData+m_Buffer.Count-1);
			for(int x = 0; x < m_Buffer.Count; x++)
			{
				builder.Append(m_Buffer[x]);
				if(x < m_Buffer.Count-1)
				{
					builder.Append(Separator);
				}
			}
			return builder.ToString();
		}

		#region Write
		private void AddToBuffer(string str)
		{
			m_BufferedData += str.Length;
			m_Buffer.Add(str);
		}

		public void Write(IObjectSerializable serializable)
		{
			throw new NotSupportedException();
		}

		public void Write(IArraySerializable serializable)
		{
			serializable.Serialize(this);
		}

		public void Write(string data)
		{
			AddToBuffer(StringMarker+data.ToString()+StringMarker);
		}

		public void Write(object data)
		{
			AddToBuffer(data.ToString());
		}
		#endregion

		#region Read
		private string GetFromBuffer()
		{
			return m_Buffer[m_Head++];
		}

		private string GetFromBuffer(int index)
		{
			return m_Buffer[index];
		}

		public void ReadObject(IObjectSerializable obj)
		{
			throw new NotSupportedException();
		}

		public void ReadArray(IArraySerializable obj)
		{
			obj.Deserialize(this);
		}

		public IObjectSerializer ReadObject()
		{
			throw new NotSupportedException();
		}

		public IArraySerializer ReadArray()
		{
			throw new NotSupportedException();
		}

		public byte ReadByte()
		{
			return byte.Parse(GetFromBuffer());
		}

		public bool ReadBool()
		{
			return bool.Parse(GetFromBuffer());
		}

		public short ReadShort()
		{
			return short.Parse(GetFromBuffer());
		}

		public int ReadInt()
		{
			return int.Parse(GetFromBuffer());
		}

		public long ReadLong()
		{
			return long.Parse(GetFromBuffer());
		}

		public float ReadFloat()
		{
			return float.Parse(GetFromBuffer());
		}

		public double ReadDouble()
		{
			return double.Parse(GetFromBuffer());
		}

		public string ReadString()
		{
			return GetFromBuffer();
		}

		public void ReadObject(int index, IObjectSerializable obj)
		{
			throw new NotSupportedException();
		}

		public void ReadArray(int index, IArraySerializable obj)
		{
			int oldHead = m_Head;
			m_Head = index;
			obj.Deserialize(this);
			m_Head = oldHead;
		}

		public IObjectSerializer ReadObject(int index)
		{
			throw new NotSupportedException();
		}

		public IArraySerializer ReadArray(int index)
		{
			throw new NotSupportedException();
		}

		public byte ReadByte(int index)
		{
			return byte.Parse(GetFromBuffer(index));
		}

		public bool ReadBool(int index)
		{
			return bool.Parse(GetFromBuffer(index));
		}

		public short ReadShort(int index)
		{
			return short.Parse(GetFromBuffer(index));
		}

		public int ReadInt(int index)
		{
			return int.Parse(GetFromBuffer(index));
		}

		public long ReadLong(int index)
		{
			return long.Parse(GetFromBuffer(index));
		}

		public float ReadFloat(int index)
		{
			return float.Parse(GetFromBuffer(index));
		}

		public double ReadDouble(int index)
		{
			return double.Parse(GetFromBuffer(index));
		}

		public string ReadString(int index)
		{
			return GetFromBuffer(index);
		}
		#endregion
	}
}
