using System.Collections.Generic;
using System.Text;

namespace ProceduralLevel.Serialization.Json
{
	public partial class JsonArray: AArray
	{
		private List<AValue> m_Values = new List<AValue>();

		public override int Count { get { return m_Values.Count; } }

		public AValue this[int index]
		{
			get { return m_Values[index]; }
			set { m_Values[index] = value; }
		}

		public override void Clear()
		{
			base.Clear();
			m_Values.Clear();
		}

		#region Equals
		public override bool Equals(object obj)
		{
			JsonArray other = obj as JsonArray;
			if(other == null)
			{
				return false;
			}

			if(Count != other.Count)
			{
				return false;
			}

			for(int x = 0; x < m_Values.Count; x++)
			{
				if(!other[x].Equals(m_Values[x]))
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

		public void Write(AValue data)
		{
			m_Values.Add(data);
		}

		public override AObject WriteObject()
		{
			JsonObject obj = new JsonObject();
			ObjectValue value = new ObjectValue(obj);
			m_Values.Add(value);
			return obj;
		}

		public override AArray WriteArray()
		{
			JsonArray arr = new JsonArray();
			ArrayValue value = new ArrayValue(arr);
			m_Values.Add(value);
			return arr;
		}

		public override AObject ReadObject()
		{
			return ReadObject(m_Index++);
		}

		public override AArray ReadArray()
		{
			return ReadArray(m_Index++);
		}

		public override AObject ReadObject(int index)
		{
			ObjectValue value = m_Values[index] as ObjectValue;
			return value.Data;
		}

		public override AArray ReadArray(int index)
		{
			ArrayValue value = m_Values[index] as ArrayValue;
			return value.Data;
		}

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
			sb.Append(JsonConst.ARRAY_OPEN);
			for(int x = 0; x < m_Values.Count; x++)
			{
				AValue value = m_Values[x];
				if(x > 0)
				{
					sb.Append(JsonConst.SEPARATOR);
				}
				value.ToString(sb, formatted);
				if(formatted)
				{
					sb.AppendLine();
				}
			}
			sb.Append(JsonConst.ARRAY_CLOSE);
		}
	}
}
