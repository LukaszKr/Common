namespace ProceduralLevel.Parsing
{
	public class SimpleTokenizer: ATokenizer
    {
		private string[] m_Separators;

		public SimpleTokenizer(string escapeSeparator, params string[] separators): base(false, escapeSeparator)
		{
			bool hasEscape = !string.IsNullOrEmpty(escapeSeparator);
			int offset = (hasEscape? 1: 0);
			m_Separators = new string[separators.Length+offset];
			for(int x = 0; x < separators.Length; x++)
			{
				m_Separators[x] = separators[x];
			}
			if(hasEscape)
			{
				m_Separators[separators.Length] = escapeSeparator;
			}
		}

		protected override string[] GetDefaultSeparators()
		{
			return m_Separators;
		}
	}
}
