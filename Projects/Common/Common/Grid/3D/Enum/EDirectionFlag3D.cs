using System;

namespace ProceduralLevel.Common.Grid
{
	[Flags]
	public enum EDirectionFlag3D: byte
	{
		Up = 1 << 0,
		Down = 1 << 1,
		Left = 1 << 2,
		Right = 1 << 3,
		Front = 1 << 4,
		Back = 1 << 5,

		All = Up | Down | Left | Right | Front | Back
	}

	public static class EDirectionFlag3DExt
	{
		public readonly static EDirectionFlag3D[] Values = (EDirectionFlag3D[])Enum.GetValues(typeof(EDirectionFlag3D));

		public static bool Contains(this EDirectionFlag3D flag, EDirectionFlag3D other)
		{
			return (flag & other) == other;
		}
	}
}
