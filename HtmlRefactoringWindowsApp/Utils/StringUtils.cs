
using System.IO;

namespace HtmlRefactoringWindowsApp.Utils
{
    public class StringUtils
    {
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

        public static string ValidateIsNotEmptyAndIsNotWhiteSpace(string paramValue, string paramName)
        {
            if (string.IsNullOrWhiteSpace(paramValue))
            {
                throw new ArgumentOutOfRangeException($"Invalid value! {paramName} is empty or contains only white-space character.");
            }
            return paramValue;
        }
    }
}
