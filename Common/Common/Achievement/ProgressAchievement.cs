using Common.Serialization;

namespace Common.Achievement
{
	public class ProgressAchievement: BaseAchievement
	{
		public override EAchievementType AchievementType { get { return EAchievementType.Progress; } }

		private const string KEY_PROGRESS = "progress";
		private const string KEY_TARGET = "target";

		public int Target { get; private set; }
		public int Progress { get; private set; }


		public ProgressAchievement(AchievementManager achievementManager, int target, int progress = 0) : base(achievementManager)
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
	}
}
