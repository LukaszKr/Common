namespace ProceduralLevel.Common.Serialization
{
    public interface IArraySerializable
	{
		void Serialize(AArray serializer);
		void Deserialize(AArray serializer);
	}
}
