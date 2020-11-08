using NUnit.Framework;
using ProceduralLevel.Common.Buffer;
using System;

namespace Tests.Buffer
{
	[TestFixture]
	public class BufferTest
	{
		private BinaryDataBuffer m_Buffer;

		[SetUp]
		public void Initialize()
		{
			m_Buffer = new BinaryDataBuffer(1024);
		}

		[Test]
		public void Char()
		{
			TestReadWrite(m_Buffer.Write, m_Buffer.ReadChar, 1, 'a', 'z');
		}

		[Test]
		public void Bool()
		{
			TestReadWrite(m_Buffer.Write, m_Buffer.ReadBool, 1, true, false);
		}

		[Test]
		public void Byte()
		{
			TestReadWrite(m_Buffer.Write, m_Buffer.ReadByte, 1, byte.MinValue, byte.MaxValue);
		}

		[Test]
		public void Short()
		{
			TestReadWrite(m_Buffer.Write, m_Buffer.ReadShort, 2, short.MinValue, short.MaxValue);
		}

		[Test]
		public void UShort()
		{
			TestReadWrite(m_Buffer.Write, m_Buffer.ReadUShort, 2, ushort.MinValue, ushort.MaxValue);
		}

		[Test]
		public void Int()
		{
			TestReadWrite(m_Buffer.Write, m_Buffer.ReadInt, 4, int.MinValue, int.MaxValue);
		}

		[Test]
		public void UInt()
		{
			TestReadWrite(m_Buffer.Write, m_Buffer.ReadUInt, 4, uint.MinValue, uint.MaxValue);
		}

		[Test]
		public void Long()
		{
			TestReadWrite(m_Buffer.Write, m_Buffer.ReadLong, 8, long.MinValue, long.MaxValue);
		}

		[Test]
		public void ULong()
		{
			TestReadWrite(m_Buffer.Write, m_Buffer.ReadULong, 8, ulong.MinValue, ulong.MaxValue);
		}

		[Test]
		public void String()
		{
			string str = "Hello World";
			TestReadWrite(m_Buffer.Write, m_Buffer.ReadString, str.Length+4, str);
		}

		[Test]
		public void Guid()
		{
			Guid g = System.Guid.NewGuid();
			TestReadWrite(m_Buffer.Write, m_Buffer.ReadGuid, 16, g);
		}

		[Test]
		public void Chunk()
		{
			const int BYTE_COUNT = 15;
			BufferChunk chunk = m_Buffer.CreateChunk();
			byte emptyByte = 0;
			for(int x = 0; x < BYTE_COUNT; ++x)
			{
				m_Buffer.Write(emptyByte);
			}
			Assert.AreEqual(m_Buffer.Position, BYTE_COUNT+4);
			Assert.AreEqual(chunk.Length, BYTE_COUNT);
			
			int position = m_Buffer.Position;
			chunk.Save();
			Assert.AreEqual(position, m_Buffer.Position);

			m_Buffer.Seek(0);
			int groupSize = m_Buffer.ReadInt();
			Assert.AreEqual(BYTE_COUNT, groupSize);
		}

		#region Helper
		private void TestReadWrite<TData>(Func<TData, BinaryDataBuffer> write, Func<TData> read, int size, params TData[] values)
		{
			int length = values.Length;
			for(int x = 0; x < length; ++x)
			{
				write(values[x]);
			}
			int position = m_Buffer.Position;
			Assert.AreEqual(size*length, position);
			m_Buffer.Seek(0);
			for(int x = 0; x < length; ++x)
			{
				Assert.AreEqual(values[x], read());
			}
			Assert.AreEqual(position, m_Buffer.Position);
		}
		#endregion
	}
}
