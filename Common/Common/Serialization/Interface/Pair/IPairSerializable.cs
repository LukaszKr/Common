namespace Common.Serialization
{
	public interface IPairSerializable
    {
		void Serialize(IPairSerializer serializer);
		void Deserialize(IPairDeserializer deserializer);
    }
}
