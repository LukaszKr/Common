﻿using System;
using ProceduralLevel.Common.Buffer;

namespace ProceduralLevel.Common.Identity
{
	public readonly struct ID<T> : IEquatable<ID<T>>, IComparable<ID<T>>, IGenericID
	{
		public readonly int Value;

		public static bool operator ==(ID<T> left, ID<T> right) => (left.Value == right.Value);
		public static bool operator !=(ID<T> left, ID<T> right) => (left.Value != right.Value);

		public int GenericValue => Value;

		public ID(int value)
		{
			Value = value;
		}

		#region Serialziation
		public ID(BinaryBufferReader reader)
		{
			Value = reader.ReadInt();
		}

		public void WriteToBuffer(BinaryBufferWriter writer)
		{
			writer.Write(Value);
		}
		#endregion

		public override int GetHashCode()
		{
			return Value.GetHashCode();
		}

		public bool Equals(ID<T> other)
		{
			if(other != null)
			{
				return Value.Equals(other.Value);
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if(obj == null)
			{
				return false;
			}

			if(obj is ID<T> casted)
			{
				return casted.Value == Value;
			}

			return false;
		}

		public int CompareTo(ID<T> other)
		{
			return Value.CompareTo(other.Value);
		}

		public override string ToString()
		{
			return $"({Value})";
		}
	}
}