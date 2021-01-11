using ProceduralLevel.Common.Ext;

namespace ProceduralLevel.Common.Grid
{
	public enum EDirection3D: byte
	{
		Up = 0,
		Down = 1,
		Left = 2,
		Right = 3,
		Front = 4,
		Back = 5
	}

	public static class EDirection3DExt
	{
		public static readonly EnumExt<EDirection3D> Meta = new EnumExt<EDirection3D>();

		#region Opposite
		private static readonly EDirection3D[] m_Opposite = new EDirection3D[]
		{
			EDirection3D.Down,
			EDirection3D.Up,
			EDirection3D.Right,
			EDirection3D.Left,
			EDirection3D.Back,
			EDirection3D.Front
		};

		public static EDirection3D GetOpposite(this EDirection3D direction)
		{
			return m_Opposite[(int)direction];
		}
		#endregion

		#region Axes
		private static readonly EGridAxis3D[] m_Axes = new EGridAxis3D[]
		{
			EGridAxis3D.Y, EGridAxis3D.Y,
			EGridAxis3D.X, EGridAxis3D.X,
			EGridAxis3D.Z, EGridAxis3D.Z
		};

		public static EGridAxis3D ToAxis(this EDirection3D direction)
		{
			return m_Axes[(int)direction];
		}
		#endregion
	}
}
