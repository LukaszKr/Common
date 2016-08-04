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
							m_Buffer.Add(text.Substring(lastIndex, x-1));
						}
						else
						{
							m_Buffer.Add(text.Substring(lastIndex+1, x-2));
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

		public void Read(out byte data)
		{
			data = byte.Parse(GetFromBuffer());
		}

		public void Read(out long data)
		{
			data = long.Parse(GetFromBuffer());
		}

		public void Read(out string data)
		{
			data = GetFromBuffer();
		}

		public void Read(out double data)
		{
			data = double.Parse(GetFromBuffer());
		}

		public void Read(out float data)
		{
			data = float.Parse(GetFromBuffer());
		}

		public void Read(out int data)
		{
			data = int.Parse(GetFromBuffer());
		}

		public void Read(out short data)
		{
			data = short.Parse(GetFromBuffer());
		}

		public void Read(out bool data)
		{
			data = bool.Parse(GetFromBuffer());
		}

		public void Read<ObjectType>(ObjectType obj) where ObjectType : ISerializable
		{
			obj.Deserialize(this);
		}
		#endregion
	}
}
