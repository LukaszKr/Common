namespace ProceduralLevel.Common.Grid
{
	public class DataGrid3D<TCell>
	{
		public readonly TCell[] Cells;
		public readonly GridSize3D Size;
		public readonly GridIterator3D Iterator;

		public DataGrid3D(GridSize3D size)
		{
			Size = size;
			Iterator = new GridIterator3D(size);
			Cells = new TCell[size.Length];
		}

		#region Get
		public TCell Get(int x, int y, int z)
		{
			GridCoord3D coord = new GridCoord3D(Size, x, y, z);
			return Get(coord);
		}

		public TCell Get(GridPoint3D point)
		{
			GridCoord3D coord = new GridCoord3D(Size, point);
			return Get(coord);
		}

		public TCell Get(GridCoord3D coord)
		{
			if(Cells.Length <= coord.Index)
			{
				throw new System.Exception();
			}
			return Cells[coord.Index];
		}
		#endregion

		#region Set
		public void Set(TCell cell, int x, int y, int z)
		{
			GridCoord3D coord = new GridCoord3D(Size, x, y, z);
			Set(cell, coord);
		}

		public void Set(TCell cell, GridPoint3D point)
		{
			GridCoord3D coord = new GridCoord3D(Size, point.X, point.Y, point.Z);
			Set(cell, coord);
		}

		public void Set(TCell cell, GridCoord3D coord)
		{
			if(Cells.Length <= coord.Index)
			{
				throw new System.Exception();
			}
			Cells[coord.Index] = cell;
		}

		public void SetAll(TCell data)
		{
			for(int x = 0; x < Size.Length; ++x)
			{
				Cells[x] = data;
			}
		}
		#endregion
	}
}
