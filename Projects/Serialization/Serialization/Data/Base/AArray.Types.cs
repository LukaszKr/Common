using System.Collections.Generic;

namespace ProceduralLevel.Common.Serialization
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

		#region Write Array
		public AArray Write(bool[] data)
		{
			AArray arr = WriteArray();
			for(int x = 0; x < data.Length; ++x)
			{
				arr.Write(data[x]);
			}
			return this;
		}

		public AArray Write(char[] data)
		{
			AArray arr = WriteArray();
			for(int x = 0; x < data.Length; ++x)
			{
				arr.Write(data[x]);
			}
			return this;
		}

		public AArray Write(short[] data)
		{
			AArray arr = WriteArray();
			for(int x = 0; x < data.Length; ++x)
			{
				arr.Write(data[x]);
			}
			return this;
		}

		public AArray Write(ushort[] data)
		{
			AArray arr = WriteArray();
			for(int x = 0; x < data.Length; ++x)
			{
				arr.Write(data[x]);
			}
			return this;
		}

		public AArray Write(int[] data)
		{
			AArray arr = WriteArray();
			for(int x = 0; x < data.Length; ++x)
			{
				arr.Write(data[x]);
			}
			return this;
		}

		public AArray Write(uint[] data)
		{
			AArray arr = WriteArray();
			for(int x = 0; x < data.Length; ++x)
			{
				arr.Write(data[x]);
			}
			return this;
		}

		public AArray Write(long[] data)
		{
			AArray arr = WriteArray();
			for(int x = 0; x < data.Length; ++x)
			{
				arr.Write(data[x]);
			}
			return this;
		}

		public AArray Write(ulong[] data)
		{
			AArray arr = WriteArray();
			for(int x = 0; x < data.Length; ++x)
			{
				arr.Write(data[x]);
			}
			return this;
		}

		public AArray Write(float[] data)
		{
			AArray arr = WriteArray();
			for(int x = 0; x < data.Length; ++x)
			{
				arr.Write(data[x]);
			}
			return this;
		}

		public AArray Write(double[] data)
		{
			AArray arr = WriteArray();
			for(int x = 0; x < data.Length; ++x)
			{
				arr.Write(data[x]);
			}
			return this;
		}

		public AArray Write(string[] data)
		{
			AArray arr = WriteArray();
			for(int x = 0; x < data.Length; ++x)
			{
				arr.Write(data[x]);
			}
			return this;
		}

		#endregion

		#region Write Collection
		public AArray Write(ICollection<bool> data)
		{
			AArray arr = WriteArray();
			foreach(bool item in data)
			{
				arr.Write(item);
			}
			return this;
		}

		public AArray Write(ICollection<char> data)
		{
			AArray arr = WriteArray();
			foreach(char item in data)
			{
				arr.Write(item);
			}
			return this;
		}

		public AArray Write(ICollection<short> data)
		{
			AArray arr = WriteArray();
			foreach(short item in data)
			{
				arr.Write(item);
			}
			return this;
		}

		public AArray Write(ICollection<ushort> data)
		{
			AArray arr = WriteArray();
			foreach(ushort item in data)
			{
				arr.Write(item);
			}
			return this;
		}

		public AArray Write(ICollection<int> data)
		{
			AArray arr = WriteArray();
			foreach(int item in data)
			{
				arr.Write(item);
			}
			return this;
		}

		public AArray Write(ICollection<uint> data)
		{
			AArray arr = WriteArray();
			foreach(uint item in data)
			{
				arr.Write(item);
			}
			return this;
		}

		public AArray Write(ICollection<long> data)
		{
			AArray arr = WriteArray();
			foreach(long item in data)
			{
				arr.Write(item);
			}
			return this;
		}

		public AArray Write(ICollection<ulong> data)
		{
			AArray arr = WriteArray();
			foreach(ulong item in data)
			{
				arr.Write(item);
			}
			return this;
		}

		public AArray Write(ICollection<float> data)
		{
			AArray arr = WriteArray();
			foreach(float item in data)
			{
				arr.Write(item);
			}
			return this;
		}

		public AArray Write(ICollection<double> data)
		{
			AArray arr = WriteArray();
			foreach(double item in data)
			{
				arr.Write(item);
			}
			return this;
		}

		public AArray Write(ICollection<string> data)
		{
			AArray arr = WriteArray();
			foreach(string item in data)
			{
				arr.Write(item);
			}
			return this;
		}

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

		#region Read Array
		public bool[] ReadBoolArray()
		{
			AArray arr = ReadArray();
			int count = arr.Count;
			bool[] data = new bool[count];
			for(int x = 0; x < count; ++x)
			{
				data[x] = arr.ReadBool();
			}
			return data;
		}

		public char[] ReadCharArray()
		{
			AArray arr = ReadArray();
			int count = arr.Count;
			char[] data = new char[count];
			for(int x = 0; x < count; ++x)
			{
				data[x] = arr.ReadChar();
			}
			return data;
		}

		public short[] ReadShortArray()
		{
			AArray arr = ReadArray();
			int count = arr.Count;
			short[] data = new short[count];
			for(int x = 0; x < count; ++x)
			{
				data[x] = arr.ReadShort();
			}
			return data;
		}

		public ushort[] ReadUShortArray()
		{
			AArray arr = ReadArray();
			int count = arr.Count;
			ushort[] data = new ushort[count];
			for(int x = 0; x < count; ++x)
			{
				data[x] = arr.ReadUShort();
			}
			return data;
		}

		public int[] ReadIntArray()
		{
			AArray arr = ReadArray();
			int count = arr.Count;
			int[] data = new int[count];
			for(int x = 0; x < count; ++x)
			{
				data[x] = arr.ReadInt();
			}
			return data;
		}

		public uint[] ReadUIntArray()
		{
			AArray arr = ReadArray();
			int count = arr.Count;
			uint[] data = new uint[count];
			for(int x = 0; x < count; ++x)
			{
				data[x] = arr.ReadUInt();
			}
			return data;
		}

		public long[] ReadLongArray()
		{
			AArray arr = ReadArray();
			int count = arr.Count;
			long[] data = new long[count];
			for(int x = 0; x < count; ++x)
			{
				data[x] = arr.ReadLong();
			}
			return data;
		}

		public ulong[] ReadULongArray()
		{
			AArray arr = ReadArray();
			int count = arr.Count;
			ulong[] data = new ulong[count];
			for(int x = 0; x < count; ++x)
			{
				data[x] = arr.ReadULong();
			}
			return data;
		}

		public float[] ReadFloatArray()
		{
			AArray arr = ReadArray();
			int count = arr.Count;
			float[] data = new float[count];
			for(int x = 0; x < count; ++x)
			{
				data[x] = arr.ReadFloat();
			}
			return data;
		}

		public double[] ReadDoubleArray()
		{
			AArray arr = ReadArray();
			int count = arr.Count;
			double[] data = new double[count];
			for(int x = 0; x < count; ++x)
			{
				data[x] = arr.ReadDouble();
			}
			return data;
		}

		public string[] ReadStringArray()
		{
			AArray arr = ReadArray();
			int count = arr.Count;
			string[] data = new string[count];
			for(int x = 0; x < count; ++x)
			{
				data[x] = arr.ReadString();
			}
			return data;
		}

		#endregion

		#region Read Collection
		public void Read(ICollection<bool> data)
		{
			AArray arr = ReadArray();
			int count = arr.Count;
			for(int x = 0; x < count; ++x)
			{
				data.Add(arr.ReadBool());
			}
		}

		public void Read(ICollection<char> data)
		{
			AArray arr = ReadArray();
			int count = arr.Count;
			for(int x = 0; x < count; ++x)
			{
				data.Add(arr.ReadChar());
			}
		}

		public void Read(ICollection<short> data)
		{
			AArray arr = ReadArray();
			int count = arr.Count;
			for(int x = 0; x < count; ++x)
			{
				data.Add(arr.ReadShort());
			}
		}

		public void Read(ICollection<ushort> data)
		{
			AArray arr = ReadArray();
			int count = arr.Count;
			for(int x = 0; x < count; ++x)
			{
				data.Add(arr.ReadUShort());
			}
		}

		public void Read(ICollection<int> data)
		{
			AArray arr = ReadArray();
			int count = arr.Count;
			for(int x = 0; x < count; ++x)
			{
				data.Add(arr.ReadInt());
			}
		}

		public void Read(ICollection<uint> data)
		{
			AArray arr = ReadArray();
			int count = arr.Count;
			for(int x = 0; x < count; ++x)
			{
				data.Add(arr.ReadUInt());
			}
		}

		public void Read(ICollection<long> data)
		{
			AArray arr = ReadArray();
			int count = arr.Count;
			for(int x = 0; x < count; ++x)
			{
				data.Add(arr.ReadLong());
			}
		}

		public void Read(ICollection<ulong> data)
		{
			AArray arr = ReadArray();
			int count = arr.Count;
			for(int x = 0; x < count; ++x)
			{
				data.Add(arr.ReadULong());
			}
		}

		public void Read(ICollection<float> data)
		{
			AArray arr = ReadArray();
			int count = arr.Count;
			for(int x = 0; x < count; ++x)
			{
				data.Add(arr.ReadFloat());
			}
		}

		public void Read(ICollection<double> data)
		{
			AArray arr = ReadArray();
			int count = arr.Count;
			for(int x = 0; x < count; ++x)
			{
				data.Add(arr.ReadDouble());
			}
		}

		public void Read(ICollection<string> data)
		{
			AArray arr = ReadArray();
			int count = arr.Count;
			for(int x = 0; x < count; ++x)
			{
				data.Add(arr.ReadString());
			}
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
