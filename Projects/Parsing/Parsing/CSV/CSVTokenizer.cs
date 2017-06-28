namespace ProceduralLevel.Parsing
{
	public class CSVTokenizer: ATokenizer
	{
		private string[] m_Separators;

		public CSVTokenizer(string separator)
		{
			m_Separators = new string[] { CSVConst.QUOTATION, CSVConst.NEW_LINE, separator };
		}

		protected override string[] GetDefaultSeparators()
		{
			return m_Separators;
		}
	}
}
