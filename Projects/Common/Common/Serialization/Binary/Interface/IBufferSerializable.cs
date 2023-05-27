using System.IO;

namespace ProceduralLevel.Common.Serialization.Binary
{
	public interface IBufferSerializable
	{
		void WriteToBuffer(BinaryWriter writer);
	}

	public static class IBufferSerializableExt
	{
		public static byte[] WriteToByteArray(this IBufferSerializable serializable)
		{
			using(MemoryStream stream = new MemoryStream())
			{
				using(BinaryWriter writer = new BinaryWriter(stream))
				{
					serializable.WriteToBuffer(writer);
				}
				return stream.ToArray();
			}
		}
	}
}
