namespace ProceduralLevel.Common.Serialization
{
	public interface IArrayDeserializer
    {
		int Count { get; }

		void Clear();
		void Load(IDataReader reader);
		void Load(string rawData);

		#region Read
		void ReadObject(IObjectSerializable obj);
		void ReadArray(IArraySerializable obj);
		IObjectDeserializer ReadObject();
		IArrayDeserializer ReadArray();
		bool ReadBool();
		byte ReadByte();
		short ReadShort();
		int ReadInt();
		long ReadLong();
		float ReadFloat();
		double ReadDouble();
		string ReadString();

		void ReadObject(int index, IObjectSerializable obj);
		void ReadArray(int index, IArraySerializable obj);
		IObjectDeserializer ReadObject(int index);
		IArrayDeserializer ReadArray(int index);
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
