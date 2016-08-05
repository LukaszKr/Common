namespace Common.Serialization
{
	public interface IBinaryReader
    {
		byte[] Read();
		bool CanRead();
    }
}
