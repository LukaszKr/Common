using ProceduralLevel.Serialization;

namespace ProceduralLevel.Game.ID
{
	public abstract class BaseIDProvider: IObjectSerializable
    {
		public abstract int GetID();
		public abstract void ReserveID(int ID);
		public virtual void ReleaseID(int ID) { }

		public abstract void Serialize(AObject serializer);
		public abstract void Deserialize(AObject serializer);
	}
}
