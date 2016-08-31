using ProceduralLevel.Common.Serialization;

namespace ProceduralLevel.Common.Achievement
{
	public abstract class BaseAchievement: IPairSerializable
	{
		private const string KEY_ACHIEVEMENT_ID = "id";

		public int ID { get; private set; }

		public BaseAchievement(int id)
		{
			ID = id;
		}

		public BaseAchievement(IPairDeserializer deserializer)
		{
			Deserialize(deserializer);
		}

		public abstract bool IsAchieved();
		protected abstract void OnAchieved();

		public virtual void Deserialize(IPairDeserializer deserializer)
		{
		}

		public virtual void Serialize(IPairSerializer serializer)
		{
			serializer.Write(KEY_ACHIEVEMENT_ID, ID);
		}
	}
}
