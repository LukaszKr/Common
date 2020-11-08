namespace ProceduralLevel.Common.Buffer
{
	public class BufferChunk

	{
		public readonly BinaryDataBuffer Buffer;
		public readonly int SizePosition;
		public readonly int DataPosition;

		public int Length { get { return Buffer.Position-DataPosition; } }

		public BufferChunk(BinaryDataBuffer buffer)
		{
			Buffer = buffer;
			SizePosition = buffer.Position;
			buffer.Write(0);
			DataPosition = buffer.Position;
		}

		public void Save()
		{
			int position = Buffer.Position;
			int length = position-DataPosition;
			Buffer.Seek(SizePosition);
			Buffer.Write(length);
			Buffer.Seek(position);
		}
	}
}
