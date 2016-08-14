namespace Common.Serialization
{
	public interface IPairSerializer
    {
		void Save(IDataWriter writer);

		#region Write
		void Write(string key, object data);
		void WriteObject(string key, IPairSerializable serializable);
		void WriteArray(string key, object[] array);
		void WriteString(string key, string data);
		#endregion
	}
}
