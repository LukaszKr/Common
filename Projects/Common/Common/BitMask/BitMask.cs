using System;
using System.Runtime.CompilerServices;

namespace ProceduralLevel.Common.BitMask
{
	public unsafe struct BitMask32: IEquatable<BitMask32>
	{
		public const int LENGTH = 32;

		private fixed int m_Data[1];

		private BitMask32(int i0)
		{
			m_Data[0] = i0;
		}

#region Getter/Setter
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Get(int position)
		{
			BitIndex index = BitIndex.Get(position);
			int mask = 1 << index.Local;
			return (m_Data[index.Group] & mask) != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Get(BitIndex index)
		{
			int mask = 1 << index.Local;
			return (m_Data[index.Group] & mask) != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int GetGroup(int group)
		{
			return m_Data[group];
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Set(int position, bool value)
		{
			BitIndex index = BitIndex.Get(position);
			int mask = 1 << index.Local;
			if(value)
			{
				m_Data[index.Group] |= mask;
			}
			else
			{
				m_Data[index.Group] &= ~mask;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Set(BitIndex index, bool value)
		{
			int mask = 1 << index.Local;
			if(value)
			{
				m_Data[index.Group] |= mask;
			}
			else
			{
				m_Data[index.Group] &= ~mask;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Set(int position)
		{
			BitIndex index = BitIndex.Get(position);
			int mask = 1 << index.Local;
			m_Data[index.Group] |= mask;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Set(BitIndex index)
		{
			int mask = 1 << index.Local;
			m_Data[index.Group] |= mask;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Clear(int position)
		{
			BitIndex index = BitIndex.Get(position);
			int mask = 1 << index.Local;
			m_Data[index.Group] &= ~mask;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Clear(BitIndex index)
		{
			int mask = 1 << index.Local;
			m_Data[index.Group] &= ~mask;
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Toggle(int position)
		{
			BitIndex index = BitIndex.Get(position);
			int mask = 1 << index.Local;
			m_Data[index.Group] ^= mask;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Toggle(BitIndex index)
		{
			int mask = 1 << index.Local;
			m_Data[index.Group] ^= mask;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void SetGroup(int group, int value)
		{
			m_Data[group] = value;
		}
#endregion

#region Bit Operations
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BitMask32 And(BitMask32 other)
		{
			return new BitMask32(
				m_Data[0] & other.m_Data[0]);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BitMask32 Or(BitMask32 other)
		{
			return new BitMask32(
				m_Data[0] | other.m_Data[0]);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BitMask32 XOr(BitMask32 other)
		{
			return new BitMask32(
				m_Data[0] ^ other.m_Data[0]);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BitMask32 ToggleAll()
		{
			return new BitMask32(
				~m_Data[0]);
		}
#endregion

#region Other
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsEmpty()
		{
			return
				m_Data[0] == 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool HasCommonPart(BitMask32 other)
		{
			return 
				(m_Data[0] & other.m_Data[0]) != 0;
		}
#endregion

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(BitMask32 other)
		{
			return 
				m_Data[0] == other.m_Data[0];
		}
	}
	public unsafe struct BitMask64: IEquatable<BitMask64>
	{
		public const int LENGTH = 64;

		private fixed int m_Data[2];

		private BitMask64(int i0, int i1)
		{
			m_Data[0] = i0;
			m_Data[1] = i1;
		}

#region Getter/Setter
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Get(int position)
		{
			BitIndex index = BitIndex.Get(position);
			int mask = 1 << index.Local;
			return (m_Data[index.Group] & mask) != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Get(BitIndex index)
		{
			int mask = 1 << index.Local;
			return (m_Data[index.Group] & mask) != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int GetGroup(int group)
		{
			return m_Data[group];
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Set(int position, bool value)
		{
			BitIndex index = BitIndex.Get(position);
			int mask = 1 << index.Local;
			if(value)
			{
				m_Data[index.Group] |= mask;
			}
			else
			{
				m_Data[index.Group] &= ~mask;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Set(BitIndex index, bool value)
		{
			int mask = 1 << index.Local;
			if(value)
			{
				m_Data[index.Group] |= mask;
			}
			else
			{
				m_Data[index.Group] &= ~mask;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Set(int position)
		{
			BitIndex index = BitIndex.Get(position);
			int mask = 1 << index.Local;
			m_Data[index.Group] |= mask;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Set(BitIndex index)
		{
			int mask = 1 << index.Local;
			m_Data[index.Group] |= mask;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Clear(int position)
		{
			BitIndex index = BitIndex.Get(position);
			int mask = 1 << index.Local;
			m_Data[index.Group] &= ~mask;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Clear(BitIndex index)
		{
			int mask = 1 << index.Local;
			m_Data[index.Group] &= ~mask;
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Toggle(int position)
		{
			BitIndex index = BitIndex.Get(position);
			int mask = 1 << index.Local;
			m_Data[index.Group] ^= mask;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Toggle(BitIndex index)
		{
			int mask = 1 << index.Local;
			m_Data[index.Group] ^= mask;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void SetGroup(int group, int value)
		{
			m_Data[group] = value;
		}
#endregion

#region Bit Operations
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BitMask64 And(BitMask64 other)
		{
			return new BitMask64(
				m_Data[0] & other.m_Data[0], 
				m_Data[1] & other.m_Data[1]);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BitMask64 Or(BitMask64 other)
		{
			return new BitMask64(
				m_Data[0] | other.m_Data[0], 
				m_Data[1] | other.m_Data[1]);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BitMask64 XOr(BitMask64 other)
		{
			return new BitMask64(
				m_Data[0] ^ other.m_Data[0], 
				m_Data[1] ^ other.m_Data[1]);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BitMask64 ToggleAll()
		{
			return new BitMask64(
				~m_Data[0],
				~m_Data[1]);
		}
#endregion

#region Other
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsEmpty()
		{
			return
				m_Data[0] == 0 &&
				m_Data[1] == 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool HasCommonPart(BitMask64 other)
		{
			return 
				(m_Data[0] & other.m_Data[0]) != 0 &&
				(m_Data[1] & other.m_Data[1]) != 0;
		}
#endregion

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(BitMask64 other)
		{
			return 
				m_Data[0] == other.m_Data[0] &&
				m_Data[1] == other.m_Data[1];
		}
	}
	public unsafe struct BitMask96: IEquatable<BitMask96>
	{
		public const int LENGTH = 96;

		private fixed int m_Data[3];

		private BitMask96(int i0, int i1, int i2)
		{
			m_Data[0] = i0;
			m_Data[1] = i1;
			m_Data[2] = i2;
		}

#region Getter/Setter
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Get(int position)
		{
			BitIndex index = BitIndex.Get(position);
			int mask = 1 << index.Local;
			return (m_Data[index.Group] & mask) != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Get(BitIndex index)
		{
			int mask = 1 << index.Local;
			return (m_Data[index.Group] & mask) != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int GetGroup(int group)
		{
			return m_Data[group];
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Set(int position, bool value)
		{
			BitIndex index = BitIndex.Get(position);
			int mask = 1 << index.Local;
			if(value)
			{
				m_Data[index.Group] |= mask;
			}
			else
			{
				m_Data[index.Group] &= ~mask;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Set(BitIndex index, bool value)
		{
			int mask = 1 << index.Local;
			if(value)
			{
				m_Data[index.Group] |= mask;
			}
			else
			{
				m_Data[index.Group] &= ~mask;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Set(int position)
		{
			BitIndex index = BitIndex.Get(position);
			int mask = 1 << index.Local;
			m_Data[index.Group] |= mask;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Set(BitIndex index)
		{
			int mask = 1 << index.Local;
			m_Data[index.Group] |= mask;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Clear(int position)
		{
			BitIndex index = BitIndex.Get(position);
			int mask = 1 << index.Local;
			m_Data[index.Group] &= ~mask;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Clear(BitIndex index)
		{
			int mask = 1 << index.Local;
			m_Data[index.Group] &= ~mask;
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Toggle(int position)
		{
			BitIndex index = BitIndex.Get(position);
			int mask = 1 << index.Local;
			m_Data[index.Group] ^= mask;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Toggle(BitIndex index)
		{
			int mask = 1 << index.Local;
			m_Data[index.Group] ^= mask;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void SetGroup(int group, int value)
		{
			m_Data[group] = value;
		}
#endregion

#region Bit Operations
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BitMask96 And(BitMask96 other)
		{
			return new BitMask96(
				m_Data[0] & other.m_Data[0], 
				m_Data[1] & other.m_Data[1], 
				m_Data[2] & other.m_Data[2]);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BitMask96 Or(BitMask96 other)
		{
			return new BitMask96(
				m_Data[0] | other.m_Data[0], 
				m_Data[1] | other.m_Data[1], 
				m_Data[2] | other.m_Data[2]);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BitMask96 XOr(BitMask96 other)
		{
			return new BitMask96(
				m_Data[0] ^ other.m_Data[0], 
				m_Data[1] ^ other.m_Data[1], 
				m_Data[2] ^ other.m_Data[2]);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BitMask96 ToggleAll()
		{
			return new BitMask96(
				~m_Data[0],
				~m_Data[1],
				~m_Data[2]);
		}
#endregion

#region Other
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsEmpty()
		{
			return
				m_Data[0] == 0 &&
				m_Data[1] == 0 &&
				m_Data[2] == 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool HasCommonPart(BitMask96 other)
		{
			return 
				(m_Data[0] & other.m_Data[0]) != 0 &&
				(m_Data[1] & other.m_Data[1]) != 0 &&
				(m_Data[2] & other.m_Data[2]) != 0;
		}
#endregion

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(BitMask96 other)
		{
			return 
				m_Data[0] == other.m_Data[0] &&
				m_Data[1] == other.m_Data[1] &&
				m_Data[2] == other.m_Data[2];
		}
	}
	public unsafe struct BitMask128: IEquatable<BitMask128>
	{
		public const int LENGTH = 128;

		private fixed int m_Data[4];

		private BitMask128(int i0, int i1, int i2, int i3)
		{
			m_Data[0] = i0;
			m_Data[1] = i1;
			m_Data[2] = i2;
			m_Data[3] = i3;
		}

#region Getter/Setter
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Get(int position)
		{
			BitIndex index = BitIndex.Get(position);
			int mask = 1 << index.Local;
			return (m_Data[index.Group] & mask) != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Get(BitIndex index)
		{
			int mask = 1 << index.Local;
			return (m_Data[index.Group] & mask) != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int GetGroup(int group)
		{
			return m_Data[group];
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Set(int position, bool value)
		{
			BitIndex index = BitIndex.Get(position);
			int mask = 1 << index.Local;
			if(value)
			{
				m_Data[index.Group] |= mask;
			}
			else
			{
				m_Data[index.Group] &= ~mask;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Set(BitIndex index, bool value)
		{
			int mask = 1 << index.Local;
			if(value)
			{
				m_Data[index.Group] |= mask;
			}
			else
			{
				m_Data[index.Group] &= ~mask;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Set(int position)
		{
			BitIndex index = BitIndex.Get(position);
			int mask = 1 << index.Local;
			m_Data[index.Group] |= mask;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Set(BitIndex index)
		{
			int mask = 1 << index.Local;
			m_Data[index.Group] |= mask;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Clear(int position)
		{
			BitIndex index = BitIndex.Get(position);
			int mask = 1 << index.Local;
			m_Data[index.Group] &= ~mask;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Clear(BitIndex index)
		{
			int mask = 1 << index.Local;
			m_Data[index.Group] &= ~mask;
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Toggle(int position)
		{
			BitIndex index = BitIndex.Get(position);
			int mask = 1 << index.Local;
			m_Data[index.Group] ^= mask;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Toggle(BitIndex index)
		{
			int mask = 1 << index.Local;
			m_Data[index.Group] ^= mask;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void SetGroup(int group, int value)
		{
			m_Data[group] = value;
		}
#endregion

#region Bit Operations
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BitMask128 And(BitMask128 other)
		{
			return new BitMask128(
				m_Data[0] & other.m_Data[0], 
				m_Data[1] & other.m_Data[1], 
				m_Data[2] & other.m_Data[2], 
				m_Data[3] & other.m_Data[3]);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BitMask128 Or(BitMask128 other)
		{
			return new BitMask128(
				m_Data[0] | other.m_Data[0], 
				m_Data[1] | other.m_Data[1], 
				m_Data[2] | other.m_Data[2], 
				m_Data[3] | other.m_Data[3]);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BitMask128 XOr(BitMask128 other)
		{
			return new BitMask128(
				m_Data[0] ^ other.m_Data[0], 
				m_Data[1] ^ other.m_Data[1], 
				m_Data[2] ^ other.m_Data[2], 
				m_Data[3] ^ other.m_Data[3]);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BitMask128 ToggleAll()
		{
			return new BitMask128(
				~m_Data[0],
				~m_Data[1],
				~m_Data[2],
				~m_Data[3]);
		}
#endregion

#region Other
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsEmpty()
		{
			return
				m_Data[0] == 0 &&
				m_Data[1] == 0 &&
				m_Data[2] == 0 &&
				m_Data[3] == 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool HasCommonPart(BitMask128 other)
		{
			return 
				(m_Data[0] & other.m_Data[0]) != 0 &&
				(m_Data[1] & other.m_Data[1]) != 0 &&
				(m_Data[2] & other.m_Data[2]) != 0 &&
				(m_Data[3] & other.m_Data[3]) != 0;
		}
#endregion

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(BitMask128 other)
		{
			return 
				m_Data[0] == other.m_Data[0] &&
				m_Data[1] == other.m_Data[1] &&
				m_Data[2] == other.m_Data[2] &&
				m_Data[3] == other.m_Data[3];
		}
	}
	public unsafe struct BitMask160: IEquatable<BitMask160>
	{
		public const int LENGTH = 160;

		private fixed int m_Data[5];

		private BitMask160(int i0, int i1, int i2, int i3, int i4)
		{
			m_Data[0] = i0;
			m_Data[1] = i1;
			m_Data[2] = i2;
			m_Data[3] = i3;
			m_Data[4] = i4;
		}

#region Getter/Setter
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Get(int position)
		{
			BitIndex index = BitIndex.Get(position);
			int mask = 1 << index.Local;
			return (m_Data[index.Group] & mask) != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Get(BitIndex index)
		{
			int mask = 1 << index.Local;
			return (m_Data[index.Group] & mask) != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int GetGroup(int group)
		{
			return m_Data[group];
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Set(int position, bool value)
		{
			BitIndex index = BitIndex.Get(position);
			int mask = 1 << index.Local;
			if(value)
			{
				m_Data[index.Group] |= mask;
			}
			else
			{
				m_Data[index.Group] &= ~mask;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Set(BitIndex index, bool value)
		{
			int mask = 1 << index.Local;
			if(value)
			{
				m_Data[index.Group] |= mask;
			}
			else
			{
				m_Data[index.Group] &= ~mask;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Set(int position)
		{
			BitIndex index = BitIndex.Get(position);
			int mask = 1 << index.Local;
			m_Data[index.Group] |= mask;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Set(BitIndex index)
		{
			int mask = 1 << index.Local;
			m_Data[index.Group] |= mask;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Clear(int position)
		{
			BitIndex index = BitIndex.Get(position);
			int mask = 1 << index.Local;
			m_Data[index.Group] &= ~mask;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Clear(BitIndex index)
		{
			int mask = 1 << index.Local;
			m_Data[index.Group] &= ~mask;
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Toggle(int position)
		{
			BitIndex index = BitIndex.Get(position);
			int mask = 1 << index.Local;
			m_Data[index.Group] ^= mask;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Toggle(BitIndex index)
		{
			int mask = 1 << index.Local;
			m_Data[index.Group] ^= mask;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void SetGroup(int group, int value)
		{
			m_Data[group] = value;
		}
#endregion

#region Bit Operations
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BitMask160 And(BitMask160 other)
		{
			return new BitMask160(
				m_Data[0] & other.m_Data[0], 
				m_Data[1] & other.m_Data[1], 
				m_Data[2] & other.m_Data[2], 
				m_Data[3] & other.m_Data[3], 
				m_Data[4] & other.m_Data[4]);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BitMask160 Or(BitMask160 other)
		{
			return new BitMask160(
				m_Data[0] | other.m_Data[0], 
				m_Data[1] | other.m_Data[1], 
				m_Data[2] | other.m_Data[2], 
				m_Data[3] | other.m_Data[3], 
				m_Data[4] | other.m_Data[4]);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BitMask160 XOr(BitMask160 other)
		{
			return new BitMask160(
				m_Data[0] ^ other.m_Data[0], 
				m_Data[1] ^ other.m_Data[1], 
				m_Data[2] ^ other.m_Data[2], 
				m_Data[3] ^ other.m_Data[3], 
				m_Data[4] ^ other.m_Data[4]);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BitMask160 ToggleAll()
		{
			return new BitMask160(
				~m_Data[0],
				~m_Data[1],
				~m_Data[2],
				~m_Data[3],
				~m_Data[4]);
		}
#endregion

#region Other
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsEmpty()
		{
			return
				m_Data[0] == 0 &&
				m_Data[1] == 0 &&
				m_Data[2] == 0 &&
				m_Data[3] == 0 &&
				m_Data[4] == 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool HasCommonPart(BitMask160 other)
		{
			return 
				(m_Data[0] & other.m_Data[0]) != 0 &&
				(m_Data[1] & other.m_Data[1]) != 0 &&
				(m_Data[2] & other.m_Data[2]) != 0 &&
				(m_Data[3] & other.m_Data[3]) != 0 &&
				(m_Data[4] & other.m_Data[4]) != 0;
		}
#endregion

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(BitMask160 other)
		{
			return 
				m_Data[0] == other.m_Data[0] &&
				m_Data[1] == other.m_Data[1] &&
				m_Data[2] == other.m_Data[2] &&
				m_Data[3] == other.m_Data[3] &&
				m_Data[4] == other.m_Data[4];
		}
	}
	public unsafe struct BitMask192: IEquatable<BitMask192>
	{
		public const int LENGTH = 192;

		private fixed int m_Data[6];

		private BitMask192(int i0, int i1, int i2, int i3, int i4, int i5)
		{
			m_Data[0] = i0;
			m_Data[1] = i1;
			m_Data[2] = i2;
			m_Data[3] = i3;
			m_Data[4] = i4;
			m_Data[5] = i5;
		}

#region Getter/Setter
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Get(int position)
		{
			BitIndex index = BitIndex.Get(position);
			int mask = 1 << index.Local;
			return (m_Data[index.Group] & mask) != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Get(BitIndex index)
		{
			int mask = 1 << index.Local;
			return (m_Data[index.Group] & mask) != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int GetGroup(int group)
		{
			return m_Data[group];
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Set(int position, bool value)
		{
			BitIndex index = BitIndex.Get(position);
			int mask = 1 << index.Local;
			if(value)
			{
				m_Data[index.Group] |= mask;
			}
			else
			{
				m_Data[index.Group] &= ~mask;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Set(BitIndex index, bool value)
		{
			int mask = 1 << index.Local;
			if(value)
			{
				m_Data[index.Group] |= mask;
			}
			else
			{
				m_Data[index.Group] &= ~mask;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Set(int position)
		{
			BitIndex index = BitIndex.Get(position);
			int mask = 1 << index.Local;
			m_Data[index.Group] |= mask;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Set(BitIndex index)
		{
			int mask = 1 << index.Local;
			m_Data[index.Group] |= mask;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Clear(int position)
		{
			BitIndex index = BitIndex.Get(position);
			int mask = 1 << index.Local;
			m_Data[index.Group] &= ~mask;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Clear(BitIndex index)
		{
			int mask = 1 << index.Local;
			m_Data[index.Group] &= ~mask;
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Toggle(int position)
		{
			BitIndex index = BitIndex.Get(position);
			int mask = 1 << index.Local;
			m_Data[index.Group] ^= mask;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Toggle(BitIndex index)
		{
			int mask = 1 << index.Local;
			m_Data[index.Group] ^= mask;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void SetGroup(int group, int value)
		{
			m_Data[group] = value;
		}
#endregion

#region Bit Operations
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BitMask192 And(BitMask192 other)
		{
			return new BitMask192(
				m_Data[0] & other.m_Data[0], 
				m_Data[1] & other.m_Data[1], 
				m_Data[2] & other.m_Data[2], 
				m_Data[3] & other.m_Data[3], 
				m_Data[4] & other.m_Data[4], 
				m_Data[5] & other.m_Data[5]);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BitMask192 Or(BitMask192 other)
		{
			return new BitMask192(
				m_Data[0] | other.m_Data[0], 
				m_Data[1] | other.m_Data[1], 
				m_Data[2] | other.m_Data[2], 
				m_Data[3] | other.m_Data[3], 
				m_Data[4] | other.m_Data[4], 
				m_Data[5] | other.m_Data[5]);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BitMask192 XOr(BitMask192 other)
		{
			return new BitMask192(
				m_Data[0] ^ other.m_Data[0], 
				m_Data[1] ^ other.m_Data[1], 
				m_Data[2] ^ other.m_Data[2], 
				m_Data[3] ^ other.m_Data[3], 
				m_Data[4] ^ other.m_Data[4], 
				m_Data[5] ^ other.m_Data[5]);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BitMask192 ToggleAll()
		{
			return new BitMask192(
				~m_Data[0],
				~m_Data[1],
				~m_Data[2],
				~m_Data[3],
				~m_Data[4],
				~m_Data[5]);
		}
#endregion

#region Other
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsEmpty()
		{
			return
				m_Data[0] == 0 &&
				m_Data[1] == 0 &&
				m_Data[2] == 0 &&
				m_Data[3] == 0 &&
				m_Data[4] == 0 &&
				m_Data[5] == 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool HasCommonPart(BitMask192 other)
		{
			return 
				(m_Data[0] & other.m_Data[0]) != 0 &&
				(m_Data[1] & other.m_Data[1]) != 0 &&
				(m_Data[2] & other.m_Data[2]) != 0 &&
				(m_Data[3] & other.m_Data[3]) != 0 &&
				(m_Data[4] & other.m_Data[4]) != 0 &&
				(m_Data[5] & other.m_Data[5]) != 0;
		}
#endregion

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(BitMask192 other)
		{
			return 
				m_Data[0] == other.m_Data[0] &&
				m_Data[1] == other.m_Data[1] &&
				m_Data[2] == other.m_Data[2] &&
				m_Data[3] == other.m_Data[3] &&
				m_Data[4] == other.m_Data[4] &&
				m_Data[5] == other.m_Data[5];
		}
	}
	public unsafe struct BitMask224: IEquatable<BitMask224>
	{
		public const int LENGTH = 224;

		private fixed int m_Data[7];

		private BitMask224(int i0, int i1, int i2, int i3, int i4, int i5, int i6)
		{
			m_Data[0] = i0;
			m_Data[1] = i1;
			m_Data[2] = i2;
			m_Data[3] = i3;
			m_Data[4] = i4;
			m_Data[5] = i5;
			m_Data[6] = i6;
		}

#region Getter/Setter
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Get(int position)
		{
			BitIndex index = BitIndex.Get(position);
			int mask = 1 << index.Local;
			return (m_Data[index.Group] & mask) != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Get(BitIndex index)
		{
			int mask = 1 << index.Local;
			return (m_Data[index.Group] & mask) != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int GetGroup(int group)
		{
			return m_Data[group];
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Set(int position, bool value)
		{
			BitIndex index = BitIndex.Get(position);
			int mask = 1 << index.Local;
			if(value)
			{
				m_Data[index.Group] |= mask;
			}
			else
			{
				m_Data[index.Group] &= ~mask;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Set(BitIndex index, bool value)
		{
			int mask = 1 << index.Local;
			if(value)
			{
				m_Data[index.Group] |= mask;
			}
			else
			{
				m_Data[index.Group] &= ~mask;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Set(int position)
		{
			BitIndex index = BitIndex.Get(position);
			int mask = 1 << index.Local;
			m_Data[index.Group] |= mask;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Set(BitIndex index)
		{
			int mask = 1 << index.Local;
			m_Data[index.Group] |= mask;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Clear(int position)
		{
			BitIndex index = BitIndex.Get(position);
			int mask = 1 << index.Local;
			m_Data[index.Group] &= ~mask;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Clear(BitIndex index)
		{
			int mask = 1 << index.Local;
			m_Data[index.Group] &= ~mask;
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Toggle(int position)
		{
			BitIndex index = BitIndex.Get(position);
			int mask = 1 << index.Local;
			m_Data[index.Group] ^= mask;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Toggle(BitIndex index)
		{
			int mask = 1 << index.Local;
			m_Data[index.Group] ^= mask;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void SetGroup(int group, int value)
		{
			m_Data[group] = value;
		}
#endregion

#region Bit Operations
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BitMask224 And(BitMask224 other)
		{
			return new BitMask224(
				m_Data[0] & other.m_Data[0], 
				m_Data[1] & other.m_Data[1], 
				m_Data[2] & other.m_Data[2], 
				m_Data[3] & other.m_Data[3], 
				m_Data[4] & other.m_Data[4], 
				m_Data[5] & other.m_Data[5], 
				m_Data[6] & other.m_Data[6]);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BitMask224 Or(BitMask224 other)
		{
			return new BitMask224(
				m_Data[0] | other.m_Data[0], 
				m_Data[1] | other.m_Data[1], 
				m_Data[2] | other.m_Data[2], 
				m_Data[3] | other.m_Data[3], 
				m_Data[4] | other.m_Data[4], 
				m_Data[5] | other.m_Data[5], 
				m_Data[6] | other.m_Data[6]);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BitMask224 XOr(BitMask224 other)
		{
			return new BitMask224(
				m_Data[0] ^ other.m_Data[0], 
				m_Data[1] ^ other.m_Data[1], 
				m_Data[2] ^ other.m_Data[2], 
				m_Data[3] ^ other.m_Data[3], 
				m_Data[4] ^ other.m_Data[4], 
				m_Data[5] ^ other.m_Data[5], 
				m_Data[6] ^ other.m_Data[6]);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BitMask224 ToggleAll()
		{
			return new BitMask224(
				~m_Data[0],
				~m_Data[1],
				~m_Data[2],
				~m_Data[3],
				~m_Data[4],
				~m_Data[5],
				~m_Data[6]);
		}
#endregion

#region Other
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsEmpty()
		{
			return
				m_Data[0] == 0 &&
				m_Data[1] == 0 &&
				m_Data[2] == 0 &&
				m_Data[3] == 0 &&
				m_Data[4] == 0 &&
				m_Data[5] == 0 &&
				m_Data[6] == 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool HasCommonPart(BitMask224 other)
		{
			return 
				(m_Data[0] & other.m_Data[0]) != 0 &&
				(m_Data[1] & other.m_Data[1]) != 0 &&
				(m_Data[2] & other.m_Data[2]) != 0 &&
				(m_Data[3] & other.m_Data[3]) != 0 &&
				(m_Data[4] & other.m_Data[4]) != 0 &&
				(m_Data[5] & other.m_Data[5]) != 0 &&
				(m_Data[6] & other.m_Data[6]) != 0;
		}
#endregion

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(BitMask224 other)
		{
			return 
				m_Data[0] == other.m_Data[0] &&
				m_Data[1] == other.m_Data[1] &&
				m_Data[2] == other.m_Data[2] &&
				m_Data[3] == other.m_Data[3] &&
				m_Data[4] == other.m_Data[4] &&
				m_Data[5] == other.m_Data[5] &&
				m_Data[6] == other.m_Data[6];
		}
	}
	public unsafe struct BitMask256: IEquatable<BitMask256>
	{
		public const int LENGTH = 256;

		private fixed int m_Data[8];

		private BitMask256(int i0, int i1, int i2, int i3, int i4, int i5, int i6, int i7)
		{
			m_Data[0] = i0;
			m_Data[1] = i1;
			m_Data[2] = i2;
			m_Data[3] = i3;
			m_Data[4] = i4;
			m_Data[5] = i5;
			m_Data[6] = i6;
			m_Data[7] = i7;
		}

#region Getter/Setter
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Get(int position)
		{
			BitIndex index = BitIndex.Get(position);
			int mask = 1 << index.Local;
			return (m_Data[index.Group] & mask) != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Get(BitIndex index)
		{
			int mask = 1 << index.Local;
			return (m_Data[index.Group] & mask) != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int GetGroup(int group)
		{
			return m_Data[group];
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Set(int position, bool value)
		{
			BitIndex index = BitIndex.Get(position);
			int mask = 1 << index.Local;
			if(value)
			{
				m_Data[index.Group] |= mask;
			}
			else
			{
				m_Data[index.Group] &= ~mask;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Set(BitIndex index, bool value)
		{
			int mask = 1 << index.Local;
			if(value)
			{
				m_Data[index.Group] |= mask;
			}
			else
			{
				m_Data[index.Group] &= ~mask;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Set(int position)
		{
			BitIndex index = BitIndex.Get(position);
			int mask = 1 << index.Local;
			m_Data[index.Group] |= mask;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Set(BitIndex index)
		{
			int mask = 1 << index.Local;
			m_Data[index.Group] |= mask;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Clear(int position)
		{
			BitIndex index = BitIndex.Get(position);
			int mask = 1 << index.Local;
			m_Data[index.Group] &= ~mask;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Clear(BitIndex index)
		{
			int mask = 1 << index.Local;
			m_Data[index.Group] &= ~mask;
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Toggle(int position)
		{
			BitIndex index = BitIndex.Get(position);
			int mask = 1 << index.Local;
			m_Data[index.Group] ^= mask;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Toggle(BitIndex index)
		{
			int mask = 1 << index.Local;
			m_Data[index.Group] ^= mask;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void SetGroup(int group, int value)
		{
			m_Data[group] = value;
		}
#endregion

#region Bit Operations
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BitMask256 And(BitMask256 other)
		{
			return new BitMask256(
				m_Data[0] & other.m_Data[0], 
				m_Data[1] & other.m_Data[1], 
				m_Data[2] & other.m_Data[2], 
				m_Data[3] & other.m_Data[3], 
				m_Data[4] & other.m_Data[4], 
				m_Data[5] & other.m_Data[5], 
				m_Data[6] & other.m_Data[6], 
				m_Data[7] & other.m_Data[7]);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BitMask256 Or(BitMask256 other)
		{
			return new BitMask256(
				m_Data[0] | other.m_Data[0], 
				m_Data[1] | other.m_Data[1], 
				m_Data[2] | other.m_Data[2], 
				m_Data[3] | other.m_Data[3], 
				m_Data[4] | other.m_Data[4], 
				m_Data[5] | other.m_Data[5], 
				m_Data[6] | other.m_Data[6], 
				m_Data[7] | other.m_Data[7]);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BitMask256 XOr(BitMask256 other)
		{
			return new BitMask256(
				m_Data[0] ^ other.m_Data[0], 
				m_Data[1] ^ other.m_Data[1], 
				m_Data[2] ^ other.m_Data[2], 
				m_Data[3] ^ other.m_Data[3], 
				m_Data[4] ^ other.m_Data[4], 
				m_Data[5] ^ other.m_Data[5], 
				m_Data[6] ^ other.m_Data[6], 
				m_Data[7] ^ other.m_Data[7]);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public BitMask256 ToggleAll()
		{
			return new BitMask256(
				~m_Data[0],
				~m_Data[1],
				~m_Data[2],
				~m_Data[3],
				~m_Data[4],
				~m_Data[5],
				~m_Data[6],
				~m_Data[7]);
		}
#endregion

#region Other
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool IsEmpty()
		{
			return
				m_Data[0] == 0 &&
				m_Data[1] == 0 &&
				m_Data[2] == 0 &&
				m_Data[3] == 0 &&
				m_Data[4] == 0 &&
				m_Data[5] == 0 &&
				m_Data[6] == 0 &&
				m_Data[7] == 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool HasCommonPart(BitMask256 other)
		{
			return 
				(m_Data[0] & other.m_Data[0]) != 0 &&
				(m_Data[1] & other.m_Data[1]) != 0 &&
				(m_Data[2] & other.m_Data[2]) != 0 &&
				(m_Data[3] & other.m_Data[3]) != 0 &&
				(m_Data[4] & other.m_Data[4]) != 0 &&
				(m_Data[5] & other.m_Data[5]) != 0 &&
				(m_Data[6] & other.m_Data[6]) != 0 &&
				(m_Data[7] & other.m_Data[7]) != 0;
		}
#endregion

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Equals(BitMask256 other)
		{
			return 
				m_Data[0] == other.m_Data[0] &&
				m_Data[1] == other.m_Data[1] &&
				m_Data[2] == other.m_Data[2] &&
				m_Data[3] == other.m_Data[3] &&
				m_Data[4] == other.m_Data[4] &&
				m_Data[5] == other.m_Data[5] &&
				m_Data[6] == other.m_Data[6] &&
				m_Data[7] == other.m_Data[7];
		}
	}
}
