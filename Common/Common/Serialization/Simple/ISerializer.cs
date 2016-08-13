namespace Common.Serialization
{
	public interface ISerializer
	{
		int Count { get; }

		void Clear();
		void Save(IDataWriter writer);
		string ToString();

		#region Write
		void Write(ISerializable serializable);
		void Write(object data);
		void Write(string data);
		#endregion
	}
}
