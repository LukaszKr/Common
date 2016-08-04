namespace Common.Serialization
{
	public interface IDeserializer
    {
		void Clear();
		void Load();

		#region Read
		void Read<ObjectType>(ObjectType obj) where ObjectType : ISerializable;
		void Read(out bool data);
		void Read(out byte data);
		void Read(out short data);
		void Read(out int data);
		void Read(out long data);
		void Read(out float data);
		void Read(out double data);
		void Read(out string data);
		#endregion
	}
}
