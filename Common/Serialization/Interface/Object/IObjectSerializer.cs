using System.Collections.Generic;

namespace ProceduralLevel.Common.Serialization
{
	public interface IObjectSerializer
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
		void Write(string key, IObjectSerializable serializable);
		void Write(string key, IArraySerializable serializable);
		void Write(string key, IEnumerable<IObjectSerializable> serializables);
		void Write(string key, IEnumerable<IArraySerializable> serializables);
		IObjectSerializer WriteObject(string key);
		IArraySerializer WriteArray(string key);
		#endregion
	}
}
