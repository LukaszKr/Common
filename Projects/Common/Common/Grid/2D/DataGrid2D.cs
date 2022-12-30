using System;
using ProceduralLevel.Common.Ext;

namespace ProceduralLevel.Common.Grid
{
	public class DataGrid2D<TCell>
	{
		public readonly TCell[][] Cells;
		public readonly GridSize2D Size;

		public DataGrid2D(int x, int y)
			: this(new GridSize2D(x, y))
		{

		}

		public DataGrid2D(GridSize2D size)
		{
			Size = size;
			Cells = ArrayExt.Create<TCell>(size);
		}

		#region Get
		public TCell Get(GridIndex2D point)
		{
			return Cells[point.X][point.Y];
		}

		public int GetLine(TCell[] buffer, EGridAxis2D axis, int lineIndex)
		{
			switch(axis)
			{
				case EGridAxis2D.X:
					for(int x = 0; x < Cells.Length; ++x)
					{
						buffer[x] = Cells[x][lineIndex];
					}
					return Cells.Length;
				case EGridAxis2D.Y:
					TCell[] line = Cells[lineIndex];
					for(int x = 0; x < line.Length; ++x)
					{
						buffer[x] = line[x];
					}
					return line.Length;
				default:
					throw new NotImplementedException();
			}
		}
		#endregion

		#region Set
		public void Set(GridIndex2D point, TCell cell)
		{
			Cells[point.X][point.Y] = cell;
		}

		public void SetAll(TCell cell)
		{
			for(int x = 0; x < Cells.Length; ++x)
			{
				TCell[] xArray = Cells[x];
				for(int y = 0; y < xArray.Length; ++y)
				{
					xArray[y] = cell;
				}
			}
		}
		#endregion
	}
}
