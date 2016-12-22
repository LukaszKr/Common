namespace ProceduralLevel.Common.Serialization
{
	public interface IObjectSerializable
    {
		void Serialize(IObjectSerializer serializer);
		void Deserialize(IObjectDeserializer deserializer);
    }
}
