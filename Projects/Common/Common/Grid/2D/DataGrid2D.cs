namespace ProceduralLevel.Common.Grid
{
	public class DataGrid2D<TCell>
	{
		public readonly TCell[] Cells;
		public readonly GridSize2D Size;
		public readonly GridIterator2D Iterator;

		public DataGrid2D(GridSize2D size)
		{
			Size = size;
			Iterator = new GridIterator2D(size);
			Cells = new TCell[size.Length];
		}

		#region Get
		public TCell Get(int x, int y)
		{
			GridCoord2D coord = new GridCoord2D(Size, x, y);
			return Get(coord);
		}

		public TCell Get(GridPoint2D point)
		{
			GridCoord2D coord = new GridCoord2D(Size, point);
			return Get(coord);
		}

		public TCell Get(GridCoord2D coord)
		{
			return Cells[coord.Index];
		}

		public int GetLine(TCell[] buffer, EGridAxis2D axis, int lineIndex)
		{
			int lineLength = Size.Get(axis);
			int iterator = Iterator.Get(axis);
			int cellIndex = Iterator.Get(axis.GetOther())*lineIndex;
			for(int x = 0; x < lineLength; ++x)
			{
				buffer[x] = Cells[cellIndex];
				cellIndex += iterator;
			}
			return lineLength;
		}
		#endregion

		#region Set
		public void Set(TCell cell, int x, int y)
		{
			GridCoord2D coord = new GridCoord2D(Size, x, y);
			Set(cell, coord);
		}

		public void Set(TCell cell, GridPoint2D point)
		{
			GridCoord2D coord = new GridCoord2D(Size, point);
			Set(cell, coord);
		}

		public void Set(TCell cell, GridCoord2D coord)
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
