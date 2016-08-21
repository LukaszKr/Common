using System;
using Common.Serialization;
using System.Collections.Generic;

namespace Common.Achievement
{
	public class AchievementManager: IPairSerializable
	{
		public const string KEY_ACHIEVEMENTS = "achievements";

		protected List<BaseAchievement> m_Achievements;

		public AchievementManager()
		{
			m_Achievements = new List<BaseAchievement>();
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
			serializer.Write(KEY_ACHIEVEMENTS, m_Achievements);
		}
	}
}
