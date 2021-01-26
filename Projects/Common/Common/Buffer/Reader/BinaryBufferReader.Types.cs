using System.Collections.Generic;

namespace ProceduralLevel.Common.Buffer
{
	public partial class BinaryBufferReader
	{
		#region Char
		public void Read(List<char> list, bool append = false)
		{
			if(!append)
			{
				list.Clear();
			}
			int count = ReadInt();
			for(int x = 0; x < count; ++x)
			{
				list.Add(ReadChar());
			}
		}

		public int Read(char[] arr, int offset = 0)
		{
			int length = ReadInt();
			for(int x = 0; x < length; ++x)
			{
				arr[x+offset] = ReadChar();
			}
			return length;
		}

		public char[] ReadCharArray()
		{
			int length = ReadInt();
			char[] arr = new char[length];
			for(int x = 0; x < length; ++x)
			{
				arr[x] = ReadChar();
			}
			return arr;
		}
		#endregion 

		#region Bool
		public void Read(List<bool> list, bool append = false)
		{
			if(!append)
			{
				list.Clear();
			}
			int count = ReadInt();
			for(int x = 0; x < count; ++x)
			{
				list.Add(ReadBool());
			}
		}

		public int Read(bool[] arr, int offset = 0)
		{
			int length = ReadInt();
			for(int x = 0; x < length; ++x)
			{
				arr[x+offset] = ReadBool();
			}
			return length;
		}

		public bool[] ReadBoolArray()
		{
			int length = ReadInt();
			bool[] arr = new bool[length];
			for(int x = 0; x < length; ++x)
			{
				arr[x] = ReadBool();
			}
			return arr;
		}
		#endregion 

		#region Byte
		public void Read(List<byte> list, bool append = false)
		{
			if(!append)
			{
				list.Clear();
			}
			int count = ReadInt();
			for(int x = 0; x < count; ++x)
			{
				list.Add(ReadByte());
			}
		}

		public int Read(byte[] arr, int offset = 0)
		{
			int length = ReadInt();
			for(int x = 0; x < length; ++x)
			{
				arr[x+offset] = ReadByte();
			}
			return length;
		}

		public byte[] ReadByteArray()
		{
			int length = ReadInt();
			byte[] arr = new byte[length];
			for(int x = 0; x < length; ++x)
			{
				arr[x] = ReadByte();
			}
			return arr;
		}
		#endregion 

		#region Short
		public void Read(List<short> list, bool append = false)
		{
			if(!append)
			{
				list.Clear();
			}
			int count = ReadInt();
			for(int x = 0; x < count; ++x)
			{
				list.Add(ReadShort());
			}
		}

		public int Read(short[] arr, int offset = 0)
		{
			int length = ReadInt();
			for(int x = 0; x < length; ++x)
			{
				arr[x+offset] = ReadShort();
			}
			return length;
		}

		public short[] ReadShortArray()
		{
			int length = ReadInt();
			short[] arr = new short[length];
			for(int x = 0; x < length; ++x)
			{
				arr[x] = ReadShort();
			}
			return arr;
		}
		#endregion 

		#region UShort
		public void Read(List<ushort> list, bool append = false)
		{
			if(!append)
			{
				list.Clear();
			}
			int count = ReadInt();
			for(int x = 0; x < count; ++x)
			{
				list.Add(ReadUShort());
			}
		}

		public int Read(ushort[] arr, int offset = 0)
		{
			int length = ReadInt();
			for(int x = 0; x < length; ++x)
			{
				arr[x+offset] = ReadUShort();
			}
			return length;
		}

		public ushort[] ReadUShortArray()
		{
			int length = ReadInt();
			ushort[] arr = new ushort[length];
			for(int x = 0; x < length; ++x)
			{
				arr[x] = ReadUShort();
			}
			return arr;
		}
		#endregion 

		#region Int
		public void Read(List<int> list, bool append = false)
		{
			if(!append)
			{
				list.Clear();
			}
			int count = ReadInt();
			for(int x = 0; x < count; ++x)
			{
				list.Add(ReadInt());
			}
		}

		public int Read(int[] arr, int offset = 0)
		{
			int length = ReadInt();
			for(int x = 0; x < length; ++x)
			{
				arr[x+offset] = ReadInt();
			}
			return length;
		}

