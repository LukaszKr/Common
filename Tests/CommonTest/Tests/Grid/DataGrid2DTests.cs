using NUnit.Framework;
using ProceduralLevel.Common.Grid;

namespace Tests.Grid
{
	[TestFixture]
	public class DataGrid2DTests
	{
		[Test]
		public void SetAll()
		{
			DataGrid2D<int> grid = new DataGrid2D<int>(3, 4);
			grid.SetAll(1);
		}
	}
}
