namespace ProceduralLevel.Serialization.Json
{
	public class Value<T>: AValue
	{
		public T Data;

		public Value(EValueType type, T data) : base(type)
		{
			Data = data;
		}
	}
}
