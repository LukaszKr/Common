using System;

namespace ProceduralLevel.Serialization
{
	public abstract partial class AArray
	{
		protected int m_Index = 0;

		public abstract int Count { get; }

		public virtual void Clear()
		{
			m_Index = 0;
		}

		public void Seek(int index)
		{
			if(index < 0 || index >= Count)
			{
				throw new ArgumentOutOfRangeException();
			}
			m_Index = index;
		}

		public abstract AObject WriteObject();
		public abstract AArray WriteArray();
		public abstract AObject ReadObject();
		public abstract AArray ReadArray();
		public abstract AObject ReadObject(int index);
		public abstract AArray ReadArray(int index);
	}
}
