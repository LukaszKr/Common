using ProceduralLevel.Common.Parsing;

namespace ProceduralLevel.Common.Serialization
{
	public class JsonArraySerializer: IArraySerializer
	{
		public JsonArray Array { get; private set; }

		public int Count { get { return Array.Count; } }

		public JsonArraySerializer()
		{
			Array = new JsonArray(4);
		}

		public void Save(IDataWriter writer)
		{
			writer.Write(Array.ToString());
		}

		public void Clear()
		{
			Array = new JsonArray(4);
		}

		public override string ToString()
		{
			return Array.ToString();
		}

		#region Write
		public void Write(IObjectSerializable serializable)
		{
			JsonObjectSerializer serializer = new JsonObjectSerializer();
			serializable.Serialize(serializer);
			Array.Write(serializer.Object);
		}

		public void Write(IArraySerializable serializable)
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
