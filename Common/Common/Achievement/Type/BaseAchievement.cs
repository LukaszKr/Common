using Common.Serialization;
using System;

namespace Common.Achievement
{
	public abstract class BaseAchievement: IPairSerializable
	{
		private const string KEY_ID = "id";
		private const string KEY_ACHIEVEMENT_TYPE = "type";

		protected AchievementManager m_AchievementManager;

		public int ID { get; private set; }
		public abstract EAchievementType AchievementType { get; }

		public BaseAchievement(AchievementManager achievementManager, int id)
		{
			m_AchievementManager = achievementManager;
			ID = id;
		}

		public BaseAchievement(AchievementManager achievementManager, IPairDeserializer deserializer)
		{
			m_AchievementManager = achievementManager;
			Deserialize(deserializer);
		}

		public static BaseAchievement CreateAndDeserialize(AchievementManager manager, IPairDeserializer deserialize)
		{
			EAchievementType achievementType = (EAchievementType)deserialize.ReadInt(KEY_ACHIEVEMENT_TYPE);
			switch(achievementType)
			{
				case EAchievementType.Toggle:
					return new ToggleAchievement(manager, deserialize);
				case EAchievementType.Progress:
					return new ProgressAchievement(manager, deserialize);
				default:
					throw new Exception(string.Format("{0} is not a supported achievement type", achievementType.ToString()));
			}
		}

		public abstract bool IsAchieved();

		public virtual void Deserialize(IPairDeserializer deserializer)
		{
			ID = deserializer.ReadInt(KEY_ID);
		}

		public virtual void Serialize(IPairSerializer serializer)
		{
			serializer.Write(KEY_ACHIEVEMENT_TYPE, (int)AchievementType);
			serializer.Write(KEY_ID, ID);
		}
	}
}
