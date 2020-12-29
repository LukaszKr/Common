using System;

namespace ProceduralLevel.Common.Grid
{
	public enum EDirection2D: byte
	{
		Up = 0,
		Down = 1,
		Left = 2,
		Right = 3
	}

	public static class EDirection2DExt
	{
		public static readonly EDirection2D[] Values = (EDirection2D[])Enum.GetValues(typeof(EDirection2D));

		#region Opposite
		private readonly static EDirection2D[] m_Opposite = new EDirection2D[]
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
	}
}
