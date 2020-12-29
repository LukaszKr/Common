using System;

namespace ProceduralLevel.Common.Grid
{
	public enum EGridAxis2D: byte
	{
		X = 0,
		Y = 1,
	}

	public static class EGridAxis2DExt
	{
		public static readonly EGridAxis2D[] Values = (EGridAxis2D[])Enum.GetValues(typeof(EGridAxis2D));
	}
}
