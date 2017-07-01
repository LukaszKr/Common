using ProceduralLevel.Tokenize;

namespace ProceduralLevel.Serialization.Json
{
	public class JsonTokenizer: ATokenizer
	{
		private static readonly char[] m_AllSeparators = new char[]
		{
			JsonConst.ARRAY_CLOSE, JsonConst.ARRAY_OPEN,
			JsonConst.BRACES_CLOSE, JsonConst.BRACES_OPEN,
			JsonConst.ASSIGN, JsonConst.QUOTE, JsonConst.SEPARATOR
		};

		private static readonly char[] m_Quoted = new char[]
		{
			JsonConst.QUOTE
		};

		private bool m_IsQuoted = false;

		public JsonTokenizer(bool autoTrim = false) : base(autoTrim)
		{
		}

		protected override void Clear()
		{
			base.Clear();

			m_IsQuoted = false;
		}

		protected override char[] GetSeparators()
		{
			return m_AllSeparators;
		}

		protected override char[] GetSeparators(Token token)
		{
			switch(token.Value[0])
			{
				case JsonConst.QUOTE:
					m_IsQuoted = !m_IsQuoted;
					if(m_IsQuoted)
					{
						return m_Quoted;
					}
					return m_AllSeparators;
				default:
					return GetSeparators();
			}
		}
	}
}
