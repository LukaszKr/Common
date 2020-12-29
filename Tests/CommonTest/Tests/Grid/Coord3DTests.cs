using NUnit.Framework;
using ProceduralLevel.Common.Grid;

namespace Tests.Grid
{
	[TestFixture]
	public class Coord3DTests
	{
		[Test]
		public void GridTraversal()
		{
			GridSize3D size = new GridSize3D(5, 6, 7);
			GridCoord3D coord = new GridCoord3D(size, 3, 3, 3);
			GridIterator3D traversal = new GridIterator3D(size);

			GridCoord3D changed = new GridCoord3D(size, coord.Index+traversal.Y);
			AssertPoint(changed.Point, 3, 4, 3);
			changed = new GridCoord3D(size, coord.Index-traversal.Y);
			AssertPoint(changed.Point, 3, 2, 3);

			changed = new GridCoord3D(size, coord.Index+traversal.X);
			AssertPoint(changed.Point, 4, 3, 3);
			changed = new GridCoord3D(size, coord.Index-traversal.X);
			AssertPoint(changed.Point, 2, 3, 3);

			changed = new GridCoord3D(size, coord.Index+traversal.Z);
			AssertPoint(changed.Point, 3, 3, 4);
			changed = new GridCoord3D(size, coord.Index-traversal.Z);
			AssertPoint(changed.Point, 3, 3, 2);
		}

		[Test]
		public void CoordConstructor()
		{
			AssertIndexCalculation(new GridSize3D(5, 5, 7), 2, 3, 1);
			AssertIndexCalculation(new GridSize3D(4, 6, 4), 2, 3, 1);
			AssertIndexCalculation(new GridSize3D(6, 4, 5), 2, 3, 1);
		}

		#region Helper
		private void AssertIndexCalculation(GridSize3D gridSize, int x, int y, int z)
		{
			GridCoord3D coord = new GridCoord3D(gridSize, x, y, z);
			GridCoord3D index = new GridCoord3D(gridSize, coord.Index);
			AssertPoint(coord.Point, index.Point.X, index.Point.Y, index.Point.Z);
		}

		private void AssertPoint(GridPoint3D point, int x, int y, int z)
		{
			Assert.AreEqual(x, point.X);
			Assert.AreEqual(y, point.Y);
			Assert.AreEqual(z, point.Z);
		}
		#endregion
	}
}
