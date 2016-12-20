using System;
using System.Text;

namespace ProceduralLevel.Common.Parsing
{
	public class JsonArray: IEquatable<JsonArray>
    {
		private const string STRING_FORMAT = "{0}{1}{0}";

		private object[] m_Data;

		public int Count { get; private set; }

		public JsonArray(int initialLength)
		{
			m_Data = new object[initialLength];
			Count = 0;
		}

        public bool Equals(JsonArray array)
        {
            if(array.Count != Count)
            {
                return false;
            }
            for(int x = 0; x < Count; x++)
            {
                if(!array.m_Data[x].Equals(m_Data[x]))
                {
                    return false;
                }
            }
            return true;
        }

		public override string ToString()
		{
			StringBuilder builder = new StringBuilder();
			builder.Append(JsonConst.ARRAY_OPEN);
#if SIMPLE_FORMAT
			builder.Append("\n");
#endif

			for(int x = 0; x < Count; x++)
			{
				object data = m_Data[x];
				if(data is string)
				{
					builder.Append(string.Format(STRING_FORMAT, JsonConst.QUOTATION, m_Data[x]));
				}
				else
				{
					builder.Append(m_Data[x].ToString());
				}
				if(x < Count-1)
				{
					builder.Append(JsonConst.SEPARATOR);
				}
#if SIMPLE_FORMAT
				builder.Append("\n");
#endif
			}
			builder.Append(JsonConst.ARRAY_CLOSE);
			return builder.ToString();
		}

		public void Resize(int newLength)
		{
			object[] oldData = m_Data;
			m_Data = new object[newLength];
			int copyLength = Math.Min(newLength, oldData.Length);

			for(int x = 0; x < copyLength; x++)
			{
				m_Data[x] = oldData[x];
			}
		}

		private void TryExpand()
		{
			if(Count >= m_Data.Length)
			{
				Resize(Count*2);
			}
		}

		public void WriteObject(object param)
		{
			m_Data[Count++] = param;
			TryExpand();
		}

		public void Write(bool param)
		{
			m_Data[Count++] = param;
			TryExpand();
		}

		public void Write(byte param)
		{
			m_Data[Count++] = param;
			TryExpand();
		}

		public void Write(short param)
		{
			m_Data[Count++] = param;
			TryExpand();
		}

		public void Write(int param)
		{
			m_Data[Count++] = param;
			TryExpand();
		}

		public void Write(long param)
		{
			m_Data[Count++] = param;
			TryExpand();
		}

		public void Write(float param)
		{
			m_Data[Count++] = param;
			TryExpand();
		}

		public void Write(double param)
		{
			m_Data[Count++] = param;
			TryExpand();
		}

		public void Write(string str)
		{
			m_Data[Count++] = str;
			TryExpand();
		}

		public void Write(JsonObject obj)
		{
			m_Data[Count++] = obj;
			TryExpand();
		}

		public void Write(JsonArray array)
		{
			m_Data[Count++] = array;
			TryExpand();
		}

		public void Write(object[] array)
		{
			JsonArray jsonArray = new JsonArray(array.Length);
			for(int x = 0; x < array.Length; x++)
			{
				jsonArray.m_Data[x] = array[x];
			}
			m_Data[Count++] = jsonArray;
			TryExpand();
		}

		#region Read
		public bool ReadBool(int index)
		{
			return (bool)m_Data[index];
		}

		public byte ReadByte(int index)
		{
			return (byte)ReadDouble(index);
		}

		public short ReadShort(int index)
		{
			return (short)ReadDouble(index);
		}

		public int ReadInt(int index)
		{
			return (int)ReadDouble(index);
		}

		public long ReadLong(int index)
		{
			return (long)ReadDouble(index);
		}

		public float ReadFloat(int index)
		{
			return (float)ReadDouble(index);
		}

		public double ReadDouble(int index)
		{
			return (double)m_Data[index];
		}

		public string ReadString(int index)
		{
			string str = (string)m_Data[index];
			return str;
		}

		public JsonObject ReadObject(int index)
		{
			return (JsonObject)m_Data[index];
		}

		public JsonArray ReadArray(int index)
		{
			return (JsonArray)m_Data[index];
		}

		public object Read(int index)
		{
			return m_Data[index];
		}
		#endregion
	}
}
