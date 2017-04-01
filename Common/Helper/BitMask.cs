using System;
using System.Text;

namespace ProceduralLevel.Common.Helper
{
	public class BitMask
	{
		public const int INT_SIZE = 32;

		private int m_Capacity;
		private int[] m_Mask;

		public int Capacity
		{
			get { return m_Capacity; }
		}

		public BitMask(int capacity = INT_SIZE)
		{
			Resize(capacity);
		}

		public void Resize(int newCapacity)
		{
			int[] oldMask = m_Mask;
			int newSize = newCapacity / INT_SIZE;
			m_Mask = new int[newSize];
			m_Capacity = newCapacity;

			if(oldMask != null)
			{
				int minimal = Math.Min(m_Mask.Length, oldMask.Length);
				for(int x = 0; x < minimal; x++)
				{
					m_Mask[x] = oldMask[x];
				}
			}
		}

		#region Bit Comparision
		public bool HasBit(int bitIndex)
		{
			int arrayIndex = bitIndex / INT_SIZE;
			int offsetIndex = bitIndex % INT_SIZE;
			return (m_Mask[arrayIndex] & (1 << offsetIndex)) != 0;
		}

		public bool HasBits(params int[] bitIndexes)
		{
			for(int x = 0; x < bitIndexes.Length; x++)
			{
				if(!HasBit(bitIndexes[x]))
				{
					return false;
				}
			}
			return true;
		}

		public bool Contains(BitMask bitMask)
		{
			for(int x = 0; x < m_Mask.Length; x++)
			{
				if((m_Mask[x] & bitMask.m_Mask[x]) != bitMask.m_Mask[x])
				{
					return false;
				}
			}
			return true;
		}

		public bool Equals(BitMask bitMask)
		{
			for(int x = 0; x < m_Mask.Length; x++)
			{
				if(m_Mask[x] != bitMask.m_Mask[x])
				{
					return false;
				}
			}
			return true;
		}
		#endregion

		#region Bit Manipulation
		public virtual void SetBit(int bitIndex)
		{
			int arrayIndex = bitIndex / INT_SIZE;
			int offsetIndex = bitIndex % INT_SIZE;
			m_Mask[arrayIndex] = m_Mask[arrayIndex] | (1 << offsetIndex);
		}

		public void SetBits(params int[] bitIndexes)
		{
			for(int x = 0; x < bitIndexes.Length; x++)
			{
				SetBit(bitIndexes[x]);
			}
		}

		public virtual void UnsetBit(int bitIndex)
		{
			int arrayIndex = bitIndex / INT_SIZE;
			int offsetIndex = bitIndex % INT_SIZE;
			m_Mask[arrayIndex] = m_Mask[arrayIndex] & ~(1 << offsetIndex);
		}

		public void UnsetBits(params int[] bitIndexes)
		{
			for(int x = 0; x < bitIndexes.Length; x++)
			{
				UnsetBit(bitIndexes[x]);
			}
		}

		public virtual void ToggleBit(int bitIndex)
		{
			int arrayIndex = bitIndex / INT_SIZE;
			int offsetIndex = bitIndex % INT_SIZE;
			m_Mask[arrayIndex] = m_Mask[arrayIndex] ^ (1 << offsetIndex);
		}

		public void ToggleBits(params int[] bitIndexes)
		{
			for(int x = 0; x < bitIndexes.Length; x++)
			{
				ToggleBit(bitIndexes[x]);
			}
		}

		public void Toggle()
		{
			for(int x = 0; x < m_Mask.Length; x++)
			{
				m_Mask[x] ^= m_Mask[x];
			}
		}

		public void Clear()
		{
			for(int x = 0; x < m_Mask.Length; x++)
			{
				m_Mask[x] = 0;
			}
		}
		#endregion

		#region Bit Operations
		public void OrMerge(BitMask bitMask)
		{
			for(int x = 0; x < m_Mask.Length; x++)
			{
				m_Mask[x] = m_Mask[x] | bitMask.m_Mask[x];
			}
		}

		public void AndMerge(BitMask bitMask)
		{
			for(int x = 0; x < m_Mask.Length; x++)
			{
				m_Mask[x] = m_Mask[x] & bitMask.m_Mask[x];
			}
		}

		public BitMask Or(BitMask bitMask)
		{
			BitMask mask = Clone();
			mask.OrMerge(bitMask);
			return mask;
		}

		public BitMask And(BitMask bitMask)
		{
			BitMask mask = Clone();
			mask.AndMerge(bitMask);
			return mask;
		}

		public BitMask Clone()
		{
			BitMask bitMask = new BitMask(m_Capacity);
			for(int x = 0; x < m_Mask.Length; x++)
			{
				bitMask.m_Mask[x] = m_Mask[x];
			}
			return bitMask;
		}
		#endregion

		public override string ToString()
		{
			StringBuilder bitMask = new StringBuilder(m_Capacity);
			for(int x = m_Capacity - 1; x >= 0; x--)
			{
				bitMask.Append((HasBit(x) ? '1' : '0'));
			}
			return bitMask.ToString();
		}
	}
}
