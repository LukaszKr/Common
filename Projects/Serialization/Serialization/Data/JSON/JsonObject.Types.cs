namespace ProceduralLevel.Serialization.Json
{
    public partial class JsonObject
    {
		#region Write
		public override AObject Write(string key, bool data)
		{
			BoolValue value = new BoolValue(data);
			m_Keys.Add(key, value);
			return this;
		}

		public override AObject Write(string key, char data)
		{
			NumberValue value = new NumberValue(data.ToString());
			m_Keys.Add(key, value);
			return this;
		}

		public override AObject Write(string key, short data)
		{
			NumberValue value = new NumberValue(data.ToString());
			m_Keys.Add(key, value);
			return this;
		}

		public override AObject Write(string key, ushort data)
		{
			NumberValue value = new NumberValue(data.ToString());
			m_Keys.Add(key, value);
			return this;
		}

		public override AObject Write(string key, int data)
		{
			NumberValue value = new NumberValue(data.ToString());
			m_Keys.Add(key, value);
			return this;
		}

		public override AObject Write(string key, uint data)
		{
			NumberValue value = new NumberValue(data.ToString());
			m_Keys.Add(key, value);
			return this;
		}

		public override AObject Write(string key, long data)
		{
			NumberValue value = new NumberValue(data.ToString());
			m_Keys.Add(key, value);
			return this;
		}

		public override AObject Write(string key, ulong data)
		{
			NumberValue value = new NumberValue(data.ToString());
			m_Keys.Add(key, value);
			return this;
		}

		public override AObject Write(string key, float data)
		{
			NumberValue value = new NumberValue(data.ToString());
			m_Keys.Add(key, value);
			return this;
		}

		public override AObject Write(string key, double data)
		{
			NumberValue value = new NumberValue(data.ToString());
			m_Keys.Add(key, value);
			return this;
		}

		public override AObject Write(string key, string data)
		{
			StringValue value = new StringValue(data);
			m_Keys.Add(key, value);
			return this;
		}

		#endregion

		#region Read
		public override bool ReadBool(string key)
		{
			BoolValue value = m_Keys[key] as BoolValue;
			return value.Data;
		}

		public override char ReadChar(string key)
		{
			NumberValue value = m_Keys[key] as NumberValue;
			char data = char.Parse(value.Data);
			return data;
		}

		public override short ReadShort(string key)
		{
			NumberValue value = m_Keys[key] as NumberValue;
			short data = short.Parse(value.Data);
			return data;
		}

		public override ushort ReadUShort(string key)
		{
			NumberValue value = m_Keys[key] as NumberValue;
			ushort data = ushort.Parse(value.Data);
			return data;
		}

		public override int ReadInt(string key)
		{
			NumberValue value = m_Keys[key] as NumberValue;
			int data = int.Parse(value.Data);
			return data;
		}

		public override uint ReadUInt(string key)
		{
			NumberValue value = m_Keys[key] as NumberValue;
			uint data = uint.Parse(value.Data);
			return data;
		}

		public override long ReadLong(string key)
		{
			NumberValue value = m_Keys[key] as NumberValue;
			long data = long.Parse(value.Data);
			return data;
		}

		public override ulong ReadULong(string key)
		{
			NumberValue value = m_Keys[key] as NumberValue;
			ulong data = ulong.Parse(value.Data);
			return data;
		}

		public override float ReadFloat(string key)
		{
			NumberValue value = m_Keys[key] as NumberValue;
			float data = float.Parse(value.Data);
			return data;
		}

		public override double ReadDouble(string key)
		{
			NumberValue value = m_Keys[key] as NumberValue;
			double data = double.Parse(value.Data);
			return data;
		}

		public override string ReadString(string key)
		{
			StringValue value = m_Keys[key] as StringValue;
			return value.Data;
		}

		#endregion
    }
}
