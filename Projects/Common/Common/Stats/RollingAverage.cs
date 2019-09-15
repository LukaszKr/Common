namespace ProceduralLevel.Common.Stats
{
	public class RollingAverageByte
	{
		private readonly byte[] m_Buffer;
		private int m_Count;
		private int m_Head;
		private byte m_Sum;

		public byte Value { get; private set; }

		public RollingAverageByte(int bufferSize)
		{
			m_Buffer = new byte[bufferSize];
		}

		public void Push(byte value)
		{
			int length = m_Buffer.Length;
			if(m_Count < length)
			{
				++m_Count;
			}
			m_Sum -= m_Buffer[m_Head];
			m_Sum += value;
			m_Buffer[m_Head] = value;
			++m_Head;
			if(m_Head >= length)
			{
				m_Head = 0;
			}
			Value = (byte)(m_Sum/(double)m_Count);
		}
	}

	public class RollingAverageShort
	{
		private readonly short[] m_Buffer;
		private int m_Count;
		private int m_Head;
		private short m_Sum;

		public short Value { get; private set; }

		public RollingAverageShort(int bufferSize)
		{
			m_Buffer = new short[bufferSize];
		}

		public void Push(short value)
		{
			int length = m_Buffer.Length;
			if(m_Count < length)
			{
				++m_Count;
			}
			m_Sum -= m_Buffer[m_Head];
			m_Sum += value;
			m_Buffer[m_Head] = value;
			++m_Head;
			if(m_Head >= length)
			{
				m_Head = 0;
			}
			Value = (short)(m_Sum/(double)m_Count);
		}
	}

	public class RollingAverageUShort
	{
		private readonly ushort[] m_Buffer;
		private int m_Count;
		private int m_Head;
		private ushort m_Sum;

		public ushort Value { get; private set; }

		public RollingAverageUShort(int bufferSize)
		{
			m_Buffer = new ushort[bufferSize];
		}

		public void Push(ushort value)
		{
			int length = m_Buffer.Length;
			if(m_Count < length)
			{
				++m_Count;
			}
			m_Sum -= m_Buffer[m_Head];
			m_Sum += value;
			m_Buffer[m_Head] = value;
			++m_Head;
			if(m_Head >= length)
			{
				m_Head = 0;
			}
			Value = (ushort)(m_Sum/(double)m_Count);
		}
	}

	public class RollingAverageInt
	{
		private readonly int[] m_Buffer;
		private int m_Count;
		private int m_Head;
		private int m_Sum;

		public int Value { get; private set; }

		public RollingAverageInt(int bufferSize)
		{
			m_Buffer = new int[bufferSize];
		}

		public void Push(int value)
		{
			int length = m_Buffer.Length;
			if(m_Count < length)
			{
				++m_Count;
			}
			m_Sum -= m_Buffer[m_Head];
			m_Sum += value;
			m_Buffer[m_Head] = value;
			++m_Head;
			if(m_Head >= length)
			{
				m_Head = 0;
			}
			Value = (int)(m_Sum/(double)m_Count);
		}
	}

	public class RollingAverageUInt
	{
		private readonly uint[] m_Buffer;
		private int m_Count;
		private int m_Head;
		private uint m_Sum;

		public uint Value { get; private set; }

		public RollingAverageUInt(int bufferSize)
		{
			m_Buffer = new uint[bufferSize];
		}

		public void Push(uint value)
		{
			int length = m_Buffer.Length;
			if(m_Count < length)
			{
				++m_Count;
			}
			m_Sum -= m_Buffer[m_Head];
			m_Sum += value;
			m_Buffer[m_Head] = value;
			++m_Head;
			if(m_Head >= length)
			{
				m_Head = 0;
			}
			Value = (uint)(m_Sum/(double)m_Count);
		}
	}

	public class RollingAverageLong
	{
		private readonly long[] m_Buffer;
		private int m_Count;
		private int m_Head;
		private long m_Sum;

		public long Value { get; private set; }

		public RollingAverageLong(int bufferSize)
		{
			m_Buffer = new long[bufferSize];
		}

		public void Push(long value)
		{
			int length = m_Buffer.Length;
			if(m_Count < length)
			{
				++m_Count;
			}
			m_Sum -= m_Buffer[m_Head];
			m_Sum += value;
			m_Buffer[m_Head] = value;
			++m_Head;
			if(m_Head >= length)
			{
				m_Head = 0;
			}
			Value = (long)(m_Sum/(double)m_Count);
		}
	}

	public class RollingAverageULong
	{
		private readonly ulong[] m_Buffer;
		private int m_Count;
		private int m_Head;
		private ulong m_Sum;

		public ulong Value { get; private set; }

		public RollingAverageULong(int bufferSize)
		{
			m_Buffer = new ulong[bufferSize];
		}

		public void Push(ulong value)
		{
			int length = m_Buffer.Length;
			if(m_Count < length)
			{
				++m_Count;
			}
			m_Sum -= m_Buffer[m_Head];
			m_Sum += value;
			m_Buffer[m_Head] = value;
			++m_Head;
			if(m_Head >= length)
			{
				m_Head = 0;
			}
			Value = (ulong)(m_Sum/(double)m_Count);
		}
	}

	public class RollingAverageFloat
	{
		private readonly float[] m_Buffer;
		private int m_Count;
		private int m_Head;
		private float m_Sum;

		public float Value { get; private set; }

		public RollingAverageFloat(int bufferSize)
		{
			m_Buffer = new float[bufferSize];
		}

		public void Push(float value)
		{
			int length = m_Buffer.Length;
			if(m_Count < length)
			{
				++m_Count;
			}
			m_Sum -= m_Buffer[m_Head];
			m_Sum += value;
			m_Buffer[m_Head] = value;
			++m_Head;
			if(m_Head >= length)
			{
				m_Head = 0;
			}
			Value = (float)(m_Sum/(double)m_Count);
		}
	}

	public class RollingAverageDouble
	{
		private readonly double[] m_Buffer;
		private int m_Count;
		private int m_Head;
		private double m_Sum;

		public double Value { get; private set; }

		public RollingAverageDouble(int bufferSize)
		{
			m_Buffer = new double[bufferSize];
		}

		public void Push(double value)
		{
			int length = m_Buffer.Length;
			if(m_Count < length)
			{
				++m_Count;
			}
			m_Sum -= m_Buffer[m_Head];
			m_Sum += value;
			m_Buffer[m_Head] = value;
			++m_Head;
			if(m_Head >= length)
			{
				m_Head = 0;
			}
			Value = (double)(m_Sum/(double)m_Count);
		}
	}

}
