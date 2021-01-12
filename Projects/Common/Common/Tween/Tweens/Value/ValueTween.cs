using ProceduralLevel.Common.Easing;

namespace ProceduralLevel.Common.Tween
{
	public class ByteTween: AValueTween<byte>
	{
		public ByteTween(EasingFunc easing, byte source, byte target)
			: base(easing, source, target)
		{
		
		}

		protected override byte Blend(byte source, byte target, float blend, float reverseBlend)
		{
			return (byte)(source*reverseBlend+target*blend);
		}
	}

	public class ByteArrayTween: AValueArrayTween<byte>
	{
		public ByteArrayTween(EasingFunc easing, byte[] buffer, byte[] source, byte[] target)
			: base(easing, buffer, source, target)
		{
		
		}

		protected override void Blend(byte[] buffer, byte[] source, byte[] target, float blend, float reverseBlend)
		{
			int length = buffer.Length;
			for(int x = 0; x < length; ++x)
			{
				buffer[x] = (byte)(source[x]*reverseBlend+target[x]*blend);
			}
		}
	}

	public class SByteTween: AValueTween<sbyte>
	{
		public SByteTween(EasingFunc easing, sbyte source, sbyte target)
			: base(easing, source, target)
		{
		
		}

		protected override sbyte Blend(sbyte source, sbyte target, float blend, float reverseBlend)
		{
			return (sbyte)(source*reverseBlend+target*blend);
		}
	}

	public class SByteArrayTween: AValueArrayTween<sbyte>
	{
		public SByteArrayTween(EasingFunc easing, sbyte[] buffer, sbyte[] source, sbyte[] target)
			: base(easing, buffer, source, target)
		{
		
		}

		protected override void Blend(sbyte[] buffer, sbyte[] source, sbyte[] target, float blend, float reverseBlend)
		{
			int length = buffer.Length;
			for(int x = 0; x < length; ++x)
			{
				buffer[x] = (sbyte)(source[x]*reverseBlend+target[x]*blend);
			}
		}
	}

	public class ShortTween: AValueTween<short>
	{
		public ShortTween(EasingFunc easing, short source, short target)
			: base(easing, source, target)
		{
		
		}

		protected override short Blend(short source, short target, float blend, float reverseBlend)
		{
			return (short)(source*reverseBlend+target*blend);
		}
	}

	public class ShortArrayTween: AValueArrayTween<short>
	{
		public ShortArrayTween(EasingFunc easing, short[] buffer, short[] source, short[] target)
			: base(easing, buffer, source, target)
		{
		
		}

		protected override void Blend(short[] buffer, short[] source, short[] target, float blend, float reverseBlend)
		{
			int length = buffer.Length;
			for(int x = 0; x < length; ++x)
			{
				buffer[x] = (short)(source[x]*reverseBlend+target[x]*blend);
			}
		}
	}

	public class UShortTween: AValueTween<ushort>
	{
		public UShortTween(EasingFunc easing, ushort source, ushort target)
			: base(easing, source, target)
		{
		
		}

		protected override ushort Blend(ushort source, ushort target, float blend, float reverseBlend)
		{
			return (ushort)(source*reverseBlend+target*blend);
		}
	}

	public class UShortArrayTween: AValueArrayTween<ushort>
	{
		public UShortArrayTween(EasingFunc easing, ushort[] buffer, ushort[] source, ushort[] target)
			: base(easing, buffer, source, target)
		{
		
		}

		protected override void Blend(ushort[] buffer, ushort[] source, ushort[] target, float blend, float reverseBlend)
		{
			int length = buffer.Length;
			for(int x = 0; x < length; ++x)
			{
				buffer[x] = (ushort)(source[x]*reverseBlend+target[x]*blend);
			}
		}
	}

	public class IntTween: AValueTween<int>
	{
		public IntTween(EasingFunc easing, int source, int target)
			: base(easing, source, target)
		{
		
		}

		protected override int Blend(int source, int target, float blend, float reverseBlend)
		{
			return (int)(source*reverseBlend+target*blend);
		}
	}

	public class IntArrayTween: AValueArrayTween<int>
	{
		public IntArrayTween(EasingFunc easing, int[] buffer, int[] source, int[] target)
			: base(easing, buffer, source, target)
		{
		
		}

