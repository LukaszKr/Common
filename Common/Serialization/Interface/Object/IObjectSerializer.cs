using System.Collections.Generic;

namespace ProceduralLevel.Common.Serialization
{
	public interface IObjectSerializer
	{
		void Load(string rawData);
		void Load(IDataReader reader);
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
		void WriteObject(string key, object data);
		IObjectSerializer WriteObject(string key);
		IArraySerializer WriteArray(string key);
		#endregion

		#region Read
		IObjectSerializer ReadObject(string key);
		IArraySerializer ReadArray(string key);
		void ReadObject(string key, IObjectSerializable obj);
		void ReadArray(string key, IArraySerializable obj);
		bool ReadBool(string key);
		byte ReadByte(string key);
		short ReadShort(string key);
		int ReadInt(string key);
		long ReadLong(string key);
		float ReadFloat(string key);
		double ReadDouble(string key);
		string ReadString(string key);

		IObjectSerializer TryReadObject(string key);
		IArraySerializer TryReadArray(string key);
		bool TryReadObject(string key, IObjectSerializable obj);
		bool TryReadArray(string key, IArraySerializable obj);
		bool TryReadBool(string key, bool defaultValue = false);
		byte TryReadByte(string key, byte defaultValue = 0);
		short TryReadShort(string key, short defaultValue = 0);
		int TryReadInt(string key, int defaultValue = 0);
		long TryReadLong(string key, long defaultValue = 0);
		float TryReadFloat(string key, float defaultValue = 0f);
		double TryReadDouble(string key, double defaultValue = 0);
		string TryReadString(string key, string defaultValue = null);
		#endregion
	}
}
