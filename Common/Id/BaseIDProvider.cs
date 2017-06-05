using ProceduralLevel.Common.Serialization;

namespace ProceduralLevel.Common.Id
{
	public abstract class BaseIDProvider: IObjectSerializable
    {
		public abstract int GetID();
		public abstract void ReserveID(int ID);
		public virtual void ReleaseID(int ID) { }

		public abstract void Serialize(IObjectSerializer serializer);
		public abstract void Deserialize(IObjectSerializer serializer);
	}
}
