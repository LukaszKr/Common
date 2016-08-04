namespace Common.Serialization
{
	public interface ISerializer
	{
		void Clear();
		void Save();

		#region Write
		void Write(ISerializable serializable);
		void Write(bool data);
		void Write(byte data);
		void Write(short data);
		void Write(int data);
		void Write(long data);
		void Write(float data);
		void Write(double data);
		void Write(string data);
		#endregion
	}
}
