
using System.Text;

namespace HtmlRefactoringWindowsApp.Temp
{
    public class Utils
    {

        public static string QuoteString(string str, char quote)
        {
            return quote + str.Replace(quote.ToString(), string.Concat(quote, quote)) + quote;
        }

        public static string[] SplitString1(string csvString, char delimiter, char quote)
        {
            var result = new List<string>();
            int firstIndex = 0;
            bool inQuotes = false;
            string doubleQuote = string.Concat(quote, quote);

            for (int i = 0; i < csvString.Length; i++)
            {
                char c = csvString[i];

                if (c == quote)
                {
                    if (inQuotes && i < csvString.Length - 1 && csvString[i + 1] == quote)
                        i++;
                    else
                        inQuotes = !inQuotes;
                }
                else if (c == delimiter && !inQuotes)
                {
                    result.Add(UnquoteString(csvString[firstIndex..i], quote));
                    firstIndex = i + 1;
                }
            }
            result.Add(UnquoteString(csvString[firstIndex..], quote));

            return result.ToArray();
        }

        public static string[] SplitString2(string csvString, char delimiter, char quote)
        {
            var result = new List<string>();
            var inQuotes = false;
            StringBuilder fieldBuilder = new StringBuilder();

            for (int i = 0; i < csvString.Length; i++)
            {
                char c = csvString[i];

                if (c == quote)
                {
                    if (inQuotes && i < csvString.Length - 1 && csvString[i + 1] == quote)
                    {
                        fieldBuilder.Append(c);
                        i++;
                    }
                    else
                        inQuotes = !inQuotes;
                }
                else if (c == delimiter && !inQuotes)
                {
                    result.Add(fieldBuilder.ToString());
                    fieldBuilder.Clear();
                }
                else
                    fieldBuilder.Append(c);
            }
            result.Add(fieldBuilder.ToString());

            return result.ToArray();
        }

        public static string UnquoteString(string str, char quote)
        {
            var isUnquotable = (str.Length > 1 && str[0] == quote && str[str.Length - 1] == quote);

            for (int i = 1; isUnquotable && i < str.Length - 2; i++)        //  skip first and last chars == quote
            {
                if (str[i] == quote)
                {
                    if (i < str.Length - 3 && str[i + 1] == quote)
                        i++;
                    else
                        isUnquotable = false;
                }
            }
            var commentQuote = (quote == '\'') ? '"' : '\'';

            if (!isUnquotable)
                throw new InvalidStringException($"Error! String {commentQuote}{str}{commentQuote} " +
                                                 $"is NOT unqotable with char {commentQuote}{quote}{commentQuote} acting as a quote");

            return str[1..(str.Length - 2)].Replace(string.Concat(quote, quote), quote.ToString());
        }

        public static string UnquoteString2(string str, char quote)
        {
            if (str.Length <= 1 || str[0] != quote || str[str.Length - 1] != quote)
                ThrowException();

            for (int i = 1; i < str.Length - 2; i++)        //  skip first and last chars == quote
                {
                    if (str[i] == quote)
                    {
                        if (i < str.Length - 3 && str[i + 1] == quote)
                            i++;
                        else
                            ThrowException();
                    }
                }
            return str[1..(str.Length - 2)].Replace(string.Concat(quote, quote), quote.ToString());

            void ThrowException()
            {
                var commentQuote = (quote == '\'') ? '"' : '\'';

                throw new InvalidStringException($"Error! String {commentQuote}{str}{commentQuote} " +
                                                 $"is NOT unqotable with char {commentQuote}{quote}{commentQuote} acting as a quote");
            }
        }
    }

    public class InvalidStringException : Exception
    {
        public InvalidStringException(string message) : base(message) { }
    }
}
