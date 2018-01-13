using System.Collections.Generic;

namespace ProceduralLevel.Common.Serialization
{
    public partial class AObject
    {
		#region Write
		public abstract AObject Write(string key, bool data);
		public abstract AObject Write(string key, char data);
		public abstract AObject Write(string key, short data);
		public abstract AObject Write(string key, ushort data);
		public abstract AObject Write(string key, int data);
		public abstract AObject Write(string key, uint data);
		public abstract AObject Write(string key, long data);
		public abstract AObject Write(string key, ulong data);
		public abstract AObject Write(string key, float data);
		public abstract AObject Write(string key, double data);
		public abstract AObject Write(string key, string data);
		#endregion

		#region Write Array
		public AObject Write(string key, bool[] data)
		{
			AArray arr = WriteArray(key);
			for(int x = 0; x < data.Length; ++x)
			{
				arr.Write(data[x]);
			}
			return this;
		}

		public AObject Write(string key, char[] data)
		{
			AArray arr = WriteArray(key);
			for(int x = 0; x < data.Length; ++x)
			{
				arr.Write(data[x]);
			}
			return this;
		}

		public AObject Write(string key, short[] data)
		{
			AArray arr = WriteArray(key);
			for(int x = 0; x < data.Length; ++x)
			{
				arr.Write(data[x]);
			}
			return this;
		}

		public AObject Write(string key, ushort[] data)
		{
			AArray arr = WriteArray(key);
			for(int x = 0; x < data.Length; ++x)
			{
				arr.Write(data[x]);
			}
			return this;
		}

		public AObject Write(string key, int[] data)
		{
			AArray arr = WriteArray(key);
			for(int x = 0; x < data.Length; ++x)
			{
				arr.Write(data[x]);
			}
			return this;
		}

		public AObject Write(string key, uint[] data)
		{
			AArray arr = WriteArray(key);
			for(int x = 0; x < data.Length; ++x)
			{
				arr.Write(data[x]);
			}
			return this;
		}

		public AObject Write(string key, long[] data)
		{
			AArray arr = WriteArray(key);
			for(int x = 0; x < data.Length; ++x)
			{
				arr.Write(data[x]);
			}
			return this;
		}

		public AObject Write(string key, ulong[] data)
		{
			AArray arr = WriteArray(key);
			for(int x = 0; x < data.Length; ++x)
			{
				arr.Write(data[x]);
			}
			return this;
		}

		public AObject Write(string key, float[] data)
		{
			AArray arr = WriteArray(key);
			for(int x = 0; x < data.Length; ++x)
			{
				arr.Write(data[x]);
			}
			return this;
		}

		public AObject Write(string key, double[] data)
		{
			AArray arr = WriteArray(key);
			for(int x = 0; x < data.Length; ++x)
			{
				arr.Write(data[x]);
			}
			return this;
		}

		public AObject Write(string key, string[] data)
		{
			AArray arr = WriteArray(key);
			for(int x = 0; x < data.Length; ++x)
			{
				arr.Write(data[x]);
			}
			return this;
		}

		#endregion

		#region Write Collection
		public AObject Write(string key, ICollection<bool> data)
		{
			AArray arr = WriteArray(key);
			foreach(bool item in data)
			{
				arr.Write(item);
			}
			return this;
		}

		public AObject Write(string key, ICollection<char> data)
		{
			AArray arr = WriteArray(key);
			foreach(char item in data)
			{
				arr.Write(item);
			}
			return this;
		}

		public AObject Write(string key, ICollection<short> data)
		{
			AArray arr = WriteArray(key);
			foreach(short item in data)
			{
				arr.Write(item);
			}
			return this;
		}

		public AObject Write(string key, ICollection<ushort> data)
		{
			AArray arr = WriteArray(key);
			foreach(ushort item in data)
			{
				arr.Write(item);
			}
			return this;
		}

		public AObject Write(string key, ICollection<int> data)
		{
			AArray arr = WriteArray(key);
			foreach(int item in data)
			{
				arr.Write(item);
			}
			return this;
		}

		public AObject Write(string key, ICollection<uint> data)
		{
			AArray arr = WriteArray(key);
			foreach(uint item in data)
			{
				arr.Write(item);
			}
			return this;
		}

		public AObject Write(string key, ICollection<long> data)
		{
			AArray arr = WriteArray(key);
			foreach(long item in data)
			{
				arr.Write(item);
			}
			return this;
		}

