using System;
using System.Collections.Generic;

namespace ProceduralLevel.Common.Collection
{
	public readonly struct UID<T> : IComparable<UID<T>>, IEquatable<UID<T>>
		where T : class
	{
		public readonly int Value;

		#region Operators
		public static bool operator ==(UID<T> l, UID<T> r)
		{
			return l.Value == r.Value;
		}

		public static bool operator !=(UID<T> l, UID<T> r)
		{
			return l.Value != r.Value;
		}
		#endregion

		public UID(int value)
		{
			Value = value;
		}

		#region Equals
		public override bool Equals(object other)
		{
			if(other is UID<T> otherID)
			{
				return otherID.Value == Value;
			}
			return false;
		}

		public bool Equals(UID<T> other)
		{
			return Value == other.Value;
		}
		#endregion

		#region Compare
		public int CompareTo(UID<T> other)
		{
			return Value.CompareTo(other.Value);
		}
		#endregion

		public override int GetHashCode()
		{
			return Value;
		}

		public override string ToString()
		{
			return $"({typeof(T).Name}, {Value})";
		}
	}

	public class UniqueIDComparer<T> : IEqualityComparer<UID<T>>
		where T : class
	{
		public static readonly UniqueIDComparer<T> Instance = new UniqueIDComparer<T>();

		private UniqueIDComparer()
		{
		}

		public bool Equals(UID<T> x, UID<T> y)
		{
			return x.Value == y.Value;
		}

		public int GetHashCode(UID<T> obj)
		{
			return obj.Value;
		}
	}
}
