using System.IO;

namespace ProceduralLevel.Common.Ext
{
	public interface IBinarySerializable
	{
		void WriteToBuffer(BinaryWriter writer);
	}
}
