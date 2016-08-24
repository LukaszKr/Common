namespace Common.Serialization
{
	public interface IPairDeserializer
    {
		void Load(IDataReader reader);

		#region Read
		IPairDeserializer ReadObject(string key);
		IDeserializer ReadArray(string key);
		void ReadObject(string key, IPairSerializable obj);
		void ReadArray(string key, ISerializable obj);
		bool ReadBool(string key);
		byte ReadByte(string key);
		short ReadShort(string key);
		int ReadInt(string key);
		long ReadLong(string key);
		float ReadFloat(string key);
		double ReadDouble(string key);
		string ReadString(string key);

		IPairDeserializer TryReadObject(string key);
		IDeserializer TryReadArray(string key);
		bool TryReadObject(string key, IPairSerializable obj);
		bool TryReadArray(string key, ISerializable obj);
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
