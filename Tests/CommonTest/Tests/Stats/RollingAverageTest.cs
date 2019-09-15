using NUnit.Framework;
using ProceduralLevel.Common.Stats;

namespace ProceduralLevel.Common.Tests.Stats
{
	[TestFixture]
	public class RollingAverageTest
	{
		[Test]
		public void Basic()
		{
			RollingAverageInt average = new RollingAverageInt(4);
			average.Push(1);
			average.Push(3);
			Assert.AreEqual(2, average.Value);
		}

		[Test]
		public void RoundDown()
		{
			RollingAverageInt average = new RollingAverageInt(2);
			average.Push(1);
			average.Push(4);
			Assert.AreEqual(2, average.Value);
		}

		[Test]
		public void RollOver()
		{
			RollingAverageInt average = new RollingAverageInt(3);
			average.Push(1);
			average.Push(2);
			average.Push(3);
			Assert.AreEqual(2, average.Value); //(1+2+3)/3
			average.Push(4);
			Assert.AreEqual(3, average.Value); //(2+3+4)/3
		}
	}
}
