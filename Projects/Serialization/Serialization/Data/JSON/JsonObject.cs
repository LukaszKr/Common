﻿using System.Collections.Generic;

namespace ProceduralLevel.Serialization.Json
{
	public partial class JsonObject: AObject
	{
		private Dictionary<string, AValue> m_Keys = new Dictionary<string, AValue>();

		public override int Count { get { return m_Keys.Count; } }

		public override void Clear()
		{
			m_Keys.Clear();
		}

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
		#endregion
	}
}
