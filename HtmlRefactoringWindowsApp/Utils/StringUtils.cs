
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace HtmlRefactoringWindowsApp.Utils
{
    public class StringUtils
    {
        public static int CountCharInString(char c, string s)
        {
            char[] test = s.ToCharArray();
            int count = 0;
            int length = test.Length;

            for (int i = length - 1; i >= 0; i--)
            {
                if (test[i] == c)
                    count++;
            }
            return count;
        }

        public static bool IsAsciiHrLettersOrSpace(string s)
        {
            bool result = true;

            for (int i = 0; i < s.Length; i++)
            {
                if (!char.IsAsciiLetter(s[i]) && !IsHrAccentedLetter(s[i]) && s[i] != ' ')
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        public static bool IsAsciiHrLetterUpper(char c)
        {
            return (char.IsAsciiLetterUpper(c) || IsHrUpperAccentedLetter(c));
        }

        public static bool IsAsciiLetters(string s)
        {
            bool result = true;

            for (int i = 0; i < s.Length; i++)
            {
                if (!char.IsAsciiLetter(s[i]))
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        public static bool IsHrAccentedLetter(char c)
        {
            return (c == 'č' || c == 'ć' || c == 'đ' || c == 'š' || c == 'ž' || c == 'Č' || c == 'Ć' || c == 'Đ' || c == 'Š' || c == 'Ž');
        }

        public static bool IsHrUpperAccentedLetter(char c)
        {
            return (c == 'Č' || c == 'Ć' || c == 'Đ' || c == 'Š' || c == 'Ž');
        }

        public static bool IsNaturalNumberUpToMaxDigitsCount(string number, int maxDigitsCount)
        {
            if (maxDigitsCount < 1)
                throw new ArgumentOutOfRangeException($"Error! Argument '{maxDigitsCount}' must be integer greater than 0");
            
            bool result = true;

            if (number.Length == 0 || number[0] < '1' || number[0] > '9' || number.Length > maxDigitsCount)
                result = false;

            for (var i = 1; i < number.Length; i++)
            {
                if (number[i] < '0' || number[i] > '9')
                { 
                    result = false; 
                    break;
                }
            }
            return result;
        }

        public static string[] SplitStringWithSeparatorIncluded(string csvString, char delimiter)
        {
            var result = new List<string>();
            int firstIndex = 0;
            int lastIndex;

            while ((lastIndex = csvString.IndexOf(delimiter, firstIndex)) != -1)
            {
                result.Add(csvString[firstIndex..(lastIndex + 1)]);
                firstIndex = lastIndex + 1;
            }
            if (firstIndex < csvString.Length)
                result.Add(csvString[firstIndex..]);

            return result.ToArray();
        }

        public static string[] SplitString(string csvString, char delimiter, char quote)
        {
            var result = new List<string>();
            int firstIndex = 0;
            int lastIndex;
            bool inQuotes = false;

            for (int i = 0; i < csvString.Length; i++)
            {
                char c = csvString[i];

                //if (c == quote)
                //{
                //    if (inQuotes && i < csvString.Length - 1 && csvString[i + 1] == quote)
                //        i++;
                //    else
                //        inQuotes = !inQuotes;
                //}
                //else if (c == delimiter && !inQuotes)
                //{
                //    result.Add(fieldBuilder.ToString());
                //    fieldBuilder.Clear();
                //}
                //else
                //    fieldBuilder.Append(c);

            }
            //while ((lastIndex = str.IndexOf(delimiter, firstIndex)) != -1)
            //{
            //    subStrings.Add(str.Substring(firstIndex, lastIndex - firstIndex + 1));
            //    firstIndex = lastIndex + 1;
            //}
            //if (firstIndex < str.Length)
            //    subStrings.Add(str[firstIndex..]);

            return result.ToArray();
        }

        public string[] ParseCsv(string csvString, char delimiter, char quote)
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

        public string[] ParseCsv2(string csvString, char delimiter, char quote)
        {
            List<string> result = new List<string>();
            StringBuilder fieldBuilder = new StringBuilder();

            for (int i = 0; i < csvString.Length; i++)
            {
                char c = csvString[i];

                if (IsQuote(c))
                    HandleQuote(ref i, csvString, quote, fieldBuilder);

                else if (IsDelimiter(c, quote))
                    HandleDelimiter(ref i, csvString, delimiter, fieldBuilder, result);

                else
                    fieldBuilder.Append(c);
            }

            result.Add(fieldBuilder.ToString());

            return result.ToArray();

                bool IsQuote(char c)
                {
                    return c == quote;
                }

                void HandleQuote(ref int i, string csvString, char quote, StringBuilder fieldBuilder)
                {
                    bool inQuotes = true;

                    if (i < csvString.Length - 1 && csvString[i + 1] == quote)
                    {
                        fieldBuilder.Append(quote);
                        i++; // skip the next quote
                    }
                    else
                        inQuotes = false;

                    inQuotes = !inQuotes;
                }

                bool IsDelimiter(char c, char quote)
                {
                    return c == quote || c == ',';
                }

                void HandleDelimiter(ref int i, string csvString, char delimiter, StringBuilder fieldBuilder, List<string> result)
                {
                    if (fieldBuilder.Length > 0 && !IsQuote(fieldBuilder[0]))
                    {
                        result.Add(fieldBuilder.ToString());
                        fieldBuilder.Clear();
                    }
                    else
                    {
                        fieldBuilder.Append(delimiter);
                        i++; // skip the delimiter
                    }
                }
        }

        // to-do: keep titles in configuration file and enable crud operations on them
        public static string StripTitlesFromName(string nameWithTitles)
        {
            string[] titles = { "acca", "bacc", "časopisa", "dip", "dipl", "doc", "dr", "eoc", "for", "gl", "glavna", "glavne", "glavni", "građ", "građanskog", "i", "inž", "iur", "izv",
                                "jezik", "ll m", "mag", "mr", "njemački", "oec", "oecc", "općinskoga", "ovl", "por", "pravna", "pred", "pripremila", "pripremio", "priredila", "priredio",
                                "prof", "rad", "rač", "rev", "sav", "savj", "savjetnica", "sc", "soc", "spec", "stalni", "struč", "suda", "sudski", "sutkinja", "stud", "š", "šk", "tumač",
                                "u", "univ", "ur", "urednica", "urednice", "urednik", "v", "vis", "za", "zagrebu", "zamjenik" };

            nameWithTitles = " " + nameWithTitles.Replace(".", " ").Replace(",", " ").Replace(":", " ").Replace("*", " ").Replace("  ", " ") + " ";

            for (int i = 0; i < titles.Length; i++)
            {
                nameWithTitles = nameWithTitles.Replace(" " + titles[i] + " ", " ", StringComparison.InvariantCultureIgnoreCase);
            }

            return nameWithTitles.Replace("  ", " ").Replace("  ", " ").Trim();
        }

        public static string ValidateIsNotEmptyNorWhiteSpace(string paramValue, string paramName)
        {
            if (string.IsNullOrWhiteSpace(paramValue))
            {
                throw new ArgumentOutOfRangeException($"Invalid value! {paramName} is empty or contains only white-space character.");
            }
            return paramValue;
        }
    }
}
