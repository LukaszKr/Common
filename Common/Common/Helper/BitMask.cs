namespace Common.Helper
{
	public class BitMask: StaticBitMask
	{
		#region Bit Manipulation
		public override void SetBit(int bitIndex)
		{
			if(bitIndex > Capacity)
			{
				Resize((bitIndex / INT_SIZE) + 1);
			}
			base.SetBit(bitIndex);
		}

		public override void UnsetBit(int bitIndex)
		{
			if(bitIndex > Capacity)
			{
				Resize((bitIndex / INT_SIZE) + 1);
			}
			base.UnsetBit(bitIndex);
		}

		public override void ToggleBit(int bitIndex)
		{
			if(bitIndex > Capacity)
			{
				Resize((bitIndex / INT_SIZE) + 1);
			}
			base.ToggleBit(bitIndex);
		}
		#endregion
	}
}
