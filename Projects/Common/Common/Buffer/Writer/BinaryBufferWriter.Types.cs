using System.Collections.Generic;

namespace ProceduralLevel.Common.Buffer
{
	public partial class BinaryBufferWriter
	{
		#region Char
		public BinaryBufferWriter Write(char[] arr)
		{
			return Write(arr, 0, arr.Length);
		}

		public BinaryBufferWriter Write(List<char> list)
		{
			return Write(list, 0, list.Count);
		}

		public BinaryBufferWriter Write(char[] arr, int offset, int length)
		{
			Write(length);
			for(int x = 0; x < length; ++x)
			{
				Write(arr[offset+x]);
			}
			return this;
		}

		public BinaryBufferWriter Write(List<char> list, int offset, int count)
		{
			Write(count);
			for(int x = 0; x < count; ++x)
			{
				Write(list[offset+x]);
			}
			return this;
		}
		#endregion

		#region Bool
		public BinaryBufferWriter Write(bool[] arr)
		{
			return Write(arr, 0, arr.Length);
		}

		public BinaryBufferWriter Write(List<bool> list)
		{
			return Write(list, 0, list.Count);
		}

		public BinaryBufferWriter Write(bool[] arr, int offset, int length)
		{
			Write(length);
			for(int x = 0; x < length; ++x)
			{
				Write(arr[offset+x]);
			}
			return this;
		}

		public BinaryBufferWriter Write(List<bool> list, int offset, int count)
		{
			Write(count);
			for(int x = 0; x < count; ++x)
			{
				Write(list[offset+x]);
			}
			return this;
		}
		#endregion

		#region Byte
		public BinaryBufferWriter Write(byte[] arr)
		{
			return Write(arr, 0, arr.Length);
		}

		public BinaryBufferWriter Write(List<byte> list)
		{
			return Write(list, 0, list.Count);
		}

		public BinaryBufferWriter Write(byte[] arr, int offset, int length)
		{
			Write(length);
			for(int x = 0; x < length; ++x)
			{
				Write(arr[offset+x]);
			}
			return this;
		}

		public BinaryBufferWriter Write(List<byte> list, int offset, int count)
		{
			Write(count);
			for(int x = 0; x < count; ++x)
			{
				Write(list[offset+x]);
			}
			return this;
		}
		#endregion

		#region Short
		public BinaryBufferWriter Write(short[] arr)
		{
			return Write(arr, 0, arr.Length);
		}

		public BinaryBufferWriter Write(List<short> list)
		{
			return Write(list, 0, list.Count);
		}

		public BinaryBufferWriter Write(short[] arr, int offset, int length)
		{
			Write(length);
			for(int x = 0; x < length; ++x)
			{
				Write(arr[offset+x]);
			}
			return this;
		}

		public BinaryBufferWriter Write(List<short> list, int offset, int count)
		{
			Write(count);
			for(int x = 0; x < count; ++x)
			{
				Write(list[offset+x]);
			}
			return this;
		}
		#endregion

		#region UShort
		public BinaryBufferWriter Write(ushort[] arr)
		{
			return Write(arr, 0, arr.Length);
		}

		public BinaryBufferWriter Write(List<ushort> list)
		{
			return Write(list, 0, list.Count);
		}

		public BinaryBufferWriter Write(ushort[] arr, int offset, int length)
		{
			Write(length);
			for(int x = 0; x < length; ++x)
			{
				Write(arr[offset+x]);
			}
			return this;
		}

		public BinaryBufferWriter Write(List<ushort> list, int offset, int count)
		{
			Write(count);
			for(int x = 0; x < count; ++x)
			{
				Write(list[offset+x]);
			}
			return this;
		}
		#endregion

		#region Int
		public BinaryBufferWriter Write(int[] arr)
		{
			return Write(arr, 0, arr.Length);
		}

		public BinaryBufferWriter Write(List<int> list)
		{
			return Write(list, 0, list.Count);
		}

		public BinaryBufferWriter Write(int[] arr, int offset, int length)
		{
			Write(length);
			for(int x = 0; x < length; ++x)
			{
				Write(arr[offset+x]);
			}
			return this;
		}

