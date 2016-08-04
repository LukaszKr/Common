namespace Common.Serialization
{
	public abstract class SerializationManager
    {
		public ISerializer Serializer { get; private set; }
		public IDeserializer Deserializer { get; private set; }

		public SerializationManager(ISerializer serializer, IDeserializer deserializer)
		{	
			Serializer = serializer;
			Deserializer = deserializer;
		}
    }
}
