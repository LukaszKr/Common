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
		public void String()
		{
			string str = "Hello World";
			m_Buffer.Write(str);
			Assert.AreEqual(str.Length+4, m_Buffer.Length); //str length + str content
			Assert.AreEqual(str, m_Buffer.ReadString());
			Assert.AreEqual(0, m_Buffer.UnreadCount);
		}
	}
}
