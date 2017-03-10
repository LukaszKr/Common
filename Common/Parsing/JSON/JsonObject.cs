﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ProceduralLevel.Common.Parsing
{
	public class JsonObject: IEquatable<JsonObject>
    {
		private const string STRING_FORMAT = "{0}{1}{0}";
		private const string PAIR_FORMAT = "{0}{1}{0}{2}{3}";
		private const string NULL_VALUE = "null";

		public Dictionary<string, object> Params { get; private set; }
		public Dictionary<string, JsonObject> Objects { get; private set; }
		public Dictionary<string, JsonArray> Arrays { get; private set; }

		public JsonObject()
		{
			Params = new Dictionary<string, object>();
			Objects = new Dictionary<string, JsonObject>();
			Arrays = new Dictionary<string, JsonArray>();
		}

		public string[] Keys()
		{
			int count = Params.Keys.Count + Objects.Keys.Count + Arrays.Keys.Count;
			string[] keys = new string[count];
			int offset = 0;
			foreach(string key in Params.Keys)
			{
				keys[offset] = key;
				offset++;
			}
			foreach(string key in Objects.Keys)
			{
				keys[offset] = key;
				offset++;
			}
			foreach(string key in Arrays.Keys)
			{
				keys[offset] = key;
				offset++;
			}
			return keys;
		}

        public bool Equals(JsonObject obj)
        {
            if(Params.Count != obj.Params.Count
                || Objects.Count != obj.Objects.Count
                || Arrays.Count != obj.Arrays.Count)
            {
                return false;
            }

            object compared;
            foreach(var pair in Params)
            {
                if(!obj.Params.TryGetValue(pair.Key, out compared) || !compared.Equals(pair.Value))
                {
                    return false;
                }
            }

            JsonObject jsonCompared;
            foreach(var pair in Objects)
            {
                if(!obj.Objects.TryGetValue(pair.Key, out jsonCompared) || !jsonCompared.Equals(pair.Value))
                {
                    return false;
                }
            }

            JsonArray arrayCompared;
            foreach(var pair in Arrays)
            {
                if(!obj.Arrays.TryGetValue(pair.Key, out arrayCompared) || !arrayCompared.Equals(pair.Value))
                {
                    return false;
                }
            }

            return true;
        }

        public override string ToString()
		{
			StringBuilder builder = new StringBuilder();
			builder.Append(JsonConst.BRACKETS_OPEN);
#if SIMPLE_FORMAT
			builder.Append("\n");
#endif

			int toWrite = Params.Count+Objects.Count+Arrays.Count;
			int written = 0;
			foreach(var pair in Params)
			{
				WritePairs(builder, pair.Key, pair.Value, ref written, toWrite);
			}

			foreach(var pair in Objects)
			{
				WritePairs(builder, pair.Key, pair.Value, ref written, toWrite);
			}

			foreach(var pair in Arrays)
			{
				WritePairs(builder, pair.Key, pair.Value, ref written, toWrite);
			}

			builder.Append(JsonConst.BRACKETS_CLOSE);
			return builder.ToString();
		}

		private void WritePairs(StringBuilder builder, string key, object value, ref int written, int toWrite)
		{
            string strValue;
            if(value is double)
            {
                strValue = ((double)value).ToString(CultureInfo.InvariantCulture);
            }
            else if(value is bool)
            {
                strValue = ((bool)value).ToString().ToLower();
            }
			else if(value is string)
			{
				strValue = string.Format(STRING_FORMAT, JsonConst.QUOTATION, JsonConst.EscapeString(value.ToString()));
			}
            else
            {
				if(value != null)
				{
					strValue = value.ToString();
				}
				else
				{
					strValue = NULL_VALUE;
				}
			}
			builder.AppendFormat(PAIR_FORMAT,
				JsonConst.QUOTATION, key, JsonConst.KEY_VALUE_SEPARATOR, strValue);
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
			Params[key] = param;
		}

		public void Write(string key, byte param)
		{
			Params[key] = param;
		}

		public void Write(string key, short param)
		{
			Params[key] = param;
		}

		public void Write(string key, int param)
		{
			Params[key] = param;
		}

		public void Write(string key, long param)
		{
			Params[key] = param;
		}

		public void Write(string key, float param)
		{
			Params[key] = param;
		}

		public void Write(string key, double param)
		{
			Params[key] = param;
		}

		public void Write(string key, string str)
		{
			Params[key] = str;
		}

		public void Write(string key, JsonObject obj)
		{
			Objects[key] = obj;
		}

		public void Write(string key, JsonArray array)
		{
			Arrays[key] = array;
		}

		public void WriteObject(string key, object obj)
		{
			if(obj == null)
			{
				Params[key] = null;
				return;
			}

			JsonObject jsonObj = obj as JsonObject;
			if(jsonObj != null)
			{
				Write(key, jsonObj);
				return;
			}

			JsonArray jsonArr = obj as JsonArray;
			if(jsonArr != null)
			{
				Write(key, jsonArr);
				return;
			}

			Params[key] = obj;
		}

		#region Read
		public bool ReadBool(string key)
		{
			return (bool)Params[key];
		}

		public byte ReadByte(string key)
		{
			return Convert.ToByte(Params[key]);
		}

		public short ReadShort(string key)
		{
			return Convert.ToInt16(Params[key]);
		}

		public int ReadInt(string key)
		{
			return Convert.ToInt32(Params[key]);
		}

		public long ReadLong(string key)
		{
			return Convert.ToInt64(Params[key]);
		}

		public float ReadFloat(string key)
		{
			return (float)ReadDouble(key);
		}

		public double ReadDouble(string key)
		{
			return (double)Params[key];
		}

		public string ReadString(string key)
		{
			return (string)Params[key];
		}

		public JsonObject ReadObject(string key)
		{
			return Objects[key];
		}

		public JsonArray ReadArray(string key)
		{
			return Arrays[key];
		}
		#endregion

		#region TryRead
		public bool TryReadBool(string key, bool defaultValue = false)
		{
			object value;
			if(Params.TryGetValue(key, out value))
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
			if(Params.TryGetValue(key, out value))
			{
				return (double)value;
			}
			return defaultValue;
		}

		public string TryReadString(string key, string defaultValue = "")
		{
			object value;
			if(Params.TryGetValue(key, out value))
			{
				return (string)value;
			}
			return defaultValue;
		}

		public JsonObject TryReadObject(string key)
		{
			JsonObject obj;
			Objects.TryGetValue(key, out obj);
			return obj;
		}

		public JsonArray TryReadArray(string key)
		{
			JsonArray array;
			Arrays.TryGetValue(key, out array);
			return array;
		}

		public object TryRead(string key)
		{
			object result;
			if(Params.TryGetValue(key, out result))
			{
				return result;
			}
			JsonObject obj;
			if(Objects.TryGetValue(key, out obj))
			{
				return obj;
			}
			JsonArray arr;
			if(Arrays.TryGetValue(key, out arr))
			{
				return arr;
			}
			return null;
		}
		#endregion
	}
}
