using ProceduralLevel.Common.Tokenize;

namespace ProceduralLevel.Common.Serialization.CSV
{
    public class CSVTokenizer: ATokenizer
	{
		protected readonly static char[] m_Separators = new char[]
		{
			CSVConst.NEW_LINE, CSVConst.QUOTATION, CSVConst.SEPARATOR, CSVConst.RETURN
		};

		public CSVTokenizer(bool autoTrim = false) : base(autoTrim)
		{
		}

		protected override char[] GetSeparators()
		{
			return m_Separators;
		}
	}
}
