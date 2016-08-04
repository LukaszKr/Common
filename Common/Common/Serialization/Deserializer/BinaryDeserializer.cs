using System;

namespace Common.Serialization.Deserializer
{
	public abstract class BinaryDeserializer: BinaryPersistence, IDeserializer
    {
		public override void Clear()
		{
			base.Clear();
		}

		public void Load()
		{
			throw new NotImplementedException();
		}

		#region Read
		public void Read(out byte data)
		{
			throw new NotImplementedException();
		}

		public void Read(out long data)
		{
			throw new NotImplementedException();
		}

		public void Read(out string data)
		{
			throw new NotImplementedException();
		}

		public void Read(out double data)
		{
			throw new NotImplementedException();
		}

		public void Read(out float data)
		{
			throw new NotImplementedException();
		}

		public void Read(out int data)
		{
			throw new NotImplementedException();
		}

		public void Read(out short data)
		{
			throw new NotImplementedException();
		}

		public void Read(out bool data)
		{
			throw new NotImplementedException();
		}

		public void Read<ObjectType>(ObjectType obj) where ObjectType : ISerializable
		{
			obj.Deserialize(this);
		}
		#endregion
	}
}
