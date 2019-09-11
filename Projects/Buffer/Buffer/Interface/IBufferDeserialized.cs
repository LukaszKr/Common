namespace ProceduralLevel.Common.Buffer
{
	public interface IBufferDeserialized
	{
		void FromDataBuffer(ADataBuffer buffer);
	}

	public interface IBufferDeserialized<TData>
	{
		void FromDataBuffer(ADataBuffer buffer, TData data);
	}
}
