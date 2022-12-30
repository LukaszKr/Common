using ProceduralLevel.Common.Ext;

namespace ProceduralLevel.Common.Grid
{
	public class DataGrid3D<TCell>
	{
		public readonly TCell[][][] Cells;
		public readonly GridSize3D Size;

		public DataGrid3D(int x, int y, int z)
			: this(new GridSize3D(x, y, z))
		{

		}

		public DataGrid3D(GridSize3D size)
		{
			Size = size;
			Cells = ArrayExt.Create<TCell>(size);
		}

		#region Get
		public TCell Get(GridPoint3D point)
		{
			return Cells[point.X][point.Y][point.Z];
		}
		#endregion

		#region Set
		public void Set(TCell cell, GridPoint3D point)
		{
			Cells[point.X][point.Y][point.Z] = cell;
		}

		public void SetAll(TCell cell)
		{
			for(int x = 0; x < Cells.Length; ++x)
			{
				TCell[][] xArray = Cells[x];
				for(int y = 0; y < xArray.Length; ++y)
				{
					TCell[] yArray = xArray[y];
					for(int z = 0; z < yArray.Length; ++z)
					{
						yArray[z] = cell;
					}
				}
			}
		}
		#endregion
	}
}
