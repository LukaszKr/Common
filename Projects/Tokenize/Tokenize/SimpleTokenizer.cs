namespace ProceduralLevel.Tokenize
{
	public class SimpleTokenizer: ATokenizer
    {
		private char[] m_Separators;

		public SimpleTokenizer(params char[] separators): base()
		{
			m_Separators = new char[separators.Length];
			for(int x = 0; x < separators.Length; x++)
			{
				m_Separators[x] = separators[x];
			}
		}

		protected override char[] GetSeparators()
		{
			return m_Separators;
		}
	}
}
