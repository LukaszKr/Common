using System;

namespace ProceduralLevel.Common.Collision2D
{
	public static partial class Detection
	{
		#region Point to...
		public static EOrientation Orientation(Point point, Line line)
		{
			return (EOrientation)Math.Sign((line.B.X-line.A.X)*(point.Y-line.A.Y)-(line.B.Y-line.A.Y)*(point.X-line.A.X));
		}
		#endregion
	}
}
