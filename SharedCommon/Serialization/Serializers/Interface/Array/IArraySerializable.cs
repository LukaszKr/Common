namespace ProceduralLevel.Common.Serialization
{
	public interface IArraySerializable
    {
		void Serialize(IArraySerializer serializer);
		void Deserialize(IArraySerializer serializer);
    }
}
