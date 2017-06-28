﻿namespace ProceduralLevel.Serialization
{
	public interface IObjectSerializable
    {
		void Serialize(IObjectSerializer serializer);
		void Deserialize(IObjectSerializer serializer);
    }
}
