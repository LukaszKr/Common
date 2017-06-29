namespace ProceduralLevel.Serialization.Json
{
	public class StringValue: Value<string>
	{
		public StringValue(string value) 
			: base(EValueType.String, value)
		{
		}
	}
}
