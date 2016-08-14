using Common.Serialization;

namespace Common.Achievement
{
	public abstract class BaseAchievement: IPairSerializable
	{
		private const string KEY_ACHIEVEMENT_TYPE = "type";

		protected AchievementManager m_AchievementManager;

		public abstract EAchievementType AchievementType { get; }

		public BaseAchievement(AchievementManager achievementManager)
		{
			m_AchievementManager = achievementManager;
		}

		public BaseAchievement(AchievementManager achievementManager, IPairDeserializer deserializer)
		{
			m_AchievementManager = achievementManager;
			Deserialize(deserializer);
		}

		protected void Save()
		{
			m_AchievementManager.Save();
		}

		public virtual void Deserialize(IPairDeserializer deserializer)
		{
			
		}

		public virtual void Serialize(IPairSerializer serializer)
		{
			serializer.Write(KEY_ACHIEVEMENT_TYPE, (int)AchievementType);
		}
	}
}
