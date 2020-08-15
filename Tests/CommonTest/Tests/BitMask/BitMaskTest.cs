using NUnit.Framework;
using ProceduralLevel.Common.BitMask;
using System.Diagnostics;

namespace ProceduralLevel.Common.Tests.BitMask
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
		public void Performace()
		{
			const int passes = 1000000;

			Stopwatch watch = new Stopwatch();
			watch.Restart();
			for(int x = 0; x < passes; ++x)
			{
				BitMask128 mask = new BitMask128();
				for(int y = 0; y < BitMask128.LENGTH; ++y)
				{
					mask.Set(y);
				}
			}
			TestContext.WriteLine($"128bitmask, {passes} passes, time elapsed: {watch.ElapsedMilliseconds}ms");
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
	}
}