		public int[] ReadIntArray()
		{
			int length = ReadInt();
			int[] arr = new int[length];
			for(int x = 0; x < length; ++x)
			{
				arr[x] = ReadInt();
			}
			return arr;
		}
		#endregion 

		#region UInt
		public void Read(List<uint> list, bool append = false)
		{
			if(!append)
			{
				list.Clear();
			}
			int count = ReadInt();
			for(int x = 0; x < count; ++x)
			{
				list.Add(ReadUInt());
			}
		}

		public int Read(uint[] arr, int offset = 0)
		{
			int length = ReadInt();
			for(int x = 0; x < length; ++x)
			{
				arr[x+offset] = ReadUInt();
			}
			return length;
		}

		public uint[] ReadUIntArray()
		{
			int length = ReadInt();
			uint[] arr = new uint[length];
			for(int x = 0; x < length; ++x)
			{
				arr[x] = ReadUInt();
			}
			return arr;
		}
		#endregion 

		#region Long
		public void Read(List<long> list, bool append = false)
		{
			if(!append)
			{
				list.Clear();
			}
			int count = ReadInt();
			for(int x = 0; x < count; ++x)
			{
				list.Add(ReadLong());
			}
		}

		public int Read(long[] arr, int offset = 0)
		{
			int length = ReadInt();
			for(int x = 0; x < length; ++x)
			{
				arr[x+offset] = ReadLong();
			}
			return length;
		}

		public long[] ReadLongArray()
		{
			int length = ReadInt();
			long[] arr = new long[length];
			for(int x = 0; x < length; ++x)
			{
				arr[x] = ReadLong();
			}
			return arr;
		}
		#endregion 

		#region ULong
		public void Read(List<ulong> list, bool append = false)
		{
			if(!append)
			{
				list.Clear();
			}
			int count = ReadInt();
			for(int x = 0; x < count; ++x)
			{
				list.Add(ReadULong());
			}
		}

		public int Read(ulong[] arr, int offset = 0)
		{
			int length = ReadInt();
			for(int x = 0; x < length; ++x)
			{
				arr[x+offset] = ReadULong();
			}
			return length;
		}

		public ulong[] ReadULongArray()
		{
			int length = ReadInt();
			ulong[] arr = new ulong[length];
			for(int x = 0; x < length; ++x)
			{
				arr[x] = ReadULong();
			}
			return arr;
		}
		#endregion 

		#region String
		public void Read(List<string> list, bool append = false)
		{
			if(!append)
			{
				list.Clear();
			}
			int count = ReadInt();
			for(int x = 0; x < count; ++x)
			{
				list.Add(ReadString());
			}
		}

		public int Read(string[] arr, int offset = 0)
		{
			int length = ReadInt();
			for(int x = 0; x < length; ++x)
			{
				arr[x+offset] = ReadString();
			}
			return length;
		}

		public string[] ReadStringArray()
		{
			int length = ReadInt();
			string[] arr = new string[length];
			for(int x = 0; x < length; ++x)
			{
				arr[x] = ReadString();
			}
			return arr;
		}
		#endregion 

		#region Float
		public void Read(List<float> list, bool append = false)
		{
			if(!append)
			{
				list.Clear();
			}
			int count = ReadInt();
			for(int x = 0; x < count; ++x)
			{
				list.Add(ReadFloat());
			}
		}

		public int Read(float[] arr, int offset = 0)
		{
			int length = ReadInt();
			for(int x = 0; x < length; ++x)
			{
				arr[x+offset] = ReadFloat();
			}
			return length;
		}

		public float[] ReadFloatArray()
		{
			int length = ReadInt();
			float[] arr = new float[length];
			for(int x = 0; x < length; ++x)
			{
				arr[x] = ReadFloat();
			}
			return arr;
		}
		#endregion 

		#region Double
		public void Read(List<double> list, bool append = false)
		{
			if(!append)
			{
				list.Clear();
			}
			int count = ReadInt();
			for(int x = 0; x < count; ++x)
			{
				list.Add(ReadDouble());
			}
		}

		public int Read(double[] arr, int offset = 0)
		{
			int length = ReadInt();
			for(int x = 0; x < length; ++x)
			{
				arr[x+offset] = ReadDouble();
			}
			return length;
		}

		public double[] ReadDoubleArray()
		{
			int length = ReadInt();
			double[] arr = new double[length];
			for(int x = 0; x < length; ++x)
			{
				arr[x] = ReadDouble();
			}
			return arr;
		}
		#endregion 

	}
}
