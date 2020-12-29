using NUnit.Framework;
using ProceduralLevel.Common.Grid;

namespace Tests.Grid
{
	[TestFixture]
	public class Bounds3DTests
	{
		[Test]
		public void Intersects()
		{
			GridBounds3D bound = new GridBounds3D(0, 0, 0, 5, 5, 5);

			Assert.IsFalse(bound.Intersects(new GridBounds3D(0, 0, 6, 1, 1, 7)));
			Assert.IsTrue(bound.Intersects(new GridBounds3D(0, 0, 4, 1, 1, 7)));
			Assert.IsTrue(bound.Intersects(new GridBounds3D(-2, -2, -2, 0, 0, 1)));
		}
	}
}
