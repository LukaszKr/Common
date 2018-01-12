using System.Collections.Generic;
using System.Text;

namespace ProceduralLevel.Common.Serialization.Json
{
	public partial class JsonObject: AObject
	{
		private Dictionary<string, AValue> m_Keys = new Dictionary<string, AValue>();

		public override int Count { get { return m_Keys.Count; } }

		public AValue this[string key]
		{
			get { return m_Keys[key]; }
			set { m_Keys[key] = value; }
		}

		public override void Clear()
		{
			m_Keys.Clear();
		}
		
		#region Equals
		public override bool Equals(object obj)
		{
			JsonObject other = obj as JsonObject;
			if(other == null)
			{
				return false;
			}

			if(Count != other.Count)
			{
				return false;
			}

			foreach(var pair in m_Keys)
			{
				if(!other[pair.Key].Equals(m_Keys[pair.Key]))
				{
					return false;
				}
			}
			return true;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
		#endregion

		public override string[] Keys()
		{
			string[] keys = new string[Count];
			m_Keys.Keys.CopyTo(keys, 0);
			return keys;
		}

		public override bool ContainsKey(string key)
		{
			return m_Keys.ContainsKey(key);
		}

		public override bool DeleteKey(string key)
		{
			return m_Keys.Remove(key);
		}


		#region Read && Write
		public void Write(string key, AValue value)
		{
			m_Keys[key] = value;
		}

		public override AObject WriteObject(string key)
		{
			JsonObject obj = new JsonObject();
			ObjectValue value = new ObjectValue(obj);
			m_Keys.Add(key, value);
			return obj;
		}

		public override AArray WriteArray(string key)
		{
			JsonArray array = new JsonArray();
			ArrayValue value = new ArrayValue(array);
			m_Keys.Add(key, value);
			return array;
		}

		public override AObject ReadObject(string key)
		{
			ObjectValue value = m_Keys[key] as ObjectValue;
			return value.Data;
		}

		public override AArray ReadArray(string key)
		{
			ArrayValue value = m_Keys[key] as ArrayValue;
			return value.Data;
		}

		public AValue ReadValue(string key)
		{
			return m_Keys[key];
		}

		public AValue TryReadValue(string key)
		{
			try
			{
				AValue value = ReadValue(key);
				return value;
			}
			catch { }
			return null;
		}
		#endregion

		public override string ToString()
		{
			return ToString(false);
		}

		public override string ToString(bool formatted)
		{
			StringBuilder sb = new StringBuilder();
			ToString(sb, formatted);
			return sb.ToString();
		}

		public void ToString(StringBuilder sb, bool formatted)
		{
			bool first = true;
			sb.Append(JsonConst.BRACES_OPEN);
			foreach(KeyValuePair<string, AValue> pair in m_Keys)
			{
				if(!first)
				{
					sb.Append(JsonConst.SEPARATOR);
				}
				pair.Value.ToString(sb, pair.Key, formatted);
				if(formatted)
				{
					sb.AppendLine();
				}
				first = false;
			}
			sb.Append(JsonConst.BRACES_CLOSE);
		}
	}
}
