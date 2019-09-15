namespace ProceduralLevel.Common.Buffer
{
	public interface IBufferDeserialized
	{
		void FromDataBuffer(BinaryDataBuffer buffer);
	}

	public interface IBufferDeserialized<TData>
	{
		void FromDataBuffer(BinaryDataBuffer buffer, TData data);
	}
}
