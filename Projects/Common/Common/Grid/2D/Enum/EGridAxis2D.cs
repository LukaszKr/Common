using ProceduralLevel.Common.Ext;

namespace ProceduralLevel.Common.Grid
{
	public enum EGridAxis2D: byte
	{
		X = 0,
		Y = 1,
	}

	public static class EGridAxis2DExt
	{
		public static readonly EnumExt<EGridAxis2D> Meta = new EnumExt<EGridAxis2D>();

		public static EGridAxis2D GetOther(this EGridAxis2D axis)
		{
			return (axis == EGridAxis2D.X ? EGridAxis2D.Y : EGridAxis2D.X);
		}
	}
}
