namespace ProceduralLevel.Common.Serialization
{
	public interface ISerializer
	{
		int Count { get; }

		void Clear();
		void Save(IDataWriter writer);
		string ToString();

		#region Write
		void Write(IPairSerializable serializable);
		void Write(ISerializable serializable);
		void Write(string data);
		void Write(object data);
		#endregion
	}
}
