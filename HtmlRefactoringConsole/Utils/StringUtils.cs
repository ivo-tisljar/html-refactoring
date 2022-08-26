using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlRefactoringConsole.Utils
{
    public class StringUtils
    {
        public static string ValidateNotWhiteSpace(string paramValue, string paramName)
        {
            if (string.IsNullOrWhiteSpace(paramValue))
            {
                throw new ArgumentOutOfRangeException($"Invalid value! {paramName} is empty or contains only white-space character.");
            }
            return paramValue;
        }

        public static string StripTitlesFromName(string nameWithTitles)
        {
            string[] titles = { "prof", "izv", "doc", "dr", "mr", "sc", "dipl", "mag", "oec", "iur", "univ", "bacc", "ll m", "acca", "inž", "građ",
                                "dip", "oecc", "eoc",
                                "ovl", "rač", "rev", "por", "for", "savj", "struč", "spec", "pred", "i", "v", "š", "soc", "rad", "pravna", "savjetnica", "vis", "šk",
                                "glavni", "urednik", "glavna", "urednica", "zamjenik", "glavne", "urednice", "gl", "ur", "časopisa",
                                "priredio", "priredila", "pripremio", "pripremila",
                                "stalni", "sudski", "tumač", "za", "njemački", "jezik", "sutkinja", "općinskoga", "građanskog", "suda", "u", "zagrebu"};

            nameWithTitles = " " + nameWithTitles.Replace(".", " ").Replace(",", " ").Replace(":", " ").Replace("*", " ").Replace("  ", " ") + " ";

            for (int i = 0; i < titles.Length; i++)
            {
                nameWithTitles = nameWithTitles.Replace(" " + titles[i] + " ", " ", StringComparison.InvariantCultureIgnoreCase);
            }

            return nameWithTitles.Replace("  ", " ").Replace("  ", " ").Trim();
        }
    }
}
