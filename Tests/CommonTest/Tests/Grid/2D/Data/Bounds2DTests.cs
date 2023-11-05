using NUnit.Framework;
using ProceduralLevel.Common.Grid;

namespace Tests.Grid
{
	[TestFixture]
	public class Bounds2DTests
	{
		[Test]
		public void Intersects()
		{
			GridBounds2D bound = new GridBounds2D(0, 0, 5, 5);

			Assert.IsFalse(bound.Intersects(new GridBounds2D(0, 6, 1, 7)));
			Assert.IsTrue(bound.Intersects(new GridBounds2D(0, 4, 1, 7)));
			Assert.IsTrue(bound.Intersects(new GridBounds2D(-2, -2, 0, 1)));
		}

		[Test]
		public void Contains()
		{
			GridBounds2D bounds = new GridBounds2D(5, 5);
			Assert.IsTrue(bounds.Contains(new GridIndex2D(0, 0)));
			Assert.IsTrue(bounds.Contains(new GridIndex2D(4, 4)));

			Assert.IsFalse(bounds.Contains(new GridIndex2D(-1, 0)));
			Assert.IsFalse(bounds.Contains(new GridIndex2D(0, -1)));
			Assert.IsFalse(bounds.Contains(new GridIndex2D(5, 4)));
			Assert.IsFalse(bounds.Contains(new GridIndex2D(4, 5)));
		}
	}
}
