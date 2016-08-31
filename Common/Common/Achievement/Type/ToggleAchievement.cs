using ProceduralLevel.Common.Serialization;

namespace ProceduralLevel.Common.Achievement
{
	public abstract class ToggleAchievement: BaseAchievement
    {
		public const string KEY_UNLOCKED = "unlocked";

		public bool Unlocked { get; private set; }

		public ToggleAchievement(int id, bool unlocked = false) : base(id)
		{
			Unlocked = unlocked;
		}

		public ToggleAchievement(IPairDeserializer deserializer) : base(deserializer)
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
			OnAchieved();
		}
    }
}
