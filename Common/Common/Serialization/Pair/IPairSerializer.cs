namespace Common.Serialization
{
	public interface IPairSerializer
    {
		void Clear();
		void Save(IDataWriter writer);

		#region Write
		void Write(string key, IPairSerializable serializable);
		void Write(string key, ISerializable serializable);
		void Write(string key, object data);
		void Write(string key, string data);

		void Write(string key, object[] array);
		void Write(string key, string[] array);
		#endregion
	}
}
