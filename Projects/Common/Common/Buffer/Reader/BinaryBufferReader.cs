using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace ProceduralLevel.Common.Buffer
{
	public partial class BinaryBufferReader
		: ABinaryBuffer
	{
		public int Length { get { return m_Buffer.Length; } }

		public BinaryBufferReader(byte[] buffer)
			: base(buffer)
		{
		}

		public BinaryBufferReader(byte[] buffer, int readOffset, int length)
			: base(new byte[length])
		{
			for(int x = 0; x < length; ++x)
			{
				m_Buffer[x] = buffer[x+readOffset];
			}
		}

		public void SkipChunk()
		{
			int chunkSize = ReadInt();
			Skip(chunkSize);
		}

		public void Skip(int length)
		{
			m_Position += length;
		}

		#region Read
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public Guid ReadGuid()
		{
			byte[] bytes = new byte[GUID_LENGTH];
			for(int x = 0; x < GUID_LENGTH; ++x)
			{
				bytes[x] = m_Buffer[m_Position++];
			}
			return new Guid(bytes);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public char ReadChar()
		{
			return (char)m_Buffer[m_Position++];
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool ReadBool()
		{
			return (m_Buffer[m_Position++] == 1 ? true : false);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte ReadByte()
		{
			return m_Buffer[m_Position++];
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public short ReadShort()
		{
			short value = m_Buffer[m_Position++];
			value += (short)(m_Buffer[m_Position++] << 8);
			return value;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ushort ReadUShort()
		{
			ushort value = m_Buffer[m_Position++];
			value += (ushort)(m_Buffer[m_Position++] << 8);
			return value;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int ReadInt()
		{
			int value = m_Buffer[m_Position++];
			value += m_Buffer[m_Position++] << 8;
			value += m_Buffer[m_Position++] << 16;
			value += m_Buffer[m_Position++] << 24;
			return value;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint ReadUInt()
		{
			uint value = m_Buffer[m_Position++];
			value += (uint)(m_Buffer[m_Position++] << 8);
			value += (uint)(m_Buffer[m_Position++] << 16);
			value += (uint)(m_Buffer[m_Position++] << 24);
			return value;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public long ReadLong()
		{
			long value = m_Buffer[m_Position++];
			value += (long)m_Buffer[m_Position++] << 8;
			value += (long)m_Buffer[m_Position++] << 16;
			value += (long)m_Buffer[m_Position++] << 24;
			value += (long)m_Buffer[m_Position++] << 32;
			value += (long)m_Buffer[m_Position++] << 40;
			value += (long)m_Buffer[m_Position++] << 48;
			value += (long)m_Buffer[m_Position++] << 56;
			return value;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ulong ReadULong()
		{
			ulong value = m_Buffer[m_Position++];
			value += ((ulong)m_Buffer[m_Position++] << 8);
			value += ((ulong)m_Buffer[m_Position++] << 16);
			value += ((ulong)m_Buffer[m_Position++] << 24);
			value += ((ulong)m_Buffer[m_Position++] << 32);
			value += ((ulong)m_Buffer[m_Position++] << 40);
			value += ((ulong)m_Buffer[m_Position++] << 48);
			value += ((ulong)m_Buffer[m_Position++] << 56);
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
				bytes[x] = m_Buffer[m_Position++];
			}
			return Encoding.UTF8.GetString(bytes);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float ReadFloat()
		{
			float value = BitConverter.ToSingle(m_Buffer, m_Position);
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
	}
}
