namespace ProceduralLevel.Common.Serialization
{
	public class Reference
    {
		public string FieldName;
		public int ObjectID;

		public Reference(string fieldName, int objectID)
		{
			FieldName = fieldName;
			ObjectID = objectID;
		}
    }
}
