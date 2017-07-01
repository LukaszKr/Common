namespace ProceduralLevel.Serialization.Json
{
    public partial class JsonArray
    {
		#region Write
		public override AArray Write(bool data)
		{
			BoolValue value = new BoolValue(data);
			m_Values.Add(value);
			return this;
		}

		public override AArray Write(char data)
		{
			NumberValue value = new NumberValue(data.ToString());
			m_Values.Add(value);
			return this;
		}

		public override AArray Write(short data)
		{
			NumberValue value = new NumberValue(data.ToString());
			m_Values.Add(value);
			return this;
		}

		public override AArray Write(ushort data)
		{
			NumberValue value = new NumberValue(data.ToString());
			m_Values.Add(value);
			return this;
		}

		public override AArray Write(int data)
		{
			NumberValue value = new NumberValue(data.ToString());
			m_Values.Add(value);
			return this;
		}

		public override AArray Write(uint data)
		{
			NumberValue value = new NumberValue(data.ToString());
			m_Values.Add(value);
			return this;
		}

		public override AArray Write(long data)
		{
			NumberValue value = new NumberValue(data.ToString());
			m_Values.Add(value);
			return this;
		}

		public override AArray Write(ulong data)
		{
			NumberValue value = new NumberValue(data.ToString());
			m_Values.Add(value);
			return this;
		}

		public override AArray Write(float data)
		{
			NumberValue value = new NumberValue(data.ToString());
			m_Values.Add(value);
			return this;
		}

		public override AArray Write(double data)
		{
			NumberValue value = new NumberValue(data.ToString());
			m_Values.Add(value);
			return this;
		}

		public override AArray Write(string data)
		{
			StringValue value = new StringValue(data);
			m_Values.Add(value);
			return this;
		}

		#endregion

		#region Read
		public override bool ReadBool(int index)
		{
			BoolValue value = m_Values[index] as BoolValue;
			return value.Data;
		}

		public override char ReadChar(int index)
		{
			NumberValue value = m_Values[index] as NumberValue;
			char data = char.Parse(value.Data);
			return data;
		}

		public override short ReadShort(int index)
		{
			NumberValue value = m_Values[index] as NumberValue;
			short data = short.Parse(value.Data);
			return data;
		}

		public override ushort ReadUShort(int index)
		{
			NumberValue value = m_Values[index] as NumberValue;
			ushort data = ushort.Parse(value.Data);
			return data;
		}

		public override int ReadInt(int index)
		{
			NumberValue value = m_Values[index] as NumberValue;
			int data = int.Parse(value.Data);
			return data;
		}

		public override uint ReadUInt(int index)
		{
			NumberValue value = m_Values[index] as NumberValue;
			uint data = uint.Parse(value.Data);
			return data;
		}

		public override long ReadLong(int index)
		{
			NumberValue value = m_Values[index] as NumberValue;
			long data = long.Parse(value.Data);
			return data;
		}

		public override ulong ReadULong(int index)
		{
			NumberValue value = m_Values[index] as NumberValue;
			ulong data = ulong.Parse(value.Data);
			return data;
		}

		public override float ReadFloat(int index)
		{
			NumberValue value = m_Values[index] as NumberValue;
			float data = float.Parse(value.Data);
			return data;
		}

		public override double ReadDouble(int index)
		{
			NumberValue value = m_Values[index] as NumberValue;
			double data = double.Parse(value.Data);
			return data;
		}

		public override string ReadString(int index)
		{
			StringValue value = m_Values[index] as StringValue;
			return value.Data;
		}

		#endregion
    }
}
