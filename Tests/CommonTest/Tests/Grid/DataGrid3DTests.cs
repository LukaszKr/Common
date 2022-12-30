using NUnit.Framework;
using ProceduralLevel.Common.Grid;

namespace Tests.Grid
{
	[TestFixture]
	public class DataGrid3DTests
	{
		[Test]
		public void SetAll()
		{
			DataGrid3D<int> grid = new DataGrid3D<int>(3, 4, 5);
			grid.SetAll(1);
		}
	}
}
