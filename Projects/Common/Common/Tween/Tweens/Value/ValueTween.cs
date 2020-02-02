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

}
