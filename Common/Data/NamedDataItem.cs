namespace ProceduralLevel.Common.Data
{
	public class NamedDataItem: IDataItem
	{
		protected string m_Name;

		public string Name
		{
			get { return m_Name; }
		}

		public NamedDataItem(string name)
		{

		}
	}
}
