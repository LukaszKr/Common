﻿using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace ProceduralLevel.Common.Buffer
{
	public partial class BinaryBufferWriter: ABinaryBuffer
	{
		private readonly bool m_CanExpand;

		public bool CanExpand { get { return m_CanExpand; } }
		public int Capacity { get { return m_Buffer.Length; } }
		public int RemainingCapacity { get { return m_Buffer.Length-m_Position; } }

		public BinaryBufferWriter(int maxCapacity)
			: base(maxCapacity)
		{
			m_CanExpand = true;
		}

		public BinaryBufferWriter(byte[] buffer)
			: base(buffer)
		{
			m_CanExpand = false;
		}

		public BinaryBufferChunk StartChunk()
		{
			return new BinaryBufferChunk(this);
		}

		private void Resize(int newCapacity)
		{
			byte[] oldBuffer = m_Buffer;
			m_Buffer = new byte[newCapacity];
			int length = Math.Min(oldBuffer.Length, newCapacity);
			for(int x = 0; x < length; ++x)
			{
				m_Buffer[x] = oldBuffer[x];
			}
		}

		private void EnsureCapacity(int requiredSpace)
		{
			if(m_CanExpand && requiredSpace > RemainingCapacity)
			{
				Resize(Capacity*2);
			}
		}

		public byte[] ToBytes()
		{
			int length = m_Position;
			byte[] bytes = new byte[length];
			ToBytes(bytes, 0);
			return bytes;
		}

		public int ToBytes(byte[] bytes, int offset = 0)
		{
			int length = m_Position;
			for(int x = 0; x < length; x++)
			{
				bytes[x+offset] = m_Buffer[x];
			}
			return m_Position;
		}

		#region Write
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BinaryBufferWriter Write(Guid guid)
		{
			EnsureCapacity(GUID_LENGTH);
			byte[] bytes = guid.ToByteArray();
			for(int x = 0; x < GUID_LENGTH; ++x)
			{
				m_Buffer[m_Position++] = bytes[x];
			}
			return this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BinaryBufferWriter Write(char data)
		{
			EnsureCapacity(1);
			m_Buffer[m_Position++] = (byte)data;
			return this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BinaryBufferWriter Write(bool data)
		{
			EnsureCapacity(1);
			m_Buffer[m_Position++] = (data ? (byte)1 : (byte)0);
			return this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BinaryBufferWriter Write(byte data)
		{
			EnsureCapacity(1);
			m_Buffer[m_Position++] = data;
			return this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BinaryBufferWriter Write(short data)
		{
			EnsureCapacity(2);
			m_Buffer[m_Position++] = (byte)data;
			m_Buffer[m_Position++] = (byte)(data >> 8);
			return this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BinaryBufferWriter Write(ushort data)
		{
			EnsureCapacity(2);
			m_Buffer[m_Position++] = (byte)data;
			m_Buffer[m_Position++] = (byte)(data >> 8);
			return this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BinaryBufferWriter Write(int data)
		{
			EnsureCapacity(4);
			m_Buffer[m_Position++] = (byte)data;
			m_Buffer[m_Position++] = (byte)(data >> 8);
			m_Buffer[m_Position++] = (byte)(data >> 16);
			m_Buffer[m_Position++] = (byte)(data >> 24);
			return this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BinaryBufferWriter Write(uint data)
		{
			EnsureCapacity(4);
			m_Buffer[m_Position++] = (byte)data;
			m_Buffer[m_Position++] = (byte)(data >> 8);
			m_Buffer[m_Position++] = (byte)(data >> 16);
			m_Buffer[m_Position++] = (byte)(data >> 24);
			return this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BinaryBufferWriter Write(long data)
		{
			EnsureCapacity(8);
			m_Buffer[m_Position++] = (byte)data;
			m_Buffer[m_Position++] = (byte)(data >> 8);
			m_Buffer[m_Position++] = (byte)(data >> 16);
			m_Buffer[m_Position++] = (byte)(data >> 24);
			m_Buffer[m_Position++] = (byte)(data >> 32);
			m_Buffer[m_Position++] = (byte)(data >> 40);
			m_Buffer[m_Position++] = (byte)(data >> 48);
			m_Buffer[m_Position++] = (byte)(data >> 56);
			return this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BinaryBufferWriter Write(ulong data)
		{
			EnsureCapacity(8);
			m_Buffer[m_Position++] = (byte)data;
			m_Buffer[m_Position++] = (byte)(data >> 8);
			m_Buffer[m_Position++] = (byte)(data >> 16);
			m_Buffer[m_Position++] = (byte)(data >> 24);
			m_Buffer[m_Position++] = (byte)(data >> 32);
			m_Buffer[m_Position++] = (byte)(data >> 40);
			m_Buffer[m_Position++] = (byte)(data >> 48);
			m_Buffer[m_Position++] = (byte)(data >> 56);
			return this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BinaryBufferWriter Write(string data)
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

				EnsureCapacity(length);
				for(int x = 0; x < length; ++x)
				{
					m_Buffer[m_Position++] = bytes[x];
				}
			}
			return this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BinaryBufferWriter Write(float data)
		{
			EnsureCapacity(4);
			byte[] bytes = BitConverter.GetBytes(data); //allocates memory, but I couldn't find a better way of doing this
			m_Buffer[m_Position++] = bytes[0];
			m_Buffer[m_Position++] = bytes[1];
			m_Buffer[m_Position++] = bytes[2];
			m_Buffer[m_Position++] = bytes[3];
			return this;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BinaryBufferWriter Write(double data)
		{
			long value = BitConverter.DoubleToInt64Bits(data);
			Write(value);
			return this;
		}
		#endregion
	}
}
