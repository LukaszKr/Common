using System.Collections.Generic;
using System.Text;

namespace Common.Serialization
{
	public class JsonSerializer: JsonPersistence, IPairSerializer
	{
		protected Dictionary<string, JsonSerializer> m_Objects;

		private int m_WrittenBytes;

		public JsonSerializer()
		{
			m_Objects = new Dictionary<string, JsonSerializer>();
		}

		public override void Clear()
		{
			base.Clear();
			m_Objects.Clear();
		}

		#region Save
		public void Save(IDataWriter writer)
		{
			StringBuilder builder = new StringBuilder(CountBytes());
			BuildString(builder);
			writer.Write(builder.ToString());
		}

		private void BuildString(StringBuilder builder)
		{
			builder.Append(BRACKETS_OPEN);
			int left = 0;

			left = m_Parameters.Count;
			foreach(var pair in m_Parameters)
			{
				builder.Append(pair.Key);
				builder.Append(KEY_VALUE_SEPARATOR);
				builder.Append(pair.Value);
				left --;
				if(left > 0 || m_Objects.Count > 0)
				{
					builder.Append(PAIR_SEPARATOR);
					builder.Append(NEW_LINE);
				}
			}

			left = m_Objects.Count;
			foreach(var pair in m_Objects)
			{
				builder.Append(QUOTATION+pair.Key+QUOTATION);
				builder.Append(KEY_VALUE_SEPARATOR);
				pair.Value.BuildString(builder);

				left --;
				if(left > 0)
				{
					builder.Append(PAIR_SEPARATOR);
					builder.Append(NEW_LINE);
				}
			}
			builder.Append(BRACKETS_CLOSE);
		}

		private int CountBytes()
		{
			int total = m_WrittenBytes;
			foreach(JsonSerializer serializer in m_Objects.Values)
			{
				total += serializer.CountBytes();
			}
			return total;
		}
		#endregion

		#region Write
		private void WriteKey(string key, object data)
		{
			string dataStr = data.ToString();
			m_WrittenBytes += dataStr.Length+key.Length+2;
			m_Parameters[QUOTATION+key+QUOTATION] = dataStr;
		}

		public void Write(string key, IPairSerializable serializable)
		{
			JsonSerializer serializer = new JsonSerializer();
			serializable.Serialize(serializer);
			m_Objects[key] = serializer;
		}

		public void Write(string key, bool data)
		{
			WriteKey(key, data);
		}

		public void Write(string key, byte data)
		{
			WriteKey(key, data);
		}

		public void Write(string key, short data)
		{
			WriteKey(key, data);
		}

		public void Write(string key, int data)
		{
			WriteKey(key, data);
		}

		public void Write(string key, long data)
		{
			WriteKey(key, data);
		}

		public void Write(string key, float data)
		{
			WriteKey(key, data);
		}

		public void Write(string key, double data)
		{
			WriteKey(key, data);
		}

		public void Write(string key, string data)
		{
			WriteKey(key, QUOTATION+data+QUOTATION);
		}
		#endregion
	}
}
