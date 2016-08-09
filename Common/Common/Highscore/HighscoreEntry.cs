using Common.Serialization;

namespace Common.Highscore
{
	public class HighscoreEntry: ISerializable
    {
		public string Name { get; private set; }
		public int Value { get; private set; }

		public HighscoreEntry(IDeserializer deserializer)
		{
			Deserialize(deserializer);
		}

		public HighscoreEntry(string name, int value)
		{
			Name = name;
			Value = value;
		}

		public void Deserialize(IDeserializer deserializer)
		{
			Name = deserializer.ReadString();
			Value = deserializer.ReadInt();
		}

		public void Serialize(ISerializer serializer)
		{
			serializer.Write(Name);
			serializer.Write(Value);
		}
	}
}
