namespace ProceduralLevel.Tokenize
{
	public class SimpleTokenizer: ATokenizer
    {
		private char[] m_Separators;

		public SimpleTokenizer(char escapeSeparator, params char[] separators): base(false, escapeSeparator)
		{
			bool hasEscape = (escapeSeparator != default(char));
			int offset = (hasEscape? 1: 0);
			m_Separators = new char[separators.Length+offset];
			for(int x = 0; x < separators.Length; x++)
			{
				m_Separators[x] = separators[x];
			}
			if(hasEscape)
			{
				m_Separators[separators.Length] = escapeSeparator;
			}
		}

		protected override char[] GetDefaultSeparators()
		{
			return m_Separators;
		}
	}
}
