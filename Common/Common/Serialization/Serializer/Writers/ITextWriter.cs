namespace Common.Serialization
{
	public interface ITextWriter
    {
		void Write(string text);
		bool CanWrite();
    }
}
