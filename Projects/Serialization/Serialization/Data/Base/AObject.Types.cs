namespace ProceduralLevel.Serialization
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

		#region WriteArray
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
