using NUnit.Framework;
using ProceduralLevel.Common.BitMask;

namespace ProceduralLevel.Common.Tests.BitMask
{
	[TestFixture]
	public class BitMaskTest
	{
		private BitMask128 m_Buffer;

		[SetUp]
		public void Initialize()
		{
			m_Buffer = new BitMask128();
		}

		[Test]
		public void SetGet()
		{
			m_Buffer.Set(63, true);
			m_Buffer.Set(64, true);
			m_Buffer.Set(65, true);

			Assert.IsFalse(m_Buffer.Get(62));
			Assert.IsTrue(m_Buffer.Get(63));
			Assert.IsTrue(m_Buffer.Get(64));
			Assert.IsTrue(m_Buffer.Get(65));
		}

		[Test]
		public void ToggleBit()
		{
			m_Buffer.Set(32);
			m_Buffer.Set(33);

			Assert.IsTrue(m_Buffer.Get(33));
			m_Buffer.Toggle(33);
			Assert.IsTrue(m_Buffer.Get(32));
			Assert.IsFalse(m_Buffer.Get(33));
			m_Buffer.Toggle(33);
			Assert.IsTrue(m_Buffer.Get(33));
		}

		[Test]
		public void ClearBit()
		{
			m_Buffer.Set(33);

			m_Buffer.Clear(32);
			m_Buffer.Clear(33);
			Assert.IsFalse(m_Buffer.Get(32));
			Assert.IsFalse(m_Buffer.Get(33));

		}
	}
}
