namespace ProceduralLevel.Common.Grid
{
	public class DataGrid2D<TCell>
	{
		protected TCell[] m_Cells;
		protected GridSize2D m_Size;
		protected GridIterator2D m_Iterator;

		public TCell[] Cells { get { return m_Cells; } }
		public GridSize2D Size { get { return m_Size; } }
		public GridIterator2D Iterator { get { return m_Iterator; } }
		public int Length { get { return m_Size.Length; } }

		public DataGrid2D()
		{
		}

		public DataGrid2D(GridSize2D size)
		{
			SetSize(size);
		}

		public TCell Get(int x, int y)
		{
			GridCoord2D coord = new GridCoord2D(m_Size, x, y);
			return Get(coord);
		}

		public TCell Get(GridPoint2D point)
		{
			GridCoord2D coord = new GridCoord2D(m_Size, point);
			return Get(coord);
		}

		public TCell Get(GridCoord2D coord)
		{
			if(m_Cells.Length <= coord.Index)
			{
				throw new System.Exception();
			}
			return m_Cells[coord.Index];
		}

		public void Set(TCell cell, int x, int y)
		{
			GridCoord2D coord = new GridCoord2D(m_Size, x, y);
			Set(cell, coord);
		}

		public void Set(TCell cell, GridPoint2D point)
		{
			GridCoord2D coord = new GridCoord2D(m_Size, point);
			Set(cell, coord);
		}

		public void Set(TCell cell, GridCoord2D coord)
		{
			if(m_Cells.Length <= coord.Index)
			{
				throw new System.Exception();
			}
			m_Cells[coord.Index] = cell;
		}

		public void SetSize(int x, int y)
		{
			SetSize(new GridSize2D(x, y));
		}

		public virtual void SetSize(GridSize2D size)
		{
			m_Size = size;
			m_Iterator = new GridIterator2D(size);
			if(m_Cells == null || m_Cells.Length < size.Length)
			{
				m_Cells = new TCell[size.Length];
			}
		}

		public void SetAll(TCell data)
		{
			int length = m_Size.Length;
			for(int x = 0; x < length; ++x)
			{
				m_Cells[x] = data;
			}
		}

		public GridCoord2D GetCoord(int index)
		{
			return new GridCoord2D(m_Size, index);
		}
	}
}
