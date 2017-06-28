using System;
using System.Collections.Generic;

namespace ProceduralLevel.Common.Parsing
{
    public class CSVParser: AParser<CSV>
    {
        private char m_Separator;
		private bool m_HasHeader;

		public CSVParser(char separator = CSVConst.COLUMN_SEPARATOR)
			:base(new CSVTokenizer(separator.ToString()))
        {
            m_Separator = separator;
        }

        private enum ParseState
        {
            ValueStart,
            Value,
            QuotedValue,
            OpenQuote,
            CloseQuote
        }

		protected override void Reset()
		{
			base.Reset();

			m_HasHeader = false;
		}

		protected override CSV Parse()
        {
            ParseState parseState = ParseState.ValueStart;
            CSV csv = new CSV(m_Separator);
            string value = "";
            List<string> values = new List<string>();

            while(HasTokens())
            {
                Token token = ConsumeToken();
                switch(parseState)
                {
                    case ParseState.ValueStart:
                        value = "";
                        if(token.IsSeparator)
                        {
                            if(token.Value == CSVConst.QUOTATION)
                            {
                                parseState = ParseState.OpenQuote;
                            }
                            else if(token.Value[0] == m_Separator)
                            {
                                parseState = ParseState.CloseQuote;
                                goto case ParseState.CloseQuote;
                            }
                            else if(token.Value == CSVConst.NEW_LINE)
                            {
                                parseState = ParseState.Value;
                                goto case ParseState.Value;
                            }
                        }
                        else
                        {
                            parseState = ParseState.Value;
                            goto case ParseState.Value;
                        }
                        break;
                    case ParseState.Value:
                        if(token.IsSeparator)
                        {
                            if(token.Value[0] == m_Separator)
                            {
                                values.Add(value.Trim());
                                parseState = ParseState.ValueStart;
                            }
                            else if(token.Value == CSVConst.NEW_LINE)
                            {
                                values.Add(value.Trim());
                                AddEntry(csv, values);
                                parseState = ParseState.ValueStart;
                            }
                            else if(token.Value == CSVConst.QUOTATION)
                            {
                                parseState = ParseState.OpenQuote;
                            }
                            else
                            {
                                throw new Exception(string.Format("Found unexpected separator: {0} while parsing value.", 
                                    token.Value));
                            }
                        }
                        else
                        {
                            value += token.Value;
                        }
                        break;
                    case ParseState.QuotedValue:
                        if(token.IsSeparator && token.Value == CSVConst.QUOTATION)
                        {
                            parseState = ParseState.CloseQuote;
                        }
                        else
                        {
                            value += token.Value;
                        }
                        break;
                    case ParseState.OpenQuote:
                        if(token.IsSeparator && token.Value == CSVConst.QUOTATION)
                        {
                            parseState = ParseState.Value;
                        }
                        else
                        {
                            parseState = ParseState.QuotedValue;
                        }
                        value += token.Value;
                        break;
                    case ParseState.CloseQuote:
                        if(token.IsSeparator)
                        {
                            if(token.Value == CSVConst.QUOTATION)
                            {
                                parseState = ParseState.Value;
                                value += token.Value;
                            }
                            else if(token.Value == CSVConst.NEW_LINE)
                            {
                                values.Add(value.Trim());
                                AddEntry(csv, values);
                                parseState = ParseState.ValueStart;
                            }
                            else
                            {
                                values.Add(value.Trim());
                                parseState = ParseState.ValueStart;
                            }
                            if(token.Value[0] != m_Separator && parseState == ParseState.CloseQuote)
                            {
                                throw new Exception(string.Format("Expected seperator: {0} but found {1}",
                                    m_Separator, token.Value));
                            }
                        }
                        break;
                }
            }
            if(!string.IsNullOrEmpty(value) && parseState != ParseState.ValueStart)
            {
                values.Add(value);
            }
            if(values.Count > 0)
            {
                AddEntry(csv, values);
            }

            return csv;
        }

        private void AddEntry(CSV csv, List<string> values)
        {
			if(m_HasHeader)
			{
				CSVRow row = new CSVRow(values);
				csv.Add(row);
			}
			else
			{
				m_HasHeader = true;
				csv.AddHeaders(values.ToArray());
			}
			values.Clear();
        }

        private CSVRow ParseRow(CSVRow row = null)
        {
            if(row == null)
            {
                row = new CSVRow(1);
            }
            return row;
        }
    }
}
