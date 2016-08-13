namespace Common.Serialization
{
	public class TextDeserializer: TextPersistence, IDeserializer
    {
		private int m_Head = 0;

		private int m_LastIndex;
		private bool m_Field;
		private bool m_IsString;
		private string m_Chunk;

		public int Head { get { return m_Head; } }

		public TextDeserializer(char separator = ';', char stringMarker = '"') : base(separator, stringMarker)
		{
		}

		public override void Clear()
		{
			base.Clear();
			m_Head = 0;
			m_LastIndex = 0;
			m_Field = false;
			m_IsString = false;
		}

		public void Load(IDataReader reader)
		{
			string text = reader.ReadString();
			FromString(text);
		}

		public void FromString(string stringPart)
		{
			string str = m_Chunk + stringPart;
			for(int x = 0; x < str.Length; x++)
			{
				if(str[x] == Separator)
				{
					if(m_IsString)
					{
						m_Buffer.Add(str.Substring(m_LastIndex+1, x-m_LastIndex-1));
					}
					else
					{
						m_Buffer.Add(str.Substring(m_LastIndex, x-m_LastIndex));
					}
					m_LastIndex = x+1;
					m_IsString = false;
				}
				else if(str[x] == StringMarker)
				{
					m_IsString = true;
					m_Field = !m_Field;
				}
			}
			if(m_LastIndex < str.Length)
			{
				m_Chunk = str.Substring(m_LastIndex);
			}
			else
			{
				m_Chunk = null;
			}
		}

		#region Read
		private string GetFromBuffer()
		{
			return m_Buffer[m_Head++];
		}

		private string GetFromBuffer(int index)
		{
			return m_Buffer[index];
		}

		public void Read(ISerializable obj)
		{
			obj.Deserialize(this);
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

		public void Read(int index, ISerializable obj)
		{
			int oldHead = m_Head;
			m_Head = index;
			obj.Deserialize(this);
			m_Head = oldHead;
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
