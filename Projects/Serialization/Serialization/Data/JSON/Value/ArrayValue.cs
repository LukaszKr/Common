namespace ProceduralLevel.Serialization.Json
{
	public class ArrayValue: Value<JsonArray>
	{
		public ArrayValue(JsonArray value) 
			: base(EValueType.Array, value)
		{
		}
	}
}
