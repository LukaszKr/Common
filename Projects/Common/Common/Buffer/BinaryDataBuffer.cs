using System;
using System.Collections.Generic;
using System.Text;

namespace ProceduralLevel.Common.Buffer
{
	public partial class BinaryDataBuffer
	{
		private readonly byte[] m_Data;
		private int m_Head;
		private int m_Length;

		public byte[] Bytes { get { return m_Data; } }
		public int Length { get { return m_Length; } }
		public int UnreadCount { get { return m_Length-m_Head; } }

		public BinaryDataBuffer(int capacity)
		{
			m_Data = new byte[capacity];
		}

		public int ToBytes(byte[] bytes, int offset)
		{
			for(int x = 0; x < m_Length; x++)
			{
				bytes[x+offset] = m_Data[x];
			}
			return m_Head;
		}

		public void FromBytes(byte[] bytes, int readOffset, int length)
		{
			m_Head = 0;
			m_Length = length;
			for(int x = 0; x < length; ++x)
			{
				m_Data[x] = bytes[x+readOffset];
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

		public void Reset()
		{
			m_Length = 0;
			m_Head = 0;
		}

		#region Deserialize
		public void Read(IBufferDeserialized serializable)
		{
			serializable.FromDataBuffer(this);
		}

		public void Read<TEntry>(List<TEntry> list, bool append = false)
			where TEntry : IBufferDeserialized, new()
		{
			if(!append)
			{
				list.Clear();
			}
			int count = ReadInt();
			for(int x = 0; x < count; ++x)
			{
				TEntry entry = new TEntry();
				Read(entry);
				list.Add(entry);
			}
		}

		public int Read<TEntry>(TEntry[] arr, int offset = 0)
			where TEntry : IBufferDeserialized, new()
		{
			int length = ReadInt();
			for(int x = 0; x < length; ++x)
			{
				TEntry entry = new TEntry();
				Read(entry);
				arr[x+offset] = entry;
			}
			return length;
		}

		public TEntry[] ReadArray<TEntry>()
			where TEntry : IBufferDeserialized, new()
		{
			int length = ReadInt();
			TEntry[] arr = new TEntry[length];
			for(int x = 0; x < length; ++x)
			{
				TEntry entry = new TEntry();
				Read(entry);
				arr[x] = entry;
			}
			return arr;
		}

		public void Read<TData>(IBufferDeserialized<TData> serializable, TData data)
		{
			serializable.FromDataBuffer(this, data);
		}

		public void Read<TEntry, TData>(List<TEntry> list, TData data, bool append = false)
			where TEntry : IBufferDeserialized<TData>, new()
		{
			if(!append)
			{
				list.Clear();
			}
			int count = ReadInt();
			for(int x = 0; x < count; ++x)
			{
				TEntry entry = new TEntry();
				Read(entry, data);
				list.Add(entry);
			}
		}

		public int Read<TEntry, TData>(TEntry[] arr, TData data, int offset = 0)
			where TEntry : IBufferDeserialized<TData>, new()
		{
			int length = ReadInt();
			for(int x = 0; x < length; ++x)
			{
				TEntry entry = new TEntry();
				Read(entry, data);
				arr[x+offset] = entry;
			}
			return length;
		}

		public TEntry[] ReadArray<TEntry, TData>(TData data)
			where TEntry : IBufferDeserialized<TData>, new()
		{
			int length = ReadInt();
			TEntry[] arr = new TEntry[length];
			for(int x = 0; x < length; ++x)
			{
				TEntry entry = new TEntry();
				Read(entry, data);
				arr[x] = entry;
			}
			return arr;
		}

		public char ReadChar()
		{
			return (char)m_Data[m_Head++];
		}

		public bool ReadBool()
		{
			return (m_Data[m_Head++] == 1? true: false);
		}

		public byte ReadByte()
		{
			return m_Data[m_Head++];
		}

		public short ReadShort()
		{
			short value = m_Data[m_Head++];
			value += (short)(m_Data[m_Head++] << 8);
			return value;
		}

		public ushort ReadUShort()
		{
			ushort value = m_Data[m_Head++];
			value += (ushort)(m_Data[m_Head++] << 8);
			return value;
		}

		public int ReadInt()
		{
			int value = m_Data[m_Head++];
			value += m_Data[m_Head++] << 8;
			value += m_Data[m_Head++] << 16;
			value += m_Data[m_Head++] << 24;
			return value;
		}

		public uint ReadUInt()
		{
			uint value = m_Data[m_Head++];
			value += (uint)(m_Data[m_Head++] << 8);
			value += (uint)(m_Data[m_Head++] << 16);
			value += (uint)(m_Data[m_Head++] << 24);
			return value;
		}

		public long ReadLong()
		{
			long value = m_Data[m_Head++];
			value += (long)m_Data[m_Head++] << 8;
			value += (long)m_Data[m_Head++] << 16;
			value += (long)m_Data[m_Head++] << 24;
			value += (long)m_Data[m_Head++] << 32;
			value += (long)m_Data[m_Head++] << 40;
			value += (long)m_Data[m_Head++] << 48;
			value += (long)m_Data[m_Head++] << 56;
			return value;
		}

		public ulong ReadULong()
		{
			ulong value = m_Data[m_Head++];
			value += ((ulong)m_Data[m_Head++] << 8);
			value += ((ulong)m_Data[m_Head++] << 16);
			value += ((ulong)m_Data[m_Head++] << 24);
			value += ((ulong)m_Data[m_Head++] << 32);
			value += ((ulong)m_Data[m_Head++] << 40);
			value += ((ulong)m_Data[m_Head++] << 48);
			value += ((ulong)m_Data[m_Head++] << 56);
			return value;
		}

		public string ReadString()
		{
			int length = ReadInt();
			if(length == 0)
			{
				return string.Empty;
			}
			byte[] bytes = new byte[length];
			for(int x = 0; x < length; ++x)
			{
				bytes[x] = m_Data[m_Head++];
			}
			return Encoding.UTF8.GetString(bytes);
		}

		public float ReadFloat()
		{
			float value = BitConverter.ToSingle(m_Data, m_Head);
			m_Head += 4;
			return value;
		}

		public double ReadDouble()
		{
			long value = ReadLong();
			return BitConverter.Int64BitsToDouble(value);
		}
		#endregion

		#region Write
		public BinaryDataBuffer Write(IBufferSerialized serializable)
		{
			serializable.ToDataBuffer(this);
			return this;
		}

		public BinaryDataBuffer Write(IBufferSerialized[] arr)
		{
			int length = arr.Length;
			Write(length);
			for(int x = 0; x < length; ++x)
			{
				Write(arr[x]);
			}
			return this;
		}

		public BinaryDataBuffer Write<TEntry>(List<TEntry> list)
			where TEntry : IBufferSerialized
		{
			int count = list.Count;
			Write(count);
			for(int x = 0; x < count; ++x)
			{
				Write(list[x]);
			}
			return this;
		}

		public BinaryDataBuffer Write(char data)
		{
			m_Data[m_Length++] = (byte)data;
			return this;
		}

		public BinaryDataBuffer Write(bool data)
		{
			m_Data[m_Length++] = (data? (byte)1: (byte)0);
			return this;
		}

		public BinaryDataBuffer Write(byte data)
		{
			m_Data[m_Length++] = data;
			return this;
		}

		public BinaryDataBuffer Write(short data)
		{
			m_Data[m_Length++] = (byte)data;
			m_Data[m_Length++] = (byte)(data >> 8);
			return this;
		}

		public BinaryDataBuffer Write(ushort data)
		{
			m_Data[m_Length++] = (byte)data;
			m_Data[m_Length++] = (byte)(data >> 8);
			return this;
		}

		public BinaryDataBuffer Write(int data)
		{
			m_Data[m_Length++] = (byte)data;
			m_Data[m_Length++] = (byte)(data >> 8);
			m_Data[m_Length++] = (byte)(data >> 16);
			m_Data[m_Length++] = (byte)(data >> 24);
			return this;
		}

		public BinaryDataBuffer Write(uint data)
		{
			m_Data[m_Length++] = (byte)data;
			m_Data[m_Length++] = (byte)(data >> 8);
			m_Data[m_Length++] = (byte)(data >> 16);
			m_Data[m_Length++] = (byte)(data >> 24);
			return this;
		}

		public BinaryDataBuffer Write(long data)
		{
			m_Data[m_Length++] = (byte)data;
			m_Data[m_Length++] = (byte)(data >> 8);
			m_Data[m_Length++] = (byte)(data >> 16);
			m_Data[m_Length++] = (byte)(data >> 24);
			m_Data[m_Length++] = (byte)(data >> 32);
			m_Data[m_Length++] = (byte)(data >> 40);
			m_Data[m_Length++] = (byte)(data >> 48);
			m_Data[m_Length++] = (byte)(data >> 56);
			return this;
		}

		public BinaryDataBuffer Write(ulong data)
		{
			m_Data[m_Length++] = (byte)data;
			m_Data[m_Length++] = (byte)(data >> 8);
			m_Data[m_Length++] = (byte)(data >> 16);
			m_Data[m_Length++] = (byte)(data >> 24);
			m_Data[m_Length++] = (byte)(data >> 32);
			m_Data[m_Length++] = (byte)(data >> 40);
			m_Data[m_Length++] = (byte)(data >> 48);
			m_Data[m_Length++] = (byte)(data >> 56);
			return this;
		}

		public BinaryDataBuffer Write(string data)
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

		public BinaryDataBuffer Write(float data)
		{
			byte[] bytes = BitConverter.GetBytes(data); //allocates memory, but I couldn't find a better way of doing this
			m_Data[m_Length++] = bytes[0];
			m_Data[m_Length++] = bytes[1];
			m_Data[m_Length++] = bytes[2];
			m_Data[m_Length++] = bytes[3];
			return this;
		}

		public BinaryDataBuffer Write(double data)
		{
			long value = BitConverter.DoubleToInt64Bits(data);
			Write(value);
			return this;
		}
		#endregion

		public override string ToString()
		{
			return string.Format("[Length: {0}, Head: {1}]", m_Length, m_Head);
		}
	}
}
