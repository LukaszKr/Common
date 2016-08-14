using Common.Parsing;

namespace Common.Serialization
{
	public class JsonSerializer: IPairSerializer
	{
		protected JsonObject m_Object;

		public JsonSerializer()
		{
			m_Object = new JsonObject();
		}

		public void Save(IDataWriter writer)
		{
			writer.Write(m_Object.ToString());
		}

		#region Write
		public void Write(string key, object data)
		{
			m_Object.Write(key, data);
		}


		public void WriteObject(string key, IPairSerializable serializable)
		{
			JsonSerializer serializer = new JsonSerializer();
			serializable.Serialize(serializer);
			m_Object.WriteObject(key, serializer.m_Object);
		}

		public void WriteArray(string key, object[] array)
		{
			JsonArray jsonArray = new JsonArray(array.Length);
			for(int x = 0; x < array.Length; x++)
			{
				object value = array[x];
				if(value == null || value is string)
				{
					jsonArray.WriteString(value as string);
				}
				else if(value.GetType().IsArray)
				{
					jsonArray.WriteArray(value as object[]);
				}
				else
				{
					jsonArray.Write(array[x]);
				}
			}
			m_Object.WriteArray(key, jsonArray);
		}

		public void WriteString(string key, string data)
		{
			m_Object.WriteString(key, data);
		}
		#endregion
	}
}
