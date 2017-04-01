//using System;
//using System.Reflection;

//namespace ProceduralLevel.Common.Serialization
//{
//	public class ReferenceSerializer: ASerializer
//	{
//		private const string KEY_REF_OBJECTS = "Objects";

//		private IArraySerializer m_Objects;

//		protected ReferenceSerializer() { }

//		#region Serialization
//		public static void Serialize(object obj, IObjectSerializer serializer)
//		{
//			ReferenceSerializer processor = new ReferenceSerializer()
//			{
//				m_Objects = serializer.WriteArray(KEY_REF_OBJECTS)
//			};
//			processor.SerializeObject(obj, serializer);
//		}

//		public override void SerializeObject(object obj, IObjectSerializer serializer)
//		{
//			if(obj == null)
//			{
//				return;
//			}


//			FieldInfo[] fields = GetSerializableFields(obj.GetType());
//			if(fields != null)
//			{
//				for(int x = 0; x < fields.Length; x++)
//				{
//					//FieldInfo field = fields[x];

//					//SerializeField(field.GetValue(obj), field, serializer, null);
//				}
//			}
//		}
//		#endregion

//		#region Deserialization
//		public static DataType Deserialize<DataType>(IObjectSerializer serializer, DataType instance = null) where DataType : class
//		{
//			return (DataType)Deserialize(typeof(DataType), serializer, instance);
//		}

//		public static object Deserialize(Type type, IObjectSerializer serializer, object instance = null)
//		{
//			ReferenceSerializer processor = new ReferenceSerializer()
//			{
//				m_Objects = serializer.ReadArray(KEY_REF_OBJECTS)
//			};
//			return processor.DeserializeObject(type, serializer, instance);
//		}

//		public override object DeserializeObject(Type type, IObjectSerializer serializer, object instance = null)
//		{
//			return null;
//		}
//		#endregion
//	}
//}
