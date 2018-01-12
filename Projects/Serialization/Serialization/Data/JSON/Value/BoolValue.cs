using System.Text;

namespace ProceduralLevel.Common.Serialization.Json
{
    public class BoolValue: AValue<bool>
	{
		public BoolValue(bool data)
            : base(data)
		{
		}

		public override bool Equals(object obj)
		{
			BoolValue other = obj as BoolValue;
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
			sb.Append(Data.ToString());
		}
	}
}
