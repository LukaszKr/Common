namespace ProceduralLevel.Serialization
{
    public partial class AArray
    {
		#region Write
		public abstract AArray Write(bool data);
		public abstract AArray Write(char data);
		public abstract AArray Write(short data);
		public abstract AArray Write(ushort data);
		public abstract AArray Write(int data);
		public abstract AArray Write(uint data);
		public abstract AArray Write(long data);
		public abstract AArray Write(ulong data);
		public abstract AArray Write(float data);
		public abstract AArray Write(double data);
		public abstract AArray Write(string data);
		#endregion

		#region Read
		public bool ReadBool()
		{
			bool value = ReadBool(m_Index++);
			return value;
		}

		public char ReadChar()
		{
			char value = ReadChar(m_Index++);
			return value;
		}

		public short ReadShort()
		{
			short value = ReadShort(m_Index++);
			return value;
		}

		public ushort ReadUShort()
		{
			ushort value = ReadUShort(m_Index++);
			return value;
		}

		public int ReadInt()
		{
			int value = ReadInt(m_Index++);
			return value;
		}

		public uint ReadUInt()
		{
			uint value = ReadUInt(m_Index++);
			return value;
		}

		public long ReadLong()
		{
			long value = ReadLong(m_Index++);
			return value;
		}

		public ulong ReadULong()
		{
			ulong value = ReadULong(m_Index++);
			return value;
		}

		public float ReadFloat()
		{
			float value = ReadFloat(m_Index++);
			return value;
		}

		public double ReadDouble()
		{
			double value = ReadDouble(m_Index++);
			return value;
		}

		public string ReadString()
		{
			string value = ReadString(m_Index++);
			return value;
		}

		#endregion

		#region Read Indexed
		public abstract bool ReadBool(int index);
		public abstract char ReadChar(int index);
		public abstract short ReadShort(int index);
		public abstract ushort ReadUShort(int index);
		public abstract int ReadInt(int index);
		public abstract uint ReadUInt(int index);
		public abstract long ReadLong(int index);
		public abstract ulong ReadULong(int index);
		public abstract float ReadFloat(int index);
		public abstract double ReadDouble(int index);
		public abstract string ReadString(int index);
		#endregion
    }
}
