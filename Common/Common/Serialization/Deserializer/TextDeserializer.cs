namespace Common.Serialization
{
	public class TextDeserializer: TextPersistence, IDeserializer
    {
		private ITextReader m_Reader;
		private int m_Head = 0;

		public int Head { get { return m_Head; } }

		public TextDeserializer(ITextReader reader)
		{
			m_Reader = reader;
		}

		public override void Clear()
		{
			base.Clear();
			m_Head = 0;
		}

		public void Load()
		{
			string text = m_Reader.Read();
			int lastIndex = 0;
			bool field = false;
			bool isString = false;
			for(int x = 0; x < text.Length; x++)
			{
				switch(text[x])
				{
					case SEPARATOR:
						if(isString)
						{
							m_Buffer.Add(text.Substring(lastIndex+1, x-lastIndex-1));
						}
						else
						{
							m_Buffer.Add(text.Substring(lastIndex, x-lastIndex));
						}
						lastIndex = x+1;
						isString = false;
						break;
					case QUOTATION:
						isString = true;
						field = !field;
						break;
				}
			}
		}

		#region Read
		private string GetFromBuffer()
		{
			return m_Buffer[m_Head++];
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

		public void Read<ObjectType>(ObjectType obj) where ObjectType : ISerializable
		{
			obj.Deserialize(this);
		}
		#endregion
	}
}
