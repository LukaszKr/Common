using ProceduralLevel.Common.Serialization;
using System.Collections.Generic;

namespace ProceduralLevel.Common.Achievement
{
	public abstract class AchievementManager: IPairSerializable
	{
		public const string KEY_ACHIEVEMENTS = "achievements";

		protected List<BaseAchievement> m_Achievements;

		public AchievementManager()
		{
			m_Achievements = new List<BaseAchievement>();
		}

		public void Deserialize(IPairDeserializer deserializer)
		{
			IDeserializer arrayDeserializer = deserializer.ReadArray(KEY_ACHIEVEMENTS);
			for(int x = 0; x < arrayDeserializer.Count; x++)
			{
				m_Achievements.Add(BaseAchievement.CreateAndDeserialize(this, arrayDeserializer.ReadObject()));
			}
		}

		public void Serialize(IPairSerializer serializer)
		{
			ISerializer arraySerializer = serializer.WriteArray(KEY_ACHIEVEMENTS);
			for(int x = 0; x < m_Achievements.Count; x++)
			{
				arraySerializer.Write(m_Achievements[x]);
			}
		}

		public BaseAchievement GetAchievementByID(int id)
		{
			for(int x = 0; x < m_Achievements.Count; x++)
			{
				BaseAchievement achievement = m_Achievements[x];
				if(achievement.ID == id)
				{
					return achievement;
				}
			}
			return null;
		}

		public abstract void OnAchievementUnlocked(BaseAchievement achievement);
	}
}
