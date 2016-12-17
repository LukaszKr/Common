namespace ProceduralLevel.Common.Parsing
{
	public class SimpleTokenizer: Tokenizer
    {
		private string[] m_Separators;

		public SimpleTokenizer(params string[] separators)
		{
			m_Separators = new string[separators.Length];
			for(int x = 0; x < separators.Length; x++)
			{
				m_Separators[x] = separators[x];
			}
		}

		protected override string[] GetDefaultSeparators()
		{
			return m_Separators;
		}
	}
}
