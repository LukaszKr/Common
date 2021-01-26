using System;
using NUnit.Framework;
using ProceduralLevel.Common.Buffer;

namespace Tests.Buffer
{
	[TestFixture]
	public class BufferTest
	{
		private BinaryBufferWriter m_Writer;
		private BinaryBufferReader m_Reader;

		[SetUp]
		public void Initialize()
		{
			m_Writer = new BinaryBufferWriter(1024);
			m_Reader = new BinaryBufferReader(m_Writer.Buffer);
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

		#region Helper
		private void TestReadWrite<TData>(Func<TData, BinaryBufferWriter> write, Func<TData> read, int size, params TData[] values)
		{
			int length = values.Length;
			for(int x = 0; x < length; ++x)
			{
				write(values[x]);
			}
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
