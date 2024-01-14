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
		public TCell Get<TIndex>(TIndex index)
			where TIndex : IGridIndex3D
		{
			return Cells[index.X][index.Y][index.Z];
		}
		#endregion

		#region Set
		public void Set<TIndex>(TIndex index, TCell cell)
			where TIndex : IGridIndex3D
		{
			Cells[index.X][index.Y][index.Z] = cell;
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
