using System.Text;

namespace ProceduralLevel.Serialization
{
	public static class JsonConst
    {
		public const char ARRAY_OPEN = '[';
		public const char ARRAY_CLOSE = ']';
		public const char BRACES_OPEN = '{';
		public const char BRACES_CLOSE = '}';
		public const char ASSIGN = ':';
		public const char SEPARATOR = ',';
		public const char QUOTE = '\"';

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
