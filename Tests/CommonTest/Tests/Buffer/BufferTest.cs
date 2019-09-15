using NUnit.Framework;
using ProceduralLevel.Common.Buffer;
using System;

namespace ProceduralLevel.Common.Tests.Buffer
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
		public void Bool()
		{
			TestPrimitive(m_Buffer.Write, m_Buffer.ReadBool, 1, true, false);
		}

		[Test]
		public void Byte()
		{
			TestPrimitive(m_Buffer.Write, m_Buffer.ReadByte, 1, byte.MinValue, byte.MaxValue);
		}

		[Test]
		public void Short()
		{
			TestPrimitive(m_Buffer.Write, m_Buffer.ReadShort, 2, short.MinValue, short.MaxValue);
		}

		[Test]
		public void UShort()
		{
			TestPrimitive(m_Buffer.Write, m_Buffer.ReadUShort, 2, ushort.MinValue, ushort.MaxValue);
		}

		[Test]
		public void Int()
		{
			TestPrimitive(m_Buffer.Write, m_Buffer.ReadInt, 4, int.MinValue, int.MaxValue);
		}

		[Test]
		public void UInt()
		{
			TestPrimitive(m_Buffer.Write, m_Buffer.ReadUInt, 4, uint.MinValue, uint.MaxValue);
		}

		[Test]
		public void Long()
		{
			TestPrimitive(m_Buffer.Write, m_Buffer.ReadLong, 8, long.MinValue, long.MaxValue);
		}

		[Test]
		public void ULong()
		{
			TestPrimitive(m_Buffer.Write, m_Buffer.ReadULong, 8, ulong.MinValue, ulong.MaxValue);
		}

		[Test]
		public void String()
		{
			string str = "Hello World";
			m_Buffer.Write(str);
			Assert.AreEqual(str.Length+4, m_Buffer.Length); //str length + str content
			Assert.AreEqual(str, m_Buffer.ReadString());
			AssertPostTest();
		}

		#region Helper
		private void TestPrimitive<TPrimitive>(Func<TPrimitive, BinaryDataBuffer> write, Func<TPrimitive> read, int size, params TPrimitive[] values)
		{
			int length = values.Length;
			for(int x = 0; x < length; ++x)
			{
				write(values[x]);
			}
			Assert.AreEqual(size*length, m_Buffer.Length);
			for(int x = 0; x < length; ++x)
			{
				Assert.AreEqual(values[x], read());
			}
			AssertPostTest();
		}

		private void AssertPostTest()
		{
			Assert.AreEqual(0, m_Buffer.UnreadCount);
		}
		#endregion
	}
}
