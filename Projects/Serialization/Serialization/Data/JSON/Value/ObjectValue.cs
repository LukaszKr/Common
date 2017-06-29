using System.Text;

namespace ProceduralLevel.Serialization.Json
{
	public class ObjectValue: AValue<JsonObject>
	{
		public ObjectValue(JsonObject data) 
			: base(EValueType.Object, data)
		{
		}

		public override void ToString(StringBuilder sb, bool formatted)
		{
			Data.ToString(sb, formatted);
		}
	}
}
