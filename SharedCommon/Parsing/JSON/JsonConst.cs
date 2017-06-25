using System.Text;

namespace ProceduralLevel.Common.Parsing
{
	public static class JsonConst
    {
		public const string ARRAY_OPEN = "[";
		public const string ARRAY_CLOSE = "]";
		public const string BRACKETS_OPEN = "{";
		public const string BRACKETS_CLOSE = "}";
		public const string KEY_VALUE_SEPARATOR = ":";
		public const string SEPARATOR = ",";
		public const string QUOTATION = "\"";
		public const string ESCAPE = "\\";

		private static char[] m_ToEscape = new char[]
		{
			'"', '\\', '\b', '\f', '\n', '\r', '\t'
		};
		private static string[] m_Escaped = new string[]
		{
			"\\\"", "\\\\", "\\b", "\\f", "\\n", "\\r", "\\t"
		};

		public static string EscapeString(string str)
		{
			StringBuilder builder = new StringBuilder(str.Length);
			for(int x = 0; x < str.Length; x++)
			{
				bool escape = false;
				char c = str[x];
				for(int y = 0; y < m_ToEscape.Length; y++)
				{
					if(m_ToEscape[y] == c)
					{
						builder.Append(m_Escaped[y]);
						escape = true;
						break;
					}
				}
				if(!escape)
				{
					builder.Append(c);
				}
			}

			return builder.ToString();
		}

		public static string UnescapeString(string str)
		{
			StringBuilder builder = new StringBuilder(str.Length);
			for(int x = 0; x < str.Length; x++)
			{
				char c = str[x];
				if(c == '\\')
				{
					x ++;
				}
				else
				{
					builder.Append(c);
				}
			}
			return builder.ToString();
		}
	}
}
