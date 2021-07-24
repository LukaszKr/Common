using ProceduralLevel.Common.Ext;

namespace ProceduralLevel.Common.Grid
{
	public enum EDirection2D : byte
	{
		Up = 0,
		Down = 1,
		Left = 2,
		Right = 3
	}

	public static class EDirection2DExt
	{
		public static readonly EnumExt<EDirection2D> Meta = new EnumExt<EDirection2D>();

		#region Opposite
		private static readonly EDirection2D[] m_Opposite = new EDirection2D[]
		{
			EDirection2D.Down,
			EDirection2D.Up,
			EDirection2D.Right,
			EDirection2D.Left
		};

		public static EDirection2D GetOpposite(this EDirection2D direction)
		{
			return m_Opposite[(int)direction];
		}
		#endregion

		#region Axes
		private static readonly EGridAxis2D[] m_Axes = new EGridAxis2D[]
		{
			EGridAxis2D.Y, EGridAxis2D.Y,
			EGridAxis2D.X, EGridAxis2D.X
		};

		public static EGridAxis2D ToAxis(this EDirection2D direction)
		{
			return m_Axes[(int)direction];
		}
		#endregion
	}
}
