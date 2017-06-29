using System;
using System.Reflection;

namespace ProceduralLevel.Serialization
{
	public class Serializer: ASerializer
    {
		protected Serializer() { }

		#region Serialization
		public static void Serialize(object obj, AObject serializer)
		{
			Serializer processor = new Serializer();
			processor.SerializeObject(obj, serializer);
		}

		public override void SerializeObject(object obj, AObject serializer)
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

		protected void SerializeField(object value, FieldInfo field, AObject serializer, AArray arraySerializer)
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
		public static DataType Deserialize<DataType>(AObject serializer, DataType instance = null) where DataType: class
		{
			return (DataType)Deserialize(typeof(DataType), serializer, instance);
		}

		public static object Deserialize(Type type, AObject serializer, object instance = null)
		{
			Serializer processor = new Serializer();
			return processor.DeserializeObject(type, serializer, instance);
		}

		public override object DeserializeObject(Type type, AObject serializer, object instance = null)
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

		private void DeserializeField(object obj, FieldInfo field, AObject serializer, AArray arraySerializer)
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
