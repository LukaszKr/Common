using Common.Parsing;
using System;
using System.Collections.Generic;

namespace Common.Serialization
{
	public class JsonDeserializer: JsonPersistence, IPairDeserializer
	{
		protected Dictionary<string, JsonDeserializer> m_Objects;
		private Tokenizer m_Tokenizer;

		public JsonDeserializer()
		{
			m_Objects = new Dictionary<string, JsonDeserializer>();
			m_Tokenizer = new Tokenizer();
			m_Tokenizer.AddSeparators(BRACKETS_OPEN, BRACKETS_CLOSE, KEY_VALUE_SEPARATOR, PAIR_SEPARATOR, QUOTATION);
		}

		public override void Clear()
		{
			base.Clear();
			m_Objects.Clear();
		}

		public void Load(IDataReader reader)
		{
			string text = reader.ReadString();
			m_Tokenizer.Tokenize(text);
			List<Token> tokens = m_Tokenizer.Flush();
			ParseObject(tokens, 1);
		}

		private enum ParseState
		{
			Key,
			KeyValueSeparator,
			Value,
			PostValue
		}

		private int ParseObject(List<Token> tokens, int offset)
		{
			string key = null;
			ParseState state = ParseState.Key;
			for(int tokenIndex = offset; tokenIndex < tokens.Count; tokenIndex ++)
			{
				Token token = tokens[tokenIndex];
				switch(state)
				{
					case ParseState.Key:
						if(!token.IsSeparator)
						{
							key = token.Value;
							state = ParseState.KeyValueSeparator;
						}
						break;
					case ParseState.KeyValueSeparator:
						if(token.IsSeparator && token.Value == KEY_VALUE_SEPARATOR.ToString())
						{
							state = ParseState.Value;
						}
						break;
					case ParseState.Value:
						if(!token.IsSeparator)
						{
							m_Parameters[key] = token.Value;
							state = ParseState.PostValue;
						}
						else if(token.Value == BRACKETS_OPEN.ToString())
						{
							JsonDeserializer deserializer = new JsonDeserializer();
							m_Objects[key] = deserializer;
							tokenIndex = deserializer.ParseObject(tokens, tokenIndex);
							state = ParseState.PostValue;
						}
						break;
					case ParseState.PostValue:
						if(token.IsSeparator)
						{
							if(token.Value == PAIR_SEPARATOR.ToString())
							{
								state = ParseState.Key;
							}
							else if(token.Value == BRACKETS_CLOSE.ToString())
							{
								return tokenIndex;
							}
						}
						break;
				}
			}
			return tokens.Count;
		}

		#region Read
		public void Read(string key, IPairSerializable obj)
		{
			IPairDeserializer deserializer = m_Objects[key];
			obj.Deserialize(deserializer);
		}

		public IPairDeserializer ReadObject(string key)
		{
			return m_Objects[key];
		}

		public bool ReadBool(string key)
		{
			return bool.Parse(m_Parameters[key]);
		}

		public byte ReadByte(string key)
		{
			return byte.Parse(m_Parameters[key]);
		}

		public short ReadShort(string key)
		{
			return short.Parse(m_Parameters[key]);
		}

		public int ReadInt(string key)
		{
			return int.Parse(m_Parameters[key]);
		}

		public long ReadLong(string key)
		{
			return long.Parse(m_Parameters[key]);
		}

		public float ReadFloat(string key)
		{
			return float.Parse(m_Parameters[key]);
		}

		public double ReadDouble(string key)
		{
			return double.Parse(m_Parameters[key]);
		}

		public string ReadString(string key)
		{
			return m_Parameters[key];
		}
		#endregion

		#region TryRead
		public bool TryRead(string key, IPairSerializable obj) 
		{
			IPairDeserializer deserializer = TryReadObject(key);
			if(deserializer != null)
			{
				obj.Deserialize(deserializer);
				return true;
			}
			return false;
		}

		public IPairDeserializer TryReadObject(string key)
		{
			JsonDeserializer deserializer;
			bool result = m_Objects.TryGetValue(key, out deserializer);
			return deserializer;
		}

		public bool TryReadBool(string key, bool defaultValue = false)
		{
			string rawData;
			bool data;
			if(!m_Parameters.TryGetValue(key, out rawData) || !bool.TryParse(rawData, out data))
			{
				return defaultValue;
			}
			return data;
		}

		public byte TryReadByte(string key, byte defaultValue = 0)
		{
			string rawData;
			byte data;
			if(!m_Parameters.TryGetValue(key, out rawData) || !byte.TryParse(rawData, out data))
			{
				return defaultValue;
			}
			return data;
		}

		public short TryReadShort(string key, short defaultValue = 0)
		{
			string rawData;
			short data;
			if(!m_Parameters.TryGetValue(key, out rawData) || !short.TryParse(rawData, out data))
			{
				return defaultValue;
			}
			return data;
		}

		public int TryReadInt(string key, int defaultValue = 0)
		{
			string rawData;
			int data;
			if(!m_Parameters.TryGetValue(key, out rawData) || !int.TryParse(rawData, out data))
			{
				return defaultValue;
			}
			return data;
		}

		public long TryReadLong(string key, long defaultValue = 0)
		{
			string rawData;
			long data;
			if(!m_Parameters.TryGetValue(key, out rawData) || !long.TryParse(rawData, out data))
			{
				return defaultValue;
			}
			return data;
		}

		public float TryReadFloat(string key, float defaultValue = 0)
		{
			string rawData;
			float data;
			if(!m_Parameters.TryGetValue(key, out rawData) || !float.TryParse(rawData, out data))
			{
				return defaultValue;
			}
			return data;
		}

		public double TryReadDouble(string key, double defaultValue = 0)
		{
			string rawData;
			double data;
			if(!m_Parameters.TryGetValue(key, out rawData) || !double.TryParse(rawData, out data))
			{
				return defaultValue;
			}
			return data;
		}

		public string TryReadString(string key, string defaultValue = null)
		{
			string data;
			if(!m_Parameters.TryGetValue(key, out data))
			{
				return defaultValue;
			}
			return data;
		}
		#endregion
	}
}
