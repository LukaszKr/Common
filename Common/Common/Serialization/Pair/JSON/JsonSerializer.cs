﻿using Common.Parsing;
using System.Collections;

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

		public void Clear()
		{
			m_Object = new JsonObject();
		}

		#region Write
		public void Write(string key, bool data)
		{
			m_Object.Write(key, data);
		}

		public void Write(string key, byte data)
		{
			m_Object.Write(key, data);
		}

		public void Write(string key, short data)
		{
			m_Object.Write(key, data);
		}

		public void Write(string key, int data)
		{
			m_Object.Write(key, data);
		}

		public void Write(string key, long data)
		{
			m_Object.Write(key, data);
		}

		public void Write(string key, float data)
		{
			m_Object.Write(key, data);
		}

		public void Write(string key, double data)
		{
			m_Object.Write(key, data);
		}

		public void Write(string key, string data)
		{
			m_Object.Write(key, data);
		}

		public void Write(string key, object[] array)
		{
			JsonArray jsonArray = new JsonArray(array.Length);
			for(int x = 0; x < array.Length; x++)
			{
				object value = array[x];
				if(value == null || value is string)
				{
					jsonArray.Write(value as string);
				}
				else if(value.GetType().IsArray)
				{
					jsonArray.Write(value as object[]);
				}
				else
				{
					jsonArray.WriteObject(value);
				}
			}
			m_Object.Write(key, jsonArray);
		}

		public void Write(string key, IEnumerable array)
		{
			JsonArray jsonArray = new JsonArray(4);
			foreach(object obj in array)
			{
				if(obj == null || obj is string)
				{
					jsonArray.Write(obj as string);
				}
				else if(obj.GetType().IsArray)
				{
					jsonArray.Write(obj as object[]);
				}
				else
				{
					jsonArray.WriteObject(obj);
				}
			}
			m_Object.Write(key, jsonArray);
		}

		public void Write(string key, IPairSerializable serializable)
		{
			JsonSerializer serializer = new JsonSerializer();
			serializable.Serialize(serializer);
			m_Object.Write(key, serializer.m_Object);
		}
		#endregion
	}
}
