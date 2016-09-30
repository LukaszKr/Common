using System;
using System.Collections.Generic;

namespace ProceduralLevel.Common.Parsing
{
    public class CSVParser
    {
        private Tokenizer m_Tokenizer;
        private string m_Separator;

        public CSVParser(string separator = CSVConst.COLUMN_SEPARATOR)
        {
            m_Tokenizer = new Tokenizer();
            m_Tokenizer.AddSeparators(CSVConst.QUOTATION, CSVConst.NEW_LINE, separator);
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

        public CSV Parse(string str)
        {
            m_Tokenizer.Tokenize(str);

            List<Token> tokens = m_Tokenizer.Flush();
            return Parse(tokens);
        }

        public CSV Parse(List<Token> tokens)
        {
            ParseState parseState = ParseState.ValueStart;
            CSV csv = new CSV(m_Separator);
            string value = "";
            List<string> values = new List<string>();

            for(int x = 0; x < tokens.Count; x++)
            {
                Token token = tokens[x];
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
                            else if(token.Value == m_Separator)
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
                            if(token.Value == m_Separator)
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
                            if(token.Value != m_Separator && parseState == ParseState.CloseQuote)
                            {
                                throw new Exception(string.Format("Expected seperator: {0} but found {1}",
                                    m_Separator, token.Value));
                            }
                        }
                        else
                        {
                            throw new Exception(string.Format("Expected seperator: {0} but found {1}",
                                m_Separator, token.Value));
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
            CSVRow row = new CSVRow(values);
            csv.Add(row);
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
