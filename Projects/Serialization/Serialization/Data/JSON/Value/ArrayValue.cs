using System.Text;

namespace ProceduralLevel.Serialization.Json
{
	public class ArrayValue: AValue<JsonArray>
	{
		public ArrayValue(JsonArray data) 
			: base(EValueType.Array, data)
		{
		}

		public override void ToString(StringBuilder sb, bool formatted)
		{
			Data.ToString(sb, formatted);
		}
	}
}
