using ProceduralLevel.Common.Serialization;
using System;

namespace ProceduralLevel.Common.Achievement
{
	public class ProgressAchievement: BaseAchievement
	{
		public override EAchievementType AchievementType { get { return EAchievementType.Progress; } }

		private const string KEY_PROGRESS = "progress";
		private const string KEY_TARGET = "target";

		public int Target { get; private set; }
		public int Progress { get; private set; }


		public ProgressAchievement(AchievementManager achievementManager, int id, int target, int progress = 0) : base(achievementManager, id)
		{
			Target = target;
			Progress = progress;
		}

		public ProgressAchievement(AchievementManager achievementManager, IPairDeserializer deserializer) : base(achievementManager, deserializer)
		{
		}

		public override void Deserialize(IPairDeserializer deserializer)
		{
			base.Deserialize(deserializer);
			Progress = deserializer.TryReadInt(KEY_PROGRESS);
			Target = deserializer.TryReadInt(KEY_TARGET);
		}

		public override void Serialize(IPairSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write(KEY_PROGRESS, Progress);
			serializer.Write(KEY_TARGET, Target);
		}

		public override bool IsAchieved()
		{
			return Progress == Target;
		}

		public void AddProgress(int progress)
		{
			SetProgress(Progress+progress);
		}

		public void SetProgress(int progress, bool onlyIncrease = true)
		{
			int newProgress = progress;
			if(onlyIncrease)
			{
				newProgress = Math.Max(progress, Progress);
			}
			Progress = Math.Min(progress, Target);
			if(IsAchieved())
			{
				m_AchievementManager.OnAchievementUnlocked(this);
			}
		}
	}
}
