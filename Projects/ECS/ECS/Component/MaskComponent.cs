namespace ProceduralLevel.ECS
{
	public unsafe struct MaskComponent: IComponent
	{
		public const int LENGTH = 2; //64 ids, increase if more is needed
		public const int MAX_COMPONENT_SIZE = ComponentID.INT_SIZE*LENGTH;

		public fixed int Mask[LENGTH];

		public bool Contains(MaskComponent other)
		{
			fixed(int* mask = Mask)
			{
				for(int x = 0; x < LENGTH; ++x)
				{
					int otherMaskValue = other.Mask[x];
					if((mask[x] & otherMaskValue) != otherMaskValue)
					{
						return false;
					}
				}
			}
			return true;
		}

		public bool Equals(MaskComponent other)
		{
			fixed (int* mask = Mask)
			{
				for(int x = 0; x < LENGTH; ++x)
				{
					if(mask[x] != other.Mask[x])
					{
						return false;
					}
				}
			}
			return true;
		}

		public bool Has(ComponentID id)
		{
			fixed(int* mask = Mask)
			{
				return (mask[id.Index] & (1 << id.Offset)) != 0;
			}
		}

		public void Set(ComponentID id)
		{
			fixed(int* mask = Mask)
			{
				mask[id.Index] = mask[id.Index] | (1 << id.Offset);
			}
		}

		public void Unset(ComponentID id)
		{
			fixed (int* mask = Mask)
			{
				mask[id.Index] = mask[id.Index] & ~(1 << id.Offset);
			}
		}
	}
}
