namespace Common.Serialization
{
	public interface IDataWriter
    {
		void Write(byte[] data);
		void Write(string data);
		bool CanWrite();
    }
}
