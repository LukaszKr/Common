namespace Common.Serialization
{
	public interface IPairSerializer
    {
		void Clear();
		void Save(IDataWriter writer);

		#region Write
		void Write(string key, IPairSerializable serializable);
		void Write(string key, bool data);
		void Write(string key, byte data);
		void Write(string key, short data);
		void Write(string key, int data);
		void Write(string key, long data);
		void Write(string key, float data);
		void Write(string key, double data);
		void Write(string key, string data);
		#endregion
	}
}
