#define SIMPLE_FORMAT

using System.Collections.Generic;
using System.Text;

namespace Common.Parsing
{
	public class JsonObject
    {
		private const string PAIR_FORMAT = "{0}{1}{0}{2}{3}";

		private Dictionary<string, object> m_Params;
		private Dictionary<string, JsonObject> m_Objects;
		private Dictionary<string, JsonArray> m_Arrays;

		public JsonObject()
		{
			m_Params = new Dictionary<string, object>();
			m_Objects = new Dictionary<string, JsonObject>();
			m_Arrays = new Dictionary<string, JsonArray>();
		}

		public override string ToString()
		{
			StringBuilder builder = new StringBuilder();
			builder.Append(JsonConst.BRACKETS_OPEN);
#if SIMPLE_FORMAT
			builder.Append("\n");
#endif

			int toWrite = m_Params.Count+m_Objects.Count+m_Arrays.Count;
			int written = 0;
			foreach(var pair in m_Params)
			{
				WritePairs(builder, pair.Key, pair.Value, ref written, toWrite);
			}

			foreach(var pair in m_Objects)
			{
				WritePairs(builder, pair.Key, pair.Value, ref written, toWrite);
			}

			foreach(var pair in m_Arrays)
			{
				WritePairs(builder, pair.Key, pair.Value, ref written, toWrite);
			}

			builder.Append(JsonConst.BRACKETS_CLOSE);
			return builder.ToString();
		}

		private void WritePairs(StringBuilder builder, string key, object value, ref int written, int toWrite)
		{
			builder.AppendFormat(PAIR_FORMAT,
				JsonConst.QUOTATION, key, JsonConst.KEY_VALUE_SEPARATOR, value.ToString());
			written++;
			if(written < toWrite)
			{
				builder.Append(JsonConst.SEPARATOR);
			}
#if SIMPLE_FORMAT
			builder.Append("\n");
#endif
		}

		public void Write(string key, bool param)
		{
			m_Params[key] = param;
		}

		public void Write(string key, byte param)
		{
			m_Params[key] = param;
		}

		public void Write(string key, short param)
		{
			m_Params[key] = param;
		}

		public void Write(string key, int param)
		{
			m_Params[key] = param;
		}

		public void Write(string key, long param)
		{
			m_Params[key] = param;
		}

		public void Write(string key, float param)
		{
			m_Params[key] = param;
		}

		public void Write(string key, double param)
		{
			m_Params[key] = param;
		}

		public void Write(string key, string str)
		{
			m_Params[key] = JsonConst.QUOTATION+str+JsonConst.QUOTATION;
		}

		public void Write(string key, JsonObject obj)
		{
			m_Objects[key] = obj;
		}

		public void Write(string key, JsonArray array)
		{
			m_Arrays[key] = array;
		}

		#region Read
		public bool ReadBool(string key)
		{
			return (bool)m_Params[key];
		}

		public byte ReadByte(string key)
		{
			return (byte)ReadDouble(key);
		}

		public short ReadShort(string key)
		{
			return (short)ReadDouble(key);
		}

		public int ReadInt(string key)
		{
			return (int)ReadDouble(key);
		}

		public long ReadLong(string key)
		{
			return (long)ReadDouble(key);
		}

		public float ReadFloat(string key)
		{
			return (float)ReadDouble(key);
		}

		public double ReadDouble(string key)
		{
			return (double)m_Params[key];
		}

		public string ReadString(string key)
		{
			string str = (string)m_Params[key];
			return str.Substring(1, str.Length-2);
		}

		public JsonObject ReadObject(string key)
		{
			return m_Objects[key];
		}

		public JsonArray ReadArray(string key)
		{
			return m_Arrays[key];
		}
		#endregion

		#region TryRead
		public bool TryReadBool(string key, bool defaultValue = false)
		{
			object value;
			if(m_Params.TryGetValue(key, out value))
			{
				return (bool)value;
			}
			return defaultValue;
		}

		public byte TryReadByte(string key, byte defaultValue = 0)
		{
			return (byte)TryReadDouble(key, defaultValue);
		}

		public short TryReadShort(string key, short defaultValue = 0)
		{
			return (short)TryReadDouble(key, defaultValue);
		}

		public int TryReadInt(string key, int defaultValue = 0)
		{
			return (int)TryReadDouble(key, defaultValue);
		}

		public long TryReadLong(string key, long defaultValue = 0)
		{
			return (long)TryReadDouble(key, defaultValue);
		}

		public float TryReadFloat(string key, float defaultValue = 0)
		{
			return (float)TryReadDouble(key, defaultValue);
		}

		public double TryReadDouble(string key, double defaultValue = 0)
		{
			object value;
			if(m_Params.TryGetValue(key, out value))
			{
				return (double)value;
			}
			return defaultValue;
		}

		public string TryReadString(string key, string defaultValue = "")
		{
			object value;
			if(m_Params.TryGetValue(key, out value))
			{
				string str = (string)value;
				return str.Substring(1, str.Length-2);
			}
			return defaultValue;
		}

		public JsonObject TryReadObject(string key)
		{
			JsonObject obj;
			m_Objects.TryGetValue(key, out obj);
			return obj;
		}

		public JsonArray TryReadArray(string key)
		{
			JsonArray array;
			m_Arrays.TryGetValue(key, out array);
			return array;
		}
		#endregion
	}
}
