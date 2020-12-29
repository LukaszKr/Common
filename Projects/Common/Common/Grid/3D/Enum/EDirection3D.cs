using System;

namespace ProceduralLevel.Common.Grid
{
	public enum EDirection3D: byte
	{
		Up = 0,
		Down = 1,
		Left = 2,
		Right = 3,
		Forward = 4,
		Back = 5
	}

	public static class EDirection3DExt
	{
		public static readonly EDirection3D[] Values = (EDirection3D[])Enum.GetValues(typeof(EDirection3D));

		#region Opposite
		private static readonly EDirection3D[] m_Opposite = new EDirection3D[]
		{
			EDirection3D.Down,
			EDirection3D.Up,
			EDirection3D.Right,
			EDirection3D.Left,
			EDirection3D.Back,
			EDirection3D.Forward
		};

		public static EDirection3D GetOpposite(this EDirection3D direction)
		{
			return m_Opposite[(int)direction];
		}
		#endregion
	}
}
