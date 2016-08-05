using System;

namespace Common.Serialization.Deserializer
{
	public abstract class BinaryDeserializer: BinaryPersistence, IDeserializer
    {
		public override void Clear()
		{
			base.Clear();
		}

		public void Load(IBinaryReader reader)
		{
			throw new NotImplementedException();
		}

		#region Read
		public bool ReadBool()
		{
			throw new NotImplementedException();
		}

		public byte ReadByte()
		{
			throw new NotImplementedException();
		}

		public short ReadShort()
		{
			throw new NotImplementedException();
		}

		public int ReadInt()
		{
			throw new NotImplementedException();
		}

		public long ReadLong()
		{
			throw new NotImplementedException();
		}

		public float ReadFloat()
		{
			throw new NotImplementedException();
		}

		public double ReadDouble()
		{
			throw new NotImplementedException();
		}

		public string ReadString()
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
