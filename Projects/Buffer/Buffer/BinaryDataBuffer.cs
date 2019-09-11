using System.Text;

namespace ProceduralLevel.Common.Buffer
{
	public sealed class BinaryDataBuffer: ADataBuffer
	{
		public readonly static BinaryDataBuffer Reusable = new BinaryDataBuffer(1024*4096);

		private byte[] m_Data;
		private int m_Head;
		private int m_Length;

		public override int Length { get { return m_Length; } }
		public override int UnreadCount { get { return m_Length-m_Head; } }

		public BinaryDataBuffer(int capacity)
		{
			m_Data = new byte[capacity];
		}

		public override int ToBytes(byte[] bytes, int offset)
		{
			for(int x = 0; x < m_Length; x++)
			{
				bytes[x+offset] = m_Data[x];
			}
			return m_Head;
		}

		public override void FromBytes(byte[] bytes)
		{
			int length = bytes.Length;
			m_Head = 0;
			m_Length = length;
			if(m_Data.Length < length)
			{
				m_Data = new byte[length];
			}
			for(int x = 0; x < length; ++x)
			{
				m_Data[x] = bytes[x];
			}
		}

		public void Seek(int position)
		{
			m_Head = position;
		}

		public void Skip(int bytes)
		{
			m_Head += bytes;
		}

		public override void Reset()
		{
			m_Length = 0;
			m_Head = 0;
		}

		#region Read
		public override char ReadChar()
		{
			return (char)ReadByte();
		}

		public override bool ReadBool()
		{
			return (ReadByte() == 1? true: false);
		}

		public override byte ReadByte()
		{
			return m_Data[m_Head++];
		}

		public override short ReadShort()
		{
			short value = ReadByte();
			value += (short)(ReadByte() << 8);
			return value;
		}

		public override ushort ReadUShort()
		{
			ushort value = ReadByte();
			value += (ushort)(ReadByte() << 8);
			return value;
		}

		public override int ReadInt()
		{
			int value = ReadByte();
			value += ReadByte() << 8;
			value += ReadByte() << 16;
			value += ReadByte() << 24;
			return value;
		}

		public override uint ReadUInt()
		{
			uint value = ReadByte();
			value += (uint)(ReadByte() << 8);
			value += (uint)(ReadByte() << 16);
			value += (uint)(ReadByte() << 24);
			return value;
		}

		public override string ReadString()
		{
			int length = ReadInt();
			if(length == 0)
			{
				return string.Empty;
			}
			byte[] bytes = new byte[length];
			for(int x = 0; x < length; ++x)
			{
				bytes[x] = ReadByte();
			}
			return Encoding.UTF8.GetString(bytes);
		}
		#endregion

		#region Write
		public override ADataBuffer Write(char data)
		{
			m_Data[m_Length++] = (byte)data;
			return this;
		}

		public override ADataBuffer Write(bool data)
		{
			m_Data[m_Length++] = (data? (byte)1: (byte)0);
			return this;
		}

		public override ADataBuffer Write(byte data)
		{
			m_Data[m_Length++] = data;
			return this;
		}

		public override ADataBuffer Write(short data)
		{
			m_Data[m_Length++] = (byte)data;
			m_Data[m_Length++] = (byte)(data >> 8);
			return this;
		}

		public override ADataBuffer Write(ushort data)
		{
			m_Data[m_Length++] = (byte)data;
			m_Data[m_Length++] = (byte)(data >> 8);
			return this;
		}

		public override ADataBuffer Write(int data)
		{
			m_Data[m_Length++] = (byte)data;
			m_Data[m_Length++] = (byte)(data >> 8);
			m_Data[m_Length++] = (byte)(data >> 16);
			m_Data[m_Length++] = (byte)(data >> 24);
			return this;
		}

		public override ADataBuffer Write(uint data)
		{
			m_Data[m_Length++] = (byte)data;
			m_Data[m_Length++] = (byte)(data >> 8);
			m_Data[m_Length++] = (byte)(data >> 16);
			m_Data[m_Length++] = (byte)(data >> 24);
			return this;
		}

		public override ADataBuffer Write(string data)
		{
			if(string.IsNullOrEmpty(data))
			{
				Write(0);
			}
			else
			{
				byte[] bytes = Encoding.UTF8.GetBytes(data);
				int length = bytes.Length;
				Write(length);
				for(int x = 0; x < length; ++x)
				{
					m_Data[m_Length++] = bytes[x];
				}
			}
			return this;
		}
		#endregion

		public override string ToString()
		{
			return base.ToString()+string.Format("[Head: {0}]", m_Head);
		}
	}
}
