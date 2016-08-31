using ProceduralLevel.Common.Serialization;
using System;

namespace ProceduralLevel.Common.Achievement
{
	public abstract class ProgressAchievement: BaseAchievement
	{
		private const string KEY_PROGRESS = "progress";
		private const string KEY_TARGET = "target";

		public int Target { get; private set; }
		public int Progress { get; private set; }

		public ProgressAchievement(int id, int target, int progress = 0) : base(id)
		{
			Target = target;
			Progress = progress;
		}

		public ProgressAchievement(IPairDeserializer deserializer) : base(deserializer)
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
			int oldProgress = Progress;
			Progress = Math.Min(progress, Target);
			if(IsAchieved())
			{
				OnAchieved();
			}
			else
			{
				OnProgress(oldProgress, Progress);
			}
		}

		protected abstract void OnProgress(int oldValue, int newValue);
	}
}
