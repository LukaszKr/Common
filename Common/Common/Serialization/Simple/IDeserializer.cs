﻿namespace Common.Serialization
{
	public interface IDeserializer
    {
		void Clear();
		void Load(IDataReader reader);

		#region Read
		void Read(ISerializable obj);
		bool ReadBool();
		byte ReadByte();
		short ReadShort();
		int ReadInt();
		long ReadLong();
		float ReadFloat();
		double ReadDouble();
		string ReadString();
		#endregion
	}
}
