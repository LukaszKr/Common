using System;

namespace ProceduralLevel.Common.SimpleID
{
	public class ID: IComparable<ID>, IEquatable<ID>
	{
		public readonly uint Value;
		public readonly string Name;

		public ID(uint value, string name)
		{
			Value = value;
			Name = name;
		}

		public int CompareTo(ID other)
		{
			return Value.CompareTo(other.Value);
		}

		public bool Equals(ID other)
		{
			return Value == other.Value;
		}

		public override string ToString()
		{
			return string.Format("[{0}, {1}]", Value.ToString(), Name);
		}
	}
}
