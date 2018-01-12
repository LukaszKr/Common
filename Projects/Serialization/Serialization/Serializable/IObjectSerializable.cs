namespace ProceduralLevel.Common.Serialization
{
	public interface IObjectSerializable
    {
		void Serialize(AObject serializer);
		void Deserialize(AObject serializer);
    }
}