		public AObject Write(string key, ICollection<ulong> data)
		{
			AArray arr = WriteArray(key);
			foreach(ulong item in data)
			{
				arr.Write(item);
			}
			return this;
		}

		public AObject Write(string key, ICollection<float> data)
		{
			AArray arr = WriteArray(key);
			foreach(float item in data)
			{
				arr.Write(item);
			}
			return this;
		}

		public AObject Write(string key, ICollection<double> data)
		{
			AArray arr = WriteArray(key);
			foreach(double item in data)
			{
				arr.Write(item);
			}
			return this;
		}

		public AObject Write(string key, ICollection<string> data)
		{
			AArray arr = WriteArray(key);
			foreach(string item in data)
			{
				arr.Write(item);
			}
			return this;
		}

		#endregion

		#region Read
		public abstract bool ReadBool(string key);
		public abstract char ReadChar(string key);
		public abstract short ReadShort(string key);
		public abstract ushort ReadUShort(string key);
		public abstract int ReadInt(string key);
		public abstract uint ReadUInt(string key);
		public abstract long ReadLong(string key);
		public abstract ulong ReadULong(string key);
		public abstract float ReadFloat(string key);
		public abstract double ReadDouble(string key);
		public abstract string ReadString(string key);
		#endregion

		#region Read Array
		public bool[] ReadBoolArray(string key)
		{
			AArray arr = ReadArray(key);
			int count = arr.Count;
			bool[] data = new bool[count];
			for(int x = 0; x < count; ++x)
			{
				data[x] = arr.ReadBool();
			}
			return data;
		}

		public char[] ReadCharArray(string key)
		{
			AArray arr = ReadArray(key);
			int count = arr.Count;
			char[] data = new char[count];
			for(int x = 0; x < count; ++x)
			{
				data[x] = arr.ReadChar();
			}
			return data;
		}

		public short[] ReadShortArray(string key)
		{
			AArray arr = ReadArray(key);
			int count = arr.Count;
			short[] data = new short[count];
			for(int x = 0; x < count; ++x)
			{
				data[x] = arr.ReadShort();
			}
			return data;
		}

		public ushort[] ReadUShortArray(string key)
		{
			AArray arr = ReadArray(key);
			int count = arr.Count;
			ushort[] data = new ushort[count];
			for(int x = 0; x < count; ++x)
			{
				data[x] = arr.ReadUShort();
			}
			return data;
		}

		public int[] ReadIntArray(string key)
		{
			AArray arr = ReadArray(key);
			int count = arr.Count;
			int[] data = new int[count];
			for(int x = 0; x < count; ++x)
			{
				data[x] = arr.ReadInt();
			}
			return data;
		}

		public uint[] ReadUIntArray(string key)
		{
			AArray arr = ReadArray(key);
			int count = arr.Count;
			uint[] data = new uint[count];
			for(int x = 0; x < count; ++x)
			{
				data[x] = arr.ReadUInt();
			}
			return data;
		}

		public long[] ReadLongArray(string key)
		{
			AArray arr = ReadArray(key);
			int count = arr.Count;
			long[] data = new long[count];
			for(int x = 0; x < count; ++x)
			{
				data[x] = arr.ReadLong();
			}
			return data;
		}

		public ulong[] ReadULongArray(string key)
		{
			AArray arr = ReadArray(key);
			int count = arr.Count;
			ulong[] data = new ulong[count];
			for(int x = 0; x < count; ++x)
			{
				data[x] = arr.ReadULong();
			}
			return data;
		}

		public float[] ReadFloatArray(string key)
		{
			AArray arr = ReadArray(key);
			int count = arr.Count;
			float[] data = new float[count];
			for(int x = 0; x < count; ++x)
			{
				data[x] = arr.ReadFloat();
			}
			return data;
		}

		public double[] ReadDoubleArray(string key)
		{
			AArray arr = ReadArray(key);
			int count = arr.Count;
			double[] data = new double[count];
			for(int x = 0; x < count; ++x)
			{
				data[x] = arr.ReadDouble();
			}
			return data;
		}

