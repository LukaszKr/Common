namespace ProceduralLevel.Common.Grid
{
	public class DataGrid3D<TCell>
	{
		protected TCell[] m_Cells;
		protected GridSize3D m_Size;
		protected GridIterator3D m_Iterator;

		public TCell[] Cells { get { return m_Cells; } }
		public GridSize3D Size { get { return m_Size; } }
		public GridIterator3D Iterator { get { return m_Iterator; } }
		public int Length { get { return m_Size.Length; } }

		public DataGrid3D()
		{
		}

		public DataGrid3D(GridSize3D size)
		{
			SetSize(size);
		}

		public TCell Get(int x, int y, int z)
		{
			GridCoord3D coord = new GridCoord3D(m_Size, x, y, z);
			return Get(coord);
		}

		public TCell Get(GridPoint3D point)
		{
			GridCoord3D coord = new GridCoord3D(m_Size, point);
			return Get(coord);
		}

		public TCell Get(GridCoord3D coord)
		{
			if(m_Cells.Length <= coord.Index)
			{
				throw new System.Exception();
			}
			return m_Cells[coord.Index];
		}

		public void Set(TCell cell, int x, int y, int z)
		{
			GridCoord3D coord = new GridCoord3D(m_Size, x, y, z);
			Set(cell, coord);
		}

		public void Set(TCell cell, GridPoint3D point)
		{
			GridCoord3D coord = new GridCoord3D(m_Size, point.X, point.Y, point.Z);
			Set(cell, coord);
		}

		public void Set(TCell cell, GridCoord3D coord)
		{
			if(m_Cells.Length <= coord.Index)
			{
				throw new System.Exception();
			}
			m_Cells[coord.Index] = cell;
		}

		public void SetSize(int x, int y, int z)
		{
			SetSize(new GridSize3D(x, y, z));
		}

		public virtual void SetSize(GridSize3D size)
		{
			m_Size = size;
			m_Iterator = new GridIterator3D(size);
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

		public GridCoord3D GetCoord(int index)
		{
			return new GridCoord3D(m_Size, index);
		}
	}
}
