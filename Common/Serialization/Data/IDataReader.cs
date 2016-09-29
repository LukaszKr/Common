﻿namespace ProceduralLevel.Common.Serialization
{
	public interface IDataReader
    {
		byte[] ReadBytes();
		string ReadString();
		bool CanRead();
    }
}