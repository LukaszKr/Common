namespace Common.Serialization
{
	public interface IPairDeserializer
    {
		void Clear();
		void Load(IDataReader reader);

		#region Read
		void Read(string key, IPairSerializable obj);
		//void Read(string key, ISerializable obj);
		IPairDeserializer ReadObject(string key);
		bool ReadBool(string key);
		byte ReadByte(string key);
		short ReadShort(string key);
		int ReadInt(string key);
		long ReadLong(string key);
		float ReadFloat(string key);
		double ReadDouble(string key);
		string ReadString(string key);

		bool TryRead(string key, IPairSerializable obj);
		//bool TryRead(string key, ISerializable obj);
		bool TryRead(string key, out IPairDeserializer data);
		bool TryRead(string key, out bool data, bool defaultValue = false);
		bool TryRead(string key, out byte data, byte defaultValue = 0);
		bool TryRead(string key, out short data, short defaultValue = 0);
		bool TryRead(string key, out int data, int defaultValue = 0);
		bool TryRead(string key, out long data, long defaultValue = 0);
		bool TryRead(string key, out float data, float defaultValue = 0f);
		bool TryRead(string key, out double data, double defaultValue = 0);
		bool TryRead(string key, out string data, string defaultValue = null);
		#endregion
	}
}
