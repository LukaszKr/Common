﻿using ProceduralLevel.Common.Serialization;

namespace ProceduralLevel.Common.Achievement
{
	public class ToggleAchievement: BaseAchievement
    {
		public override EAchievementType AchievementType { get { return EAchievementType.Toggle; } }

		public const string KEY_UNLOCKED = "unlocked";

		public bool Unlocked { get; private set; }

		public ToggleAchievement(AchievementManager achievementManager, int id, bool unlocked = false) : base(achievementManager, id)
		{
			Unlocked = unlocked;
		}

		public ToggleAchievement(AchievementManager achievementManager, IPairDeserializer deserializer) : base(achievementManager, deserializer)
		{
		}

		public override void Deserialize(IPairDeserializer deserializer)
		{
			base.Deserialize(deserializer);
			Unlocked = deserializer.TryReadBool(KEY_UNLOCKED);
		}

		public override void Serialize(IPairSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write(KEY_UNLOCKED, Unlocked);
		}

		public override bool IsAchieved()
		{
			return Unlocked;
		}

		public void Unlock()
		{
			Unlocked = true;
			m_AchievementManager.OnAchievementUnlocked(this);
		}
    }
}
