namespace ProceduralLevel.Serialization.Json
{
	public class ObjectValue: Value<JsonObject>
	{
		public ObjectValue(JsonObject value) 
			: base(EValueType.Object, value)
		{
		}
	}
}
