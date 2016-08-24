using Common.Parsing;
using System;

namespace Common.Serialization
{
	public class JsonArraySerializer: ISerializer
	{
		public JsonArray Array { get; private set; }

		public int Count { get { return Array.Count; } }

		public void Clear()
		{
			throw new NotImplementedException();
		}

		public void Save(IDataWriter writer)
		{
			writer.Write(Array.ToString());
		}

		#region Write
		public void Write(IPairSerializable serializable)
		{
			JsonObjectSerializer serializer = new JsonObjectSerializer();
			serializable.Serialize(serializer);
			Array.Write(serializer.Object);
		}

		public void Write(ISerializable serializable)
		{
			JsonArraySerializer serializer = new JsonArraySerializer();
			serializable.Serialize(serializer);
			Array.Write(serializer.Array);
		}

		public void Write(string data)
		{
			Array.Write(data);
		}

		public void Write(object data)
		{
			Array.WriteObject(data);
		}
		#endregion
	}
}
