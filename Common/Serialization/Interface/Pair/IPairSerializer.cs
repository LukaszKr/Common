using System.Collections.Generic;

namespace ProceduralLevel.Common.Serialization
{
	public interface IPairSerializer
    {
		void Save(IDataWriter writer);
		void Clear();

		#region Write
		void Write(string key, bool data);
		void Write(string key, byte data);
		void Write(string key, short data);
		void Write(string key, int data);
		void Write(string key, long data);
		void Write(string key, float data);
		void Write(string key, double data);
		void Write(string key, string data);
		void Write(string key, IPairSerializable serializable);
		void Write(string key, ISerializable serializable);
		void Write(string key, IEnumerable<IPairSerializable> serializables);
		void Write(string key, IEnumerable<ISerializable> serializables);
		IPairSerializer WriteObject(string key);
		void Write(object kEY_NAME);
		ISerializer WriteArray(string key);
		#endregion
	}
}
