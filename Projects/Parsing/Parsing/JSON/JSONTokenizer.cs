﻿namespace ProceduralLevel.Common.Parsing
{
	public class JSONTokenizer: ATokenizer
	{
		private static string[] m_Separators = new string[]
		{
			JsonConst.ARRAY_CLOSE, JsonConst.ARRAY_OPEN,
			JsonConst.BRACKETS_CLOSE, JsonConst.BRACKETS_OPEN,
			JsonConst.KEY_VALUE_SEPARATOR, JsonConst.SEPARATOR,
			JsonConst.QUOTATION, JsonConst.ESCAPE
		};

		private static string[] m_Quoted = new string[]
		{
			JsonConst.QUOTATION
		};

		private static string[] m_Value = new string[]
		{
			JsonConst.QUOTATION,
			JsonConst.SEPARATOR
		};

		public JSONTokenizer(): base(false, JsonConst.ESCAPE)
		{

		}

		protected override string[] GetDefaultSeparators()
		{
			return m_Separators;
		}

		protected override string[] GetSeparators(Token token)
		{
			switch(token.Value)
			{
				//case JsonConst.KEY_VALUE_SEPARATOR:
				//	return m_Value;
				//case JsonConst.QUOTATION:
				//	return m_Quoted;
				default:
					return m_Separators;
			}
		}
	}
}