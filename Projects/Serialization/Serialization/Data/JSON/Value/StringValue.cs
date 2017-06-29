using System.Text;

namespace ProceduralLevel.Serialization.Json
{
	public class StringValue: AValue<string>
	{
		public StringValue(string data) 
			: base(EValueType.String, data)
		{
		}

		public override void ToString(StringBuilder sb, bool formatted)
		{
			sb.Append(JsonConst.QUOTE).Append(Data).Append(JsonConst.QUOTE);
		}
	}
}
