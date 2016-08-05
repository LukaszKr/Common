namespace Common.Serialization
{
	public interface ITextReader
    {
		string Read();
		bool CanRead();
    }
}
