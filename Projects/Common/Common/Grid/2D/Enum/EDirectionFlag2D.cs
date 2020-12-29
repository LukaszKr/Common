using System;

namespace ProceduralLevel.Common.Grid
{
	[Flags]
	public enum EDirectionFlag2D: byte
	{
		Up = 1 << 0,
		Down = 1 << 1,
		Left = 1 << 2,
		Right = 1 << 3,

		All = Up | Down | Left | Right
	}

	public static class EDirectionFlag2DExt
	{
		public readonly static EDirectionFlag2D[] Values = (EDirectionFlag2D[])Enum.GetValues(typeof(EDirectionFlag2D));

		public static bool Contains(this EDirectionFlag2D flag, EDirectionFlag2D other)
		{
			return (flag & other) == other;
		}
	}
}
