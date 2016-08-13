namespace Common.Serialization
{
	public interface IDeserializer
    {
		int Count { get; }

		void Clear();
		void Load(IDataReader reader);
		void FromString(string str);

		#region Read
		void Read(ISerializable obj);
		bool ReadBool();
		byte ReadByte();
		short ReadShort();
		int ReadInt();
		long ReadLong();
		float ReadFloat();
		double ReadDouble();
		string ReadString();

		void Read(int index, ISerializable obj);
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
