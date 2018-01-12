using System.Text;

namespace ProceduralLevel.Common.Serialization.Json
{
    public abstract class AValue
	{
		public void ToString(StringBuilder sb, string key, bool formatted)
		{
			sb.Append(JsonConst.QUOTE).Append(key).Append(JsonConst.QUOTE).Append(JsonConst.ASSIGN);
			if(formatted)
			{
				sb.Append(" ");
			}
			ToString(sb, formatted);
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			ToString(sb, true);
			return sb.ToString();
		}

		public abstract void ToString(StringBuilder sb, bool formatted);
	}

	public abstract class AValue<T>: AValue
	{
		public T Data;

		public AValue(T data) : base()
		{
			Data = data;
		}
	}
}
