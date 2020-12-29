using NUnit.Framework;
using ProceduralLevel.Common.Grid;

namespace Tests.Grid
{
	[TestFixture]
	public class Coord2DTests
	{
		[Test]
		public void GridTraversal()
		{
			GridSize2D size = new GridSize2D(5, 6);
			GridCoord2D coord = new GridCoord2D(size, 3, 3);
			GridIterator2D traversal = new GridIterator2D(size);

			GridCoord2D changed = new GridCoord2D(size, coord.Index+traversal.Y);
			AssertPoint(changed.Point, 3, 4);
			changed = new GridCoord2D(size, coord.Index-traversal.Y);
			AssertPoint(changed.Point, 3, 2);

			changed = new GridCoord2D(size, coord.Index+traversal.X);
			AssertPoint(changed.Point, 4, 3);
			changed = new GridCoord2D(size, coord.Index-traversal.X);
			AssertPoint(changed.Point, 2, 3);
		}

		[Test]
		public void CoordConstructor()
		{
			AssertIndexCalculation(new GridSize2D(5, 5), 2, 3);
			AssertIndexCalculation(new GridSize2D(4, 6), 2, 3);
			AssertIndexCalculation(new GridSize2D(6, 4), 2, 3);
		}

		#region Helper
		private void AssertIndexCalculation(GridSize2D gridSize, int x, int y)
		{
			GridCoord2D coord = new GridCoord2D(gridSize, x, y);
			GridCoord2D index = new GridCoord2D(gridSize, coord.Index);
			AssertPoint(coord.Point, index.Point.X, index.Point.Y);
		}

		private void AssertPoint(GridPoint2D point, int x, int y)
		{
			Assert.AreEqual(x, point.X);
			Assert.AreEqual(y, point.Y);
		}
		#endregion
	}
}