		public string[] ReadStringArray(string key)
		{
			AArray arr = ReadArray(key);
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
		public void Read(string key, ICollection<bool> data)
		{
			AArray arr = ReadArray(key);
			int count = arr.Count;
			for(int x = 0; x < count; ++x)
			{
				data.Add(arr.ReadBool());
			}
		}

		public void Read(string key, ICollection<char> data)
		{
			AArray arr = ReadArray(key);
			int count = arr.Count;
			for(int x = 0; x < count; ++x)
			{
				data.Add(arr.ReadChar());
			}
		}

		public void Read(string key, ICollection<short> data)
		{
			AArray arr = ReadArray(key);
			int count = arr.Count;
			for(int x = 0; x < count; ++x)
			{
				data.Add(arr.ReadShort());
			}
		}

		public void Read(string key, ICollection<ushort> data)
		{
			AArray arr = ReadArray(key);
			int count = arr.Count;
			for(int x = 0; x < count; ++x)
			{
				data.Add(arr.ReadUShort());
			}
		}

		public void Read(string key, ICollection<int> data)
		{
			AArray arr = ReadArray(key);
			int count = arr.Count;
			for(int x = 0; x < count; ++x)
			{
				data.Add(arr.ReadInt());
			}
		}

		public void Read(string key, ICollection<uint> data)
		{
			AArray arr = ReadArray(key);
			int count = arr.Count;
			for(int x = 0; x < count; ++x)
			{
				data.Add(arr.ReadUInt());
			}
		}

		public void Read(string key, ICollection<long> data)
		{
			AArray arr = ReadArray(key);
			int count = arr.Count;
			for(int x = 0; x < count; ++x)
			{
				data.Add(arr.ReadLong());
			}
		}

		public void Read(string key, ICollection<ulong> data)
		{
			AArray arr = ReadArray(key);
			int count = arr.Count;
			for(int x = 0; x < count; ++x)
			{
				data.Add(arr.ReadULong());
			}
		}

		public void Read(string key, ICollection<float> data)
		{
			AArray arr = ReadArray(key);
			int count = arr.Count;
			for(int x = 0; x < count; ++x)
			{
				data.Add(arr.ReadFloat());
			}
		}

		public void Read(string key, ICollection<double> data)
		{
			AArray arr = ReadArray(key);
			int count = arr.Count;
			for(int x = 0; x < count; ++x)
			{
				data.Add(arr.ReadDouble());
			}
		}

		public void Read(string key, ICollection<string> data)
		{
			AArray arr = ReadArray(key);
			int count = arr.Count;
			for(int x = 0; x < count; ++x)
			{
				data.Add(arr.ReadString());
			}
		}

		#endregion

		#region TryRead
		public bool TryReadBool(string key, bool defaultValue = default(bool))
		{
			try
			{
				bool value = ReadBool(key);
				return value;
			} catch {}
			return defaultValue;
		}

		public char TryReadChar(string key, char defaultValue = default(char))
		{
			try
			{
				char value = ReadChar(key);
				return value;
			} catch {}
			return defaultValue;
		}

		public short TryReadShort(string key, short defaultValue = default(short))
		{
			try
			{
				short value = ReadShort(key);
				return value;
			} catch {}
			return defaultValue;
		}

		public ushort TryReadUShort(string key, ushort defaultValue = default(ushort))
		{
			try
			{
				ushort value = ReadUShort(key);
				return value;
			} catch {}
			return defaultValue;
		}

		public int TryReadInt(string key, int defaultValue = default(int))
		{
			try
			{
				int value = ReadInt(key);
				return value;
			} catch {}
			return defaultValue;
		}

		public uint TryReadUInt(string key, uint defaultValue = default(uint))
		{
			try
			{
				uint value = ReadUInt(key);
				return value;
			} catch {}
			return defaultValue;
		}

		public long TryReadLong(string key, long defaultValue = default(long))
		{
			try
			{
				long value = ReadLong(key);
				return value;
			} catch {}
			return defaultValue;
		}

		public ulong TryReadULong(string key, ulong defaultValue = default(ulong))
		{
			try
			{
				ulong value = ReadULong(key);
				return value;
			} catch {}
			return defaultValue;
		}

		public float TryReadFloat(string key, float defaultValue = default(float))
		{
			try
			{
				float value = ReadFloat(key);
				return value;
			} catch {}
			return defaultValue;
		}

		public double TryReadDouble(string key, double defaultValue = default(double))
		{
			try
			{
				double value = ReadDouble(key);
				return value;
			} catch {}
			return defaultValue;
		}

		public string TryReadString(string key, string defaultValue = default(string))
		{
			try
			{
				string value = ReadString(key);
				return value;
			} catch {}
			return defaultValue;
		}

		#endregion
    }
}
