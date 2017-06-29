namespace ProceduralLevel.Serialization
{
	public abstract partial class AObject
	{
		public abstract int Count { get; }

		public abstract string[] Keys();
		public abstract void Clear();
		
		public abstract bool ContainsKey(string key);
		public abstract bool DeleteKey(string key);

		public abstract AObject WriteObject(string key);
		public abstract AArray WriteArray(string key);
		public abstract AObject ReadObject(string key);
		public abstract AArray ReadArray(string key);

		public abstract string ToString(bool formatted);
	}
}
