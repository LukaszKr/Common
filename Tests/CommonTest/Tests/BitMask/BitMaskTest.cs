using NUnit.Framework;
using ProceduralLevel.Common.BitMask;

namespace Tests.BitMask
{
	[TestFixture]
	public class BitMaskTest
	{
		private BitMask128 m_Mask;

		[SetUp]
		public void Initialize()
		{
			m_Mask = new BitMask128();
		}

		[Test]
		public void NewMaskIsEmpty()
		{
			BitMask96 mask = new BitMask96();
			Assert.IsTrue(mask.IsEmpty());
		}

		[Test]
		public void EqualMask()
		{
			m_Mask.Clear();
			m_Mask.Set(5);
			BitMask128 otherMask = new BitMask128();
			otherMask.Set(5);

			Assert.IsTrue(m_Mask.Equals(otherMask));
			m_Mask.Set(4);
			Assert.IsFalse(m_Mask.Equals(otherMask));
		}

		[Test]
		public void CheckToString()
		{
			BitMask32 mask = new BitMask32();
			string actual = mask.ToString();
			string expected = "".PadLeft(BitMask32.LENGTH, '0');

			Assert.AreEqual(expected, actual);
			mask.Set(2);
			actual = mask.ToString();
			expected = expected.Substring(0, 29)+'1'+expected.Substring(30);
			Assert.AreEqual(expected, actual);

			Assert.AreEqual("0100", mask.ToString(4));
		}

		[Test]
		public void SetGet()
		{
			m_Mask.Set(63, true);
			m_Mask.Set(64, true);
			m_Mask.Set(65, true);

			Assert.IsFalse(m_Mask.Get(62));
			Assert.IsTrue(m_Mask.Get(63));
			Assert.IsTrue(m_Mask.Get(64));
			Assert.IsTrue(m_Mask.Get(65));
		}

		[Test]
		public void ToggleBit()
		{
			m_Mask.Set(32);
			m_Mask.Set(33);

			Assert.IsTrue(m_Mask.Get(33));
			m_Mask.Toggle(33);
			Assert.IsTrue(m_Mask.Get(32));
			Assert.IsFalse(m_Mask.Get(33));
			m_Mask.Toggle(33);
			Assert.IsTrue(m_Mask.Get(33));
		}

		[Test]
		public void ClearBit()
		{
			m_Mask.Set(33);

			m_Mask.Clear(32);
			m_Mask.Clear(33);
			Assert.IsFalse(m_Mask.Get(32));
			Assert.IsFalse(m_Mask.Get(33));
		}

		[Test]
		public void Contains()
		{
			m_Mask.Set(2);
			m_Mask.Set(3);

			BitMask128 otherMask = new BitMask128();
			otherMask.Set(3);

			Assert.IsTrue(m_Mask.Contains(otherMask));
			otherMask.Set(4);
			Assert.IsFalse(m_Mask.Contains(otherMask));
		}

		[Test]
		public void CopyByAssign()
		{
			BitMask128 mask = m_Mask;
			mask.Set(1);
			Assert.IsFalse(mask.Equals(m_Mask));
		}
	}
}
