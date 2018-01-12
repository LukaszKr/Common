using System.Text;

namespace ProceduralLevel.Common.Serialization.Json
{
    public class StringValue: AValue<string>
	{
		public StringValue(string data) 
			: base(data)
		{
		}

		public override bool Equals(object obj)
		{
			StringValue other = obj as StringValue;
			if(other == null)
			{
				return false;
			}

			return Data.Equals(other.Data);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public override void ToString(StringBuilder sb, bool formatted)
		{
			sb.Append(JsonConst.QUOTE).Append(JsonConst.EscapeString(Data)).Append(JsonConst.QUOTE);
		}
	}
}
