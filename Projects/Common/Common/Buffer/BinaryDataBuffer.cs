using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ProceduralLevel.Common.Buffer
{
	public partial class BinaryDataBuffer
	{
		protected readonly byte[] m_Data;
		protected int m_ReadPos;
		protected int m_WritePos;

		public byte[] Bytes { get { return m_Data; } }
		public int Length { get { return m_WritePos; } }
		public int UnreadCount { get { return m_WritePos-m_ReadPos; } }

		public BinaryDataBuffer(int capacity)
		{
			m_Data = new byte[capacity];
		}

		public BinaryDataBuffer(byte[] data)
		{
			m_Data = data;
		}

		public byte[] ToBytes()
		{
			byte[] bytes = new byte[m_WritePos];
			ToBytes(bytes, 0);
			return bytes;
		}

		public int ToBytes(byte[] bytes, int offset = 0)
		{
			for(int x = 0; x < m_WritePos; x++)
			{
				bytes[x+offset] = m_Data[x];
			}
			return m_ReadPos;
		}

		public void FromBytes(byte[] bytes)
		{
			FromBytes(bytes, 0, bytes.Length);
		}

		public void FromBytes(byte[] bytes, int readOffset, int length)
		{
			m_ReadPos = 0;
			m_WritePos = length;
			for(int x = 0; x < length; ++x)
			{
				m_Data[x] = bytes[x+readOffset];
			}
		}

		public void Seek(int position)
		{
			m_ReadPos = position;
		}

		public void Skip(int bytes)
		{
			m_ReadPos += bytes;
		}

		public void Reset()
		{
			m_WritePos = 0;
			m_ReadPos = 0;
		}

		#region Deserialize
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
				entry.FromDataBuffer(this);
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
				entry.FromDataBuffer(this);
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
				entry.FromDataBuffer(this);
				arr[x] = entry;
			}
			return arr;
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
				entry.FromDataBuffer(this, data);
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
				entry.FromDataBuffer(this, data);
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
				entry.FromDataBuffer(this, data);
				arr[x] = entry;
			}
			return arr;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public char ReadChar()
		{
			return (char)m_Data[m_ReadPos++];
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool ReadBool()
		{
			return (m_Data[m_ReadPos++] == 1? true: false);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte ReadByte()
		{
			return m_Data[m_ReadPos++];
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public short ReadShort()
		{
			short value = m_Data[m_ReadPos++];
			value += (short)(m_Data[m_ReadPos++] << 8);
			return value;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ushort ReadUShort()
		{
			ushort value = m_Data[m_ReadPos++];
			value += (ushort)(m_Data[m_ReadPos++] << 8);
			return value;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int ReadInt()
		{
			int value = m_Data[m_ReadPos++];
			value += m_Data[m_ReadPos++] << 8;
			value += m_Data[m_ReadPos++] << 16;
			value += m_Data[m_ReadPos++] << 24;
			return value;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint ReadUInt()
		{
			uint value = m_Data[m_ReadPos++];
			value += (uint)(m_Data[m_ReadPos++] << 8);
			value += (uint)(m_Data[m_ReadPos++] << 16);
			value += (uint)(m_Data[m_ReadPos++] << 24);
			return value;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public long ReadLong()
		{
			long value = m_Data[m_ReadPos++];
			value += (long)m_Data[m_ReadPos++] << 8;
			value += (long)m_Data[m_ReadPos++] << 16;
			value += (long)m_Data[m_ReadPos++] << 24;
			value += (long)m_Data[m_ReadPos++] << 32;
			value += (long)m_Data[m_ReadPos++] << 40;
			value += (long)m_Data[m_ReadPos++] << 48;
			value += (long)m_Data[m_ReadPos++] << 56;
			return value;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ulong ReadULong()
		{
			ulong value = m_Data[m_ReadPos++];
			value += ((ulong)m_Data[m_ReadPos++] << 8);
			value += ((ulong)m_Data[m_ReadPos++] << 16);
			value += ((ulong)m_Data[m_ReadPos++] << 24);
			value += ((ulong)m_Data[m_ReadPos++] << 32);
			value += ((ulong)m_Data[m_ReadPos++] << 40);
			value += ((ulong)m_Data[m_ReadPos++] << 48);
			value += ((ulong)m_Data[m_ReadPos++] << 56);
			return value;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
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
				bytes[x] = m_Data[m_ReadPos++];
			}
			return Encoding.UTF8.GetString(bytes);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float ReadFloat()
		{
			float value = BitConverter.ToSingle(m_Data, m_ReadPos);
			m_ReadPos += 4;
			return value;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double ReadDouble()
		{
			long value = ReadLong();
			return BitConverter.Int64BitsToDouble(value);
		}
		#endregion

		#region Write
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BinaryDataBuffer Write(IBufferSerialized serializable)
		{
			serializable.ToDataBuffer(this);
			return this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
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

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
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

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BinaryDataBuffer Write(char data)
		{
			m_Data[m_WritePos++] = (byte)data;
			return this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BinaryDataBuffer Write(bool data)
		{
			m_Data[m_WritePos++] = (data? (byte)1: (byte)0);
			return this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BinaryDataBuffer Write(byte data)
		{
			m_Data[m_WritePos++] = data;
			return this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BinaryDataBuffer Write(short data)
		{
			m_Data[m_WritePos++] = (byte)data;
			m_Data[m_WritePos++] = (byte)(data >> 8);
			return this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BinaryDataBuffer Write(ushort data)
		{
			m_Data[m_WritePos++] = (byte)data;
			m_Data[m_WritePos++] = (byte)(data >> 8);
			return this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BinaryDataBuffer Write(int data)
		{
			m_Data[m_WritePos++] = (byte)data;
			m_Data[m_WritePos++] = (byte)(data >> 8);
			m_Data[m_WritePos++] = (byte)(data >> 16);
			m_Data[m_WritePos++] = (byte)(data >> 24);
			return this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BinaryDataBuffer Write(uint data)
		{
			m_Data[m_WritePos++] = (byte)data;
			m_Data[m_WritePos++] = (byte)(data >> 8);
			m_Data[m_WritePos++] = (byte)(data >> 16);
			m_Data[m_WritePos++] = (byte)(data >> 24);
			return this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BinaryDataBuffer Write(long data)
		{
			m_Data[m_WritePos++] = (byte)data;
			m_Data[m_WritePos++] = (byte)(data >> 8);
			m_Data[m_WritePos++] = (byte)(data >> 16);
			m_Data[m_WritePos++] = (byte)(data >> 24);
			m_Data[m_WritePos++] = (byte)(data >> 32);
			m_Data[m_WritePos++] = (byte)(data >> 40);
			m_Data[m_WritePos++] = (byte)(data >> 48);
			m_Data[m_WritePos++] = (byte)(data >> 56);
			return this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BinaryDataBuffer Write(ulong data)
		{
			m_Data[m_WritePos++] = (byte)data;
			m_Data[m_WritePos++] = (byte)(data >> 8);
			m_Data[m_WritePos++] = (byte)(data >> 16);
			m_Data[m_WritePos++] = (byte)(data >> 24);
			m_Data[m_WritePos++] = (byte)(data >> 32);
			m_Data[m_WritePos++] = (byte)(data >> 40);
			m_Data[m_WritePos++] = (byte)(data >> 48);
			m_Data[m_WritePos++] = (byte)(data >> 56);
			return this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
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
					m_Data[m_WritePos++] = bytes[x];
				}
			}
			return this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BinaryDataBuffer Write(float data)
		{
			byte[] bytes = BitConverter.GetBytes(data); //allocates memory, but I couldn't find a better way of doing this
			m_Data[m_WritePos++] = bytes[0];
			m_Data[m_WritePos++] = bytes[1];
			m_Data[m_WritePos++] = bytes[2];
			m_Data[m_WritePos++] = bytes[3];
			return this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BinaryDataBuffer Write(double data)
		{
			long value = BitConverter.DoubleToInt64Bits(data);
			Write(value);
			return this;
		}
		#endregion

		public override string ToString()
		{
			return string.Format("[Length: {0}, Head: {1}]", m_WritePos, m_ReadPos);
		}
	}
}
