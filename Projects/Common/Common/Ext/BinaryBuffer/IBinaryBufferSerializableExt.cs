using System.IO;

namespace ProceduralLevel.Common.Ext
{
	public static class IBufferSerializableExt
	{
		public static byte[] WriteToByteArray(this IBinarySerializable serializable)
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
