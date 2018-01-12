using System.Text;

namespace ProceduralLevel.Serialization.Json
{
    public class ObjectValue: AValue<JsonObject>
	{
		public ObjectValue(JsonObject data) 
			: base(data)
		{
		}

		public override bool Equals(object obj)
		{
			ObjectValue other = obj as ObjectValue;
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
