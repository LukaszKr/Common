namespace ProceduralLevel.Serialization.Json
{
	public class NumberValue: Value<string>
	{
		public NumberValue(string value) 
			: base(EValueType.Number, value)
		{
		}
	}
}
