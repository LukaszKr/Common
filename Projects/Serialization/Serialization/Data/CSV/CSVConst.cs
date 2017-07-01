using System.Text;

namespace ProceduralLevel.Serialization.CSV
{
	public static class CSVConst
    {
        public const char QUOTATION = '\"';
		public const char SEPARATOR = ',';
        public const char NEW_LINE = '\n';

		//CSV needs to escape quotation with another quotation
		public static string EscapeString(string escape)
		{
			StringBuilder sb = new StringBuilder(escape.Length);
			for(int x = 0; x < escape.Length; x++)
			{
				char chr = escape[x];
				if(chr == QUOTATION)
				{
					sb.Append(chr);
				}
				sb.Append(chr);
			}

			return sb.ToString();
		}

		public static string UnEscapeString(string unescape)
		{
			StringBuilder sb = new StringBuilder(unescape.Length);
			bool wasEscaped = false;
			for(int x = 0; x < unescape.Length; x++)
			{
				char chr = unescape[x];
				if(chr == QUOTATION)
				{
					if(!wasEscaped)
					{
						wasEscaped = true;
					}
					else
					{
						sb.Append(chr);
						wasEscaped = false;
					}
				}
				else
				{
					if(wasEscaped)
					{
						sb.Append(QUOTATION);
						wasEscaped = false;
					}
					sb.Append(chr);
				}
			}
			return sb.ToString();
		}
	}
}
