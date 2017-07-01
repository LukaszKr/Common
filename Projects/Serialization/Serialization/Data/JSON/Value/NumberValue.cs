﻿using System.Text;

namespace ProceduralLevel.Serialization.Json
{
	public class NumberValue: AValue<string>
	{
		public NumberValue(string data) 
			: base(EValueType.Number, data)
		{
		}

		public override bool Equals(object obj)
		{
			NumberValue other = obj as NumberValue;
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
			sb.Append(Data);
		}
	}
}
