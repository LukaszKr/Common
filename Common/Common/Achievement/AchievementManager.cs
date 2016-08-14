using System;
using Common.Serialization;

namespace Common.Achievement
{
	public class AchievementManager: IPairSerializable
	{
		public AchievementManager()
		{

		}

		public void Save()
		{

		}

		public void Deserialize(IPairDeserializer deserializer)
		{
			throw new NotImplementedException();
		}

		public void Serialize(IPairSerializer serializer)
		{
			throw new NotImplementedException();
		}
	}
}
