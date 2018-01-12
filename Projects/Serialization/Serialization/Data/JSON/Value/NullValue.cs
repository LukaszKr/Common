using System.Text;

namespace ProceduralLevel.Common.Serialization.Json
{
    public class NullValue: AValue
	{
		public const string NULL = "null";

		public NullValue() : base()
		{
		}

		public override bool Equals(object obj)
		{
			NullValue other = obj as NullValue;
			if(other == null)
			{
				return false;
			}
			return true;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public override void ToString(StringBuilder sb, bool formatted)
		{
			sb.Append(NULL);
		}
	}
}
