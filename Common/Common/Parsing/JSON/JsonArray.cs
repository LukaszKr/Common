#define SIMPLE_FORMAT

using System;
using System.Text;

namespace Common.Parsing
{
	public class JsonArray
    {
		private object[] m_Data;

		public int Count { get; private set; }

		public JsonArray(int initialLength)
		{
			m_Data = new object[initialLength];
			Count = 0;
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
				builder.Append(m_Data[x].ToString());
				if(x < Count-1)
				{
					builder.Append(JsonConst.SEPARATOR);
				}
#if SIMPLE_FORMAT
				builder.Append("\n");
#endif
			}

#if SIMPLE_FORMAT
			builder.Append("\n");
#endif
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

		public void Write(object obj)
		{
			m_Data[Count++] = obj;
			if(Count >= m_Data.Length)
			{
				Resize(Count*2);
			}
		}

		public void WriteString(string str)
		{
			Write(JsonConst.QUOTATION+str+JsonConst.QUOTATION);
		}

		public void WriteArray(object[] array)
		{
			JsonArray jsonArray = new JsonArray(array.Length);
			for(int x = 0; x < array.Length; x++)
			{
				jsonArray.m_Data[x] = array[x];
			}
			Write(jsonArray);
		}

		#region Read
		public bool ReadBool(int index)
		{
			return (bool)m_Data[index];
		}

		public byte ReadByte(int index)
		{
			return (byte)m_Data[index];
		}

		public short ReadShort(int index)
		{
			return (short)m_Data[index];
		}

		public int ReadInt(int index)
		{
			return (int)m_Data[index];
		}

		public long ReadLong(int index)
		{
			return (long)m_Data[index];
		}

		public float ReadFloat(int index)
		{
			return (float)m_Data[index];
		}

		public double ReadDouble(int index)
		{
			return (double)m_Data[index];
		}

		public string ReadString(int index)
		{
			string str = (string)m_Data[index];
			return str.Substring(1, str.Length-2);
		}

		public JsonObject ReadObject(int index)
		{
			return (JsonObject)m_Data[index];
		}

		public JsonArray ReadArray(int index)
		{
			return (JsonArray)m_Data[index];
		}
		#endregion
	}
}
