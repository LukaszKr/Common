using System;
using System.Reflection;

namespace ProceduralLevel.Common.Serialization
{
	public class Serializer: ASerializer
    {
		protected Serializer() { }

		#region Serialization
		public static void Serialize(object obj, IObjectSerializer serializer)
		{
			Serializer processor = new Serializer();
			processor.SerializeObject(obj, serializer);
		}

		public override void SerializeObject(object obj, IObjectSerializer serializer)
		{
			if(obj == null)
			{
				return;
			}

			FieldInfo[] fields = GetSerializableFields(obj.GetType());
			if(fields != null)
			{
				for(int x = 0; x < fields.Length; x++)
				{
					FieldInfo field = fields[x];
					SerializeField(field.GetValue(obj), field, serializer, null);
				}
			}
		}

		protected void SerializeField(object value, FieldInfo field, IObjectSerializer serializer, IArraySerializer arraySerializer)
		{
			if(value == null)
			{
				return;
			}
			Type fieldType = field.FieldType;
			TypeSerializer typeSerializer = GetTypeSerializer(fieldType);
			if(typeSerializer != null)
			{
				typeSerializer.Serialize(this, value, field, serializer, arraySerializer);
			}
		}
		#endregion

		#region Deserialization
		public static DataType Deserialize<DataType>(IObjectSerializer serializer, DataType instance = null) where DataType: class
		{
			return (DataType)Deserialize(typeof(DataType), serializer, instance);
		}

		public static object Deserialize(Type type, IObjectSerializer serializer, object instance = null)
		{
			Serializer processor = new Serializer();
			return processor.DeserializeObject(type, serializer, instance);
		}

		public override object DeserializeObject(Type type, IObjectSerializer serializer, object instance = null)
		{
			if(serializer == null)
			{
				return null;
			}
			if(instance == null)
			{
				instance = Activator.CreateInstance(type);
			}
			if(instance is IObjectSerializable serializable)
			{
				serializable.Deserialize(serializer);
			}
			else
			{
				FieldInfo[] fields = GetSerializableFields(type);
				for(int x = 0; x < fields.Length; x++)
				{
					FieldInfo field = fields[x];
					DeserializeField(instance, field, serializer, null);
				}
			}
			return instance;
		}

		private void DeserializeField(object obj, FieldInfo field, IObjectSerializer serializer, IArraySerializer arraySerializer)
		{
			Type fieldType = field.FieldType;
			TypeSerializer typeSerializer = GetTypeSerializer(fieldType);
			if(typeSerializer != null)
			{
				field.SetValue(obj, Convert.ChangeType(typeSerializer.Deserialize(this, fieldType, field.Name, serializer, arraySerializer), fieldType));
			}
		}
		#endregion
	}
}
