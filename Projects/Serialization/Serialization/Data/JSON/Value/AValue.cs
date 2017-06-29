namespace ProceduralLevel.Serialization.Json
{
	public abstract class AValue
	{
		public readonly EValueType Type;

		public AValue(EValueType type)
		{
			Type = type;
		}
	}
}
