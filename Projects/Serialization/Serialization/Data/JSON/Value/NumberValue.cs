using System.Text;

namespace ProceduralLevel.Serialization.Json
{
	public class NumberValue: AValue<string>
	{
		public NumberValue(string data) 
			: base(EValueType.Number, data)
		{
		}

		public override void ToString(StringBuilder sb, bool formatted)
		{
			sb.Append(Data);
		}
	}
}
