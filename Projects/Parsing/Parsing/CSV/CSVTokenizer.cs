namespace ProceduralLevel.Parsing
{
	public class CSVTokenizer: ATokenizer
	{
		private char[] m_Separators;

		public CSVTokenizer(char separator)
		{
			m_Separators = new char[] { CSVConst.QUOTATION, CSVConst.NEW_LINE, separator };
		}

		protected override char[] GetDefaultSeparators()
		{
			return m_Separators;
		}
	}
}
