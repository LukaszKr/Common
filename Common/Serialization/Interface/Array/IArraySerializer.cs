namespace ProceduralLevel.Common.Serialization
{
	public interface IArraySerializer
	{
		int Count { get; }

		void Clear();
		void Save(IDataWriter writer);
		string ToString();

		#region Write
		void Write(IObjectSerializable serializable);
		void Write(IArraySerializable serializable);
		void Write(string data);
		void Write(object data);
		#endregion
	}
}
