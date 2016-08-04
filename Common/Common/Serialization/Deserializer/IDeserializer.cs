namespace Common.Serialization
{
	public interface IDeserializer
    {
		void Clear();
		void Load();

		#region Read
		void Read<ObjectType>(ObjectType obj) where ObjectType : ISerializable;
		bool ReadBool();
		byte ReadByte();
		short ReadShort();
		int ReadInt();
		long ReadLong();
		float ReadFloat();
		double ReadDouble();
		string ReadString();
		#endregion
	}
}
