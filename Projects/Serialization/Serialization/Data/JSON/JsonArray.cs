using System.Collections.Generic;

namespace ProceduralLevel.Serialization.Json
{
	public partial class JsonArray: AArray
	{
		private List<AValue> m_Values = new List<AValue>();

		public override int Count { get { return m_Values.Count; } }

		public override void Clear()
		{
			base.Clear();
			m_Values.Clear();
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
	}
}
