using System;
using ProceduralLevel.Common.Ext;

namespace ProceduralLevel.Common.Grid
{
	public enum EGridAxis3D : byte
	{
		X = 0,
		Y = 1,
		Z = 2
	}

	public static class EGridAxis3DExt
	{
		public static readonly EnumExt<EGridAxis3D> Meta = new EnumExt<EGridAxis3D>();

		public static EGridAxis3D GetRemainingAxis(EGridAxis3D a, EGridAxis3D b)
		{
			if(a != EGridAxis3D.Z && b != EGridAxis3D.Z)
			{
				return EGridAxis3D.Z;
			}
			else if(a != EGridAxis3D.Y && b != EGridAxis3D.Y)
			{
				return EGridAxis3D.Y;
			}
			else
			{
				return EGridAxis3D.X;
			}
		}
	}
}
