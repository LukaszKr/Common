using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ProceduralLevel.Common.Buffer
{
	public partial class BinaryDataBuffer
	{
		private const int GUID_LENGTH = 16;

		protected readonly byte[] m_Data;
		protected int m_Position;

		public byte[] Bytes { get { return m_Data; } }
		public int Position { get { return m_Position; } }
		public int Capacity { get { return m_Data.Length; } }

		public BinaryDataBuffer(int capacity)
		{
			m_Data = new byte[capacity];
		}

		public BinaryDataBuffer(byte[] data)
		{
			m_Data = data;
		}

		public byte[] ToBytes(bool usePosition = true)
		{
			int length = (usePosition? m_Position: m_Data.Length);
			byte[] bytes = new byte[length];
			ToBytes(bytes, 0);
			return bytes;
		}

		public int ToBytes(byte[] bytes, int offset = 0, bool usePosition = true)
		{
			int length = (usePosition? m_Position: m_Data.Length);
			for(int x = 0; x < length; x++)
			{
				bytes[x+offset] = m_Data[x];
			}
			return m_Position;
		}

		public void FromBytes(byte[] bytes)
		{
			FromBytes(bytes, 0, bytes.Length);
		}

		public void FromBytes(byte[] bytes, int readOffset, int length)
		{
			m_Position = 0;
			for(int x = 0; x < length; ++x)
			{
				m_Data[x] = bytes[x+readOffset];
			}
		}

		public void Seek(int position, ESeekOrigin origin = ESeekOrigin.Begin)
		{
			switch(origin)
			{
				case ESeekOrigin.Begin:
					m_Position = position;
					break;
				case ESeekOrigin.Current:
					m_Position += position;
					break;
				case ESeekOrigin.End:
					m_Position = m_Data.Length-position;
					break;
				default:
					throw new NotImplementedException();
			}
		}

		public BufferChunk CreateChunk()
		{
			return new BufferChunk(this);
		}

		#region Read
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
		public Guid ReadGuid()
		{
			byte[] bytes = new byte[GUID_LENGTH];
			for(int x = 0; x < GUID_LENGTH; ++x)
			{
				bytes[x] = m_Data[m_Position++];
			}
			return new Guid(bytes);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public char ReadChar()
		{
			return (char)m_Data[m_Position++];
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool ReadBool()
		{
			return (m_Data[m_Position++] == 1 ? true : false);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte ReadByte()
		{
			return m_Data[m_Position++];
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public short ReadShort()
		{
			short value = m_Data[m_Position++];
			value += (short)(m_Data[m_Position++] << 8);
			return value;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ushort ReadUShort()
		{
			ushort value = m_Data[m_Position++];
			value += (ushort)(m_Data[m_Position++] << 8);
			return value;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int ReadInt()
		{
			int value = m_Data[m_Position++];
			value += m_Data[m_Position++] << 8;
			value += m_Data[m_Position++] << 16;
			value += m_Data[m_Position++] << 24;
			return value;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint ReadUInt()
		{
			uint value = m_Data[m_Position++];
			value += (uint)(m_Data[m_Position++] << 8);
			value += (uint)(m_Data[m_Position++] << 16);
			value += (uint)(m_Data[m_Position++] << 24);
			return value;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public long ReadLong()
		{
			long value = m_Data[m_Position++];
			value += (long)m_Data[m_Position++] << 8;
			value += (long)m_Data[m_Position++] << 16;
			value += (long)m_Data[m_Position++] << 24;
			value += (long)m_Data[m_Position++] << 32;
			value += (long)m_Data[m_Position++] << 40;
			value += (long)m_Data[m_Position++] << 48;
			value += (long)m_Data[m_Position++] << 56;
			return value;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ulong ReadULong()
		{
			ulong value = m_Data[m_Position++];
			value += ((ulong)m_Data[m_Position++] << 8);
			value += ((ulong)m_Data[m_Position++] << 16);
			value += ((ulong)m_Data[m_Position++] << 24);
			value += ((ulong)m_Data[m_Position++] << 32);
			value += ((ulong)m_Data[m_Position++] << 40);
			value += ((ulong)m_Data[m_Position++] << 48);
			value += ((ulong)m_Data[m_Position++] << 56);
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
				bytes[x] = m_Data[m_Position++];
			}
			return Encoding.UTF8.GetString(bytes);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float ReadFloat()
		{
			float value = BitConverter.ToSingle(m_Data, m_Position);
			m_Position += 4;
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
		public BinaryDataBuffer Write(Guid guid)
		{
			byte[] bytes = guid.ToByteArray();
			for(int x = 0; x < GUID_LENGTH; ++x)
			{
				m_Data[m_Position++] = bytes[x];
			}
			return this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BinaryDataBuffer Write(char data)
		{
			m_Data[m_Position++] = (byte)data;
			return this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BinaryDataBuffer Write(bool data)
		{
			m_Data[m_Position++] = (data ? (byte)1 : (byte)0);
			return this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BinaryDataBuffer Write(byte data)
		{
			m_Data[m_Position++] = data;
			return this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BinaryDataBuffer Write(short data)
		{
			m_Data[m_Position++] = (byte)data;
			m_Data[m_Position++] = (byte)(data >> 8);
			return this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BinaryDataBuffer Write(ushort data)
		{
			m_Data[m_Position++] = (byte)data;
			m_Data[m_Position++] = (byte)(data >> 8);
			return this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BinaryDataBuffer Write(int data)
		{
			m_Data[m_Position++] = (byte)data;
			m_Data[m_Position++] = (byte)(data >> 8);
			m_Data[m_Position++] = (byte)(data >> 16);
			m_Data[m_Position++] = (byte)(data >> 24);
			return this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BinaryDataBuffer Write(uint data)
		{
			m_Data[m_Position++] = (byte)data;
			m_Data[m_Position++] = (byte)(data >> 8);
			m_Data[m_Position++] = (byte)(data >> 16);
			m_Data[m_Position++] = (byte)(data >> 24);
			return this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BinaryDataBuffer Write(long data)
		{
			m_Data[m_Position++] = (byte)data;
			m_Data[m_Position++] = (byte)(data >> 8);
			m_Data[m_Position++] = (byte)(data >> 16);
			m_Data[m_Position++] = (byte)(data >> 24);
			m_Data[m_Position++] = (byte)(data >> 32);
			m_Data[m_Position++] = (byte)(data >> 40);
			m_Data[m_Position++] = (byte)(data >> 48);
			m_Data[m_Position++] = (byte)(data >> 56);
			return this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BinaryDataBuffer Write(ulong data)
		{
			m_Data[m_Position++] = (byte)data;
			m_Data[m_Position++] = (byte)(data >> 8);
			m_Data[m_Position++] = (byte)(data >> 16);
			m_Data[m_Position++] = (byte)(data >> 24);
			m_Data[m_Position++] = (byte)(data >> 32);
			m_Data[m_Position++] = (byte)(data >> 40);
			m_Data[m_Position++] = (byte)(data >> 48);
			m_Data[m_Position++] = (byte)(data >> 56);
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
					m_Data[m_Position++] = bytes[x];
				}
			}
			return this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BinaryDataBuffer Write(float data)
		{
			byte[] bytes = BitConverter.GetBytes(data); //allocates memory, but I couldn't find a better way of doing this
			m_Data[m_Position++] = bytes[0];
			m_Data[m_Position++] = bytes[1];
			m_Data[m_Position++] = bytes[2];
			m_Data[m_Position++] = bytes[3];
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
			return string.Format("[Length: {0}, Head: {1}]", m_Position, m_Position);
		}
	}
}
