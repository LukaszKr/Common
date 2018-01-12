using System.Text;

namespace ProceduralLevel.Common.Serialization.Json
{
    public class ArrayValue: AValue<JsonArray>
	{
		public ArrayValue(JsonArray data) 
			: base(data)
		{
		}

		public override bool Equals(object obj)
		{
			ArrayValue other = obj as ArrayValue;
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
			Data.ToString(sb, formatted);
		}
	}
}
