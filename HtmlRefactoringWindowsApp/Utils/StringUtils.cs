
using System.Security.Cryptography.X509Certificates;

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
                if (!char.IsAsciiLetter(s[i]) && !IsHrAccentedLetter(s[i]) && (s[i] != ' '))
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
            return ((c == 'č') || (c == 'ć') || (c == 'đ') || (c == 'š') || (c == 'ž') || (c == 'Č') || (c == 'Ć') || (c == 'Đ') || (c == 'Š') || (c == 'Ž'));
        }

        public static bool IsHrUpperAccentedLetter(char c)
        {
            return ((c == 'Č') || (c == 'Ć') || (c == 'Đ') || (c == 'Š') || (c == 'Ž'));
        }

        public static bool IsNaturalNumberUpToMaxDigitsCount(string number, int maxDigitsCount)
        {
            if (maxDigitsCount < 1)
                throw new ArgumentOutOfRangeException($"Error! Argument '{maxDigitsCount}' must be integer greater than 0");
            
            bool result = true;

            if ((number.Length == 0) || (number[0] < '1') || (number[0] > '9') || (number.Length > maxDigitsCount))
                result = false;

            for (var i = 1; i < number.Length; i++)
            {
                if ((number[i] < '0') || (number[i] > '9'))
                { 
                    result = false; 
                    break;
                }
            }
            return result;
        }

        public static string[] SplitWithSeparatorIncluded(string str, char delimiter)
        {
            var subStrings = new List<string>();
            int firstIndex = 0;
            int lastIndex;

            while ((lastIndex = str.IndexOf(delimiter, firstIndex)) != -1)
            {
                subStrings.Add(str.Substring(firstIndex, lastIndex - firstIndex + 1));
                firstIndex = lastIndex + 1;
            }
            if (firstIndex < str.Length)
                subStrings.Add(str[firstIndex..]);

            return subStrings.ToArray();
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
