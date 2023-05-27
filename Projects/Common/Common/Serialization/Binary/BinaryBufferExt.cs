using System.IO;
using ProceduralLevel.Common.Grid;

namespace ProceduralLevel.Common.Serialization.Binary
{
	public static class BinaryBufferExt
	{
		#region Array
		public static BinaryReader ToBinaryReader(this byte[] array)
		{
			MemoryStream stream = new MemoryStream(array);
			return new BinaryReader(stream);
		}
		#endregion

		#region GridIndex3D
		public static void WriteToBuffer(this GridIndex3D index, BinaryWriter writer)
		{
			writer.Write(index.X);
			writer.Write(index.Y);
			writer.Write(index.Z);
		}

		public static GridIndex3D ReadGridIndex3D(this BinaryReader reader)
		{
			int sizeX = reader.ReadInt32();
			int sizeY = reader.ReadInt32();
			int sizeZ = reader.ReadInt32();
			return new GridIndex3D(sizeX, sizeY, sizeZ);
		}
		#endregion

		#region GridSize2D
		public static void WriteToBuffer(this GridSize2D size, BinaryWriter writer)
		{
			writer.Write(size.X);
			writer.Write(size.Y);
		}

		public static GridSize2D ReadGridSize2D(this BinaryReader reader)
		{
			int sizeX = reader.ReadInt32();
			int sizeY = reader.ReadInt32();
			return new GridSize2D(sizeX, sizeY);
		}
		#endregion

		#region GridSize3D
		public static void WriteToBuffer(this GridSize3D size, BinaryWriter writer)
		{
			writer.Write(size.X);
			writer.Write(size.Y);
			writer.Write(size.Z);
		}

		public static GridSize3D ReadGridSize3D(this BinaryReader reader)
		{
			int sizeX = reader.ReadInt32();
			int sizeY = reader.ReadInt32();
			int sizeZ = reader.ReadInt32();
			return new GridSize3D(sizeX, sizeY, sizeZ);
		}
		#endregion
	}
}
