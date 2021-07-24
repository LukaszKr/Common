using System;
using NUnit.Framework;
using ProceduralLevel.Common.Buffer;

namespace Tests.Buffer
{
	[TestFixture]
	public class BufferTests
	{
		private BinaryBufferWriter m_Writer;
		private BinaryBufferReader m_Reader;

		[SetUp]
		public void Initialize()
		{
			m_Writer = new BinaryBufferWriter(64);
			m_Reader = new BinaryBufferReader(m_Writer.Buffer);
		}

		[Test]
		public void DynamicWriterBufferCanExpand()
		{
			int originalCapacity = m_Writer.Capacity;
			for(int x = 0; x < originalCapacity; ++x)
			{
				m_Writer.Write((byte)1);
			}
			Assert.AreEqual(0, m_Writer.RemainingCapacity);
			m_Writer.Write(1);
			Assert.IsTrue(originalCapacity < m_Writer.Capacity);
		}

		[Test]
		public void StaticWriterBufferCantExpand()
		{
			byte[] staticBuffer = new byte[64];
			BinaryBufferWriter writer = new BinaryBufferWriter(staticBuffer);
			int originalCapacity = writer.Capacity;
			for(int x = 0; x < originalCapacity; ++x)
			{
				writer.Write((byte)1);
			}
			Assert.AreEqual(0, writer.RemainingCapacity);
			Assert.Throws(typeof(IndexOutOfRangeException), () => writer.Write(1));

		}

		[Test]
		public void Char()
		{
			TestReadWrite(m_Writer.Write, m_Reader.ReadChar, 1, 'a', 'z');
		}

		[Test]
		public void Bool()
		{
			TestReadWrite(m_Writer.Write, m_Reader.ReadBool, 1, true, false);
		}

		[Test]
		public void Byte()
		{
			TestReadWrite(m_Writer.Write, m_Reader.ReadByte, 1, byte.MinValue, byte.MaxValue);
		}

		[Test]
		public void Short()
		{
			TestReadWrite(m_Writer.Write, m_Reader.ReadShort, 2, short.MinValue, short.MaxValue);
		}

		[Test]
		public void UShort()
		{
			TestReadWrite(m_Writer.Write, m_Reader.ReadUShort, 2, ushort.MinValue, ushort.MaxValue);
		}

		[Test]
		public void Int()
		{
			TestReadWrite(m_Writer.Write, m_Reader.ReadInt, 4, int.MinValue, int.MaxValue);
		}

		[Test]
		public void UInt()
		{
			TestReadWrite(m_Writer.Write, m_Reader.ReadUInt, 4, uint.MinValue, uint.MaxValue);
		}

		[Test]
		public void Long()
		{
			TestReadWrite(m_Writer.Write, m_Reader.ReadLong, 8, long.MinValue, long.MaxValue);
		}

		[Test]
		public void ULong()
		{
			TestReadWrite(m_Writer.Write, m_Reader.ReadULong, 8, ulong.MinValue, ulong.MaxValue);
		}

		[Test]
		public void String()
		{
			string str = "Hello World";
			TestReadWrite(m_Writer.Write, m_Reader.ReadString, str.Length+4, str);
		}

		[Test]
		public void Guid()
		{
			Guid g = System.Guid.NewGuid();
			TestReadWrite(m_Writer.Write, m_Reader.ReadGuid, 16, g);
		}

		[Test]
		public void BufferChunk()
		{
			m_Writer.Write(123);
			BinaryBufferChunk chunk = m_Writer.StartChunk();
			for(int x = 0; x < 5; ++x)
			{
				m_Writer.Write(x);
			}

			int length = chunk.WriteLength();
			m_Writer.Write(5);

			Assert.AreEqual(123, m_Reader.ReadInt());
			Assert.AreEqual(length, m_Reader.ReadInt());
			for(int x = 0; x < 6; ++x)
			{
				Assert.AreEqual(x, m_Reader.ReadInt());
			}
			Assert.AreEqual(m_Reader.Position, m_Writer.Position);
		}

		#region Helper
		private void TestReadWrite<TData>(Func<TData, BinaryBufferWriter> write, Func<TData> read, int size, params TData[] values)
		{
			Assert.AreEqual(m_Writer.Capacity, m_Writer.RemainingCapacity);
			int length = values.Length;
			for(int x = 0; x < length; ++x)
			{
				write(values[x]);
			}
			Assert.AreEqual(m_Writer.Capacity-size*values.Length, m_Writer.RemainingCapacity);

			int writtenCount = m_Writer.Position;
			Assert.AreEqual(size*length, writtenCount);
			for(int x = 0; x < length; ++x)
			{
				Assert.AreEqual(values[x], read());
			}
			Assert.AreEqual(writtenCount, m_Writer.Position);
			Assert.AreEqual(writtenCount, m_Reader.Position);
		}
		#endregion
	}
}
