namespace Common.Serialization
{
	public interface IDeserializer
    {
		int Count { get; }

		void Clear();
		void Load(IDataReader reader);
		void FromString(string str);

		#region Read
		void ReadObject(IPairSerializable obj);
		void ReadArray(ISerializable obj);
		IPairDeserializer ReadObject();
		IDeserializer ReadArray();
		bool ReadBool();
		byte ReadByte();
		short ReadShort();
		int ReadInt();
		long ReadLong();
		float ReadFloat();
		double ReadDouble();
		string ReadString();

		void ReadObject(int index, IPairSerializable obj);
		void ReadArray(int index, ISerializable obj);
		IPairDeserializer ReadObject(int index);
		IDeserializer ReadArray(int index);
		bool ReadBool(int index);
		byte ReadByte(int index);
		short ReadShort(int index);
		int ReadInt(int index);
		long ReadLong(int index);
		float ReadFloat(int index);
		double ReadDouble(int index);
		string ReadString(int index);
		#endregion
	}
}
