using System.Collections.Generic;

namespace ProceduralLevel.Common.Serialization
{
	public class ObjectMap
    {
		public int ID;
		public object Data;
		public List<Reference> References = new List<Reference>();

		public ObjectMap(int id,  object data)
		{
			ID = id;
			Data = data;
		}
    }
}
