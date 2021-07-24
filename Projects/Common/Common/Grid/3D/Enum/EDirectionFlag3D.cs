using System;
using ProceduralLevel.Common.Ext;

namespace ProceduralLevel.Common.Grid
{
	[Flags]
	public enum EDirectionFlag3D : byte
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
		public static readonly EnumExt<EDirectionFlag3D> Meta = new EnumExt<EDirectionFlag3D>();

		public static bool Contains(this EDirectionFlag3D flag, EDirectionFlag3D other)
		{
			return (flag & other) == other;
		}
	}
}