		protected override void Blend(int[] buffer, int[] source, int[] target, float blend, float reverseBlend)
		{
			int length = buffer.Length;
			for(int x = 0; x < length; ++x)
			{
				buffer[x] = (int)(source[x]*reverseBlend+target[x]*blend);
			}
		}
	}

	public class UIntTween: AValueTween<uint>
	{
		public UIntTween(EasingFunc easing, uint source, uint target)
			: base(easing, source, target)
		{
		
		}

		protected override uint Blend(uint source, uint target, float blend, float reverseBlend)
		{
			return (uint)(source*reverseBlend+target*blend);
		}
	}

	public class UIntArrayTween: AValueArrayTween<uint>
	{
		public UIntArrayTween(EasingFunc easing, uint[] buffer, uint[] source, uint[] target)
			: base(easing, buffer, source, target)
		{
		
		}

		protected override void Blend(uint[] buffer, uint[] source, uint[] target, float blend, float reverseBlend)
		{
			int length = buffer.Length;
			for(int x = 0; x < length; ++x)
			{
				buffer[x] = (uint)(source[x]*reverseBlend+target[x]*blend);
			}
		}
	}

	public class LongTween: AValueTween<long>
	{
		public LongTween(EasingFunc easing, long source, long target)
			: base(easing, source, target)
		{
		
		}

		protected override long Blend(long source, long target, float blend, float reverseBlend)
		{
			return (long)(source*reverseBlend+target*blend);
		}
	}

	public class LongArrayTween: AValueArrayTween<long>
	{
		public LongArrayTween(EasingFunc easing, long[] buffer, long[] source, long[] target)
			: base(easing, buffer, source, target)
		{
		
		}

		protected override void Blend(long[] buffer, long[] source, long[] target, float blend, float reverseBlend)
		{
			int length = buffer.Length;
			for(int x = 0; x < length; ++x)
			{
				buffer[x] = (long)(source[x]*reverseBlend+target[x]*blend);
			}
		}
	}

	public class ULongTween: AValueTween<ulong>
	{
		public ULongTween(EasingFunc easing, ulong source, ulong target)
			: base(easing, source, target)
		{
		
		}

		protected override ulong Blend(ulong source, ulong target, float blend, float reverseBlend)
		{
			return (ulong)(source*reverseBlend+target*blend);
		}
	}

	public class ULongArrayTween: AValueArrayTween<ulong>
	{
		public ULongArrayTween(EasingFunc easing, ulong[] buffer, ulong[] source, ulong[] target)
			: base(easing, buffer, source, target)
		{
		
		}

		protected override void Blend(ulong[] buffer, ulong[] source, ulong[] target, float blend, float reverseBlend)
		{
			int length = buffer.Length;
			for(int x = 0; x < length; ++x)
			{
				buffer[x] = (ulong)(source[x]*reverseBlend+target[x]*blend);
			}
		}
	}

	public class FloatTween: AValueTween<float>
	{
		public FloatTween(EasingFunc easing, float source, float target)
			: base(easing, source, target)
		{
		
		}

		protected override float Blend(float source, float target, float blend, float reverseBlend)
		{
			return (float)(source*reverseBlend+target*blend);
		}
	}

	public class FloatArrayTween: AValueArrayTween<float>
	{
		public FloatArrayTween(EasingFunc easing, float[] buffer, float[] source, float[] target)
			: base(easing, buffer, source, target)
		{
		
		}

		protected override void Blend(float[] buffer, float[] source, float[] target, float blend, float reverseBlend)
		{
			int length = buffer.Length;
			for(int x = 0; x < length; ++x)
			{
				buffer[x] = (float)(source[x]*reverseBlend+target[x]*blend);
			}
		}
	}

	public class DoubleTween: AValueTween<double>
	{
		public DoubleTween(EasingFunc easing, double source, double target)
			: base(easing, source, target)
		{
		
		}

		protected override double Blend(double source, double target, float blend, float reverseBlend)
		{
			return (double)(source*reverseBlend+target*blend);
		}
	}

	public class DoubleArrayTween: AValueArrayTween<double>
	{
		public DoubleArrayTween(EasingFunc easing, double[] buffer, double[] source, double[] target)
			: base(easing, buffer, source, target)
		{
		
		}

		protected override void Blend(double[] buffer, double[] source, double[] target, float blend, float reverseBlend)
		{
			int length = buffer.Length;
			for(int x = 0; x < length; ++x)
			{
				buffer[x] = (double)(source[x]*reverseBlend+target[x]*blend);
			}
		}
	}

}
