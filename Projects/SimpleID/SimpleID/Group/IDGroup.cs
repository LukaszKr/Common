namespace ProceduralLevel.Common.SimpleID
{
	public class IDGroup: AIDGroup<ID>
	{
		protected override ID CreateInstance(uint value, string name)
		{
			return new ID(value, name);
		}
	}
}
