namespace ProceduralLevel.Serialization
{
	public interface IArraySerializer
	{
		int Count { get; }

		void Clear();
		void Load(string rawData);
		string ToString();

		#region Write
		void Write(IObjectSerializable serializable);
		void Write(IArraySerializable serializable);
		void Write(string data);
		void Write(object data);
		IObjectSerializer WriteObject();
		IArraySerializer WriteArray();
		void WriteArray(object[] data);
		#endregion

		#region Read
		void ReadObject(IObjectSerializable obj);
		void ReadArray(IArraySerializable obj);
		IObjectSerializer ReadObject();
		IArraySerializer ReadArray();
		bool ReadBool();
		byte ReadByte();
		short ReadShort();
		int ReadInt();
		long ReadLong();
		float ReadFloat();
		double ReadDouble();
		string ReadString();
		object Read();

		void ReadObject(int index, IObjectSerializable obj);
		void ReadArray(int index, IArraySerializable obj);
		IObjectSerializer ReadObject(int index);
		IArraySerializer ReadArray(int index);
		bool ReadBool(int index);
		byte ReadByte(int index);
		short ReadShort(int index);
		int ReadInt(int index);
		long ReadLong(int index);
		float ReadFloat(int index);
		double ReadDouble(int index);
		string ReadString(int index);
		object Read(int index);
		#endregion
	}
}
