using NUnit.Framework;
using ProceduralLevel.Common.Buffer;

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
			m_Buffer.Write(true);
			m_Buffer.Write(false);
			Assert.AreEqual(2, m_Buffer.Length);
			Assert.IsTrue(m_Buffer.ReadBool());
			Assert.IsFalse(m_Buffer.ReadBool());
			AssertPostTest();
		}

		[Test]
		public void Byte()
		{
			byte val = 4;
			m_Buffer.Write(val);
			Assert.AreEqual(1, m_Buffer.Length);
			Assert.AreEqual(val, m_Buffer.ReadByte());
			AssertPostTest();
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

		private void AssertPostTest()
		{
			Assert.AreEqual(0, m_Buffer.UnreadCount);
		}
	}
}
