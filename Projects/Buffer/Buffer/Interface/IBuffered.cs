namespace ProceduralLevel.Common.Buffer
{
	public interface IBuffered: IBufferSerialized, IBufferDeserialized
	{
	}

	public interface IBuffered<TData>: IBufferSerialized, IBufferDeserialized<TData>
	{
	}
}