		public BinaryBufferWriter Write(List<int> list, int offset, int count)
		{
			Write(count);
			for(int x = 0; x < count; ++x)
			{
				Write(list[offset+x]);
			}
			return this;
		}
		#endregion

		#region UInt
		public BinaryBufferWriter Write(uint[] arr)
		{
			return Write(arr, 0, arr.Length);
		}

		public BinaryBufferWriter Write(List<uint> list)
		{
			return Write(list, 0, list.Count);
		}

		public BinaryBufferWriter Write(uint[] arr, int offset, int length)
		{
			Write(length);
			for(int x = 0; x < length; ++x)
			{
				Write(arr[offset+x]);
			}
			return this;
		}

		public BinaryBufferWriter Write(List<uint> list, int offset, int count)
		{
			Write(count);
			for(int x = 0; x < count; ++x)
			{
				Write(list[offset+x]);
			}
			return this;
		}
		#endregion

		#region Long
		public BinaryBufferWriter Write(long[] arr)
		{
			return Write(arr, 0, arr.Length);
		}

		public BinaryBufferWriter Write(List<long> list)
		{
			return Write(list, 0, list.Count);
		}

		public BinaryBufferWriter Write(long[] arr, int offset, int length)
		{
			Write(length);
			for(int x = 0; x < length; ++x)
			{
				Write(arr[offset+x]);
			}
			return this;
		}

		public BinaryBufferWriter Write(List<long> list, int offset, int count)
		{
			Write(count);
			for(int x = 0; x < count; ++x)
			{
				Write(list[offset+x]);
			}
			return this;
		}
		#endregion

		#region ULong
		public BinaryBufferWriter Write(ulong[] arr)
		{
			return Write(arr, 0, arr.Length);
		}

		public BinaryBufferWriter Write(List<ulong> list)
		{
			return Write(list, 0, list.Count);
		}

		public BinaryBufferWriter Write(ulong[] arr, int offset, int length)
		{
			Write(length);
			for(int x = 0; x < length; ++x)
			{
				Write(arr[offset+x]);
			}
			return this;
		}

		public BinaryBufferWriter Write(List<ulong> list, int offset, int count)
		{
			Write(count);
			for(int x = 0; x < count; ++x)
			{
				Write(list[offset+x]);
			}
			return this;
		}
		#endregion

		#region String
		public BinaryBufferWriter Write(string[] arr)
		{
			return Write(arr, 0, arr.Length);
		}

		public BinaryBufferWriter Write(List<string> list)
		{
			return Write(list, 0, list.Count);
		}

		public BinaryBufferWriter Write(string[] arr, int offset, int length)
		{
			Write(length);
			for(int x = 0; x < length; ++x)
			{
				Write(arr[offset+x]);
			}
			return this;
		}

		public BinaryBufferWriter Write(List<string> list, int offset, int count)
		{
			Write(count);
			for(int x = 0; x < count; ++x)
			{
				Write(list[offset+x]);
			}
			return this;
		}
		#endregion

		#region Float
		public BinaryBufferWriter Write(float[] arr)
		{
			return Write(arr, 0, arr.Length);
		}

		public BinaryBufferWriter Write(List<float> list)
		{
			return Write(list, 0, list.Count);
		}

		public BinaryBufferWriter Write(float[] arr, int offset, int length)
		{
			Write(length);
			for(int x = 0; x < length; ++x)
			{
				Write(arr[offset+x]);
			}
			return this;
		}

		public BinaryBufferWriter Write(List<float> list, int offset, int count)
		{
			Write(count);
			for(int x = 0; x < count; ++x)
			{
				Write(list[offset+x]);
			}
			return this;
		}
		#endregion

		#region Double
		public BinaryBufferWriter Write(double[] arr)
		{
			return Write(arr, 0, arr.Length);
		}

		public BinaryBufferWriter Write(List<double> list)
		{
			return Write(list, 0, list.Count);
		}

		public BinaryBufferWriter Write(double[] arr, int offset, int length)
		{
			Write(length);
			for(int x = 0; x < length; ++x)
			{
				Write(arr[offset+x]);
			}
			return this;
		}

		public BinaryBufferWriter Write(List<double> list, int offset, int count)
		{
			Write(count);
			for(int x = 0; x < count; ++x)
			{
				Write(list[offset+x]);
			}
			return this;
		}
		#endregion

	}
}
