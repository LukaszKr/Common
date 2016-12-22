namespace ProceduralLevel.Common.Serialization
{
	public interface IObjectDeserializer
    {
		void Load(IDataReader reader);
		void Clear();

		#region Read
		IObjectDeserializer ReadObject(string key);
		IArrayDeserializer ReadArray(string key);
		void ReadObject(string key, IObjectSerializable obj);
		void ReadArray(string key, IArraySerializable obj);
		bool ReadBool(string key);
		byte ReadByte(string key);
		short ReadShort(string key);
		int ReadInt(string key);
		long ReadLong(string key);
		float ReadFloat(string key);
		double ReadDouble(string key);
		string ReadString(string key);

		IObjectDeserializer TryReadObject(string key);
		IArrayDeserializer TryReadArray(string key);
		bool TryReadObject(string key, IObjectSerializable obj);
		bool TryReadArray(string key, IArraySerializable obj);
		bool TryReadBool(string key, bool defaultValue = false);
		byte TryReadByte(string key, byte defaultValue = 0);
		short TryReadShort(string key, short defaultValue = 0);
		int TryReadInt(string key, int defaultValue = 0);
		long TryReadLong(string key, long defaultValue = 0);
		float TryReadFloat(string key, float defaultValue = 0f);
		double TryReadDouble(string key, double defaultValue = 0);
		string TryReadString(string key, string defaultValue = null);
		#endregion
	}
}
