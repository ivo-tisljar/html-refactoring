
using System.Data;
using System.Text.RegularExpressions;
using static HtmlRefactoringWindowsApp.Utils.StringUtils;

namespace HtmlRefactoringWindowsApp.Css
{
    public class CssFile
    {
        public List<CssRule> rules;

        public int Count
        {
            get { return rules.Count; }
        }

        public CssRule this[int index]
        {
            get { return rules[index]; }
        }

        public CssFile(string file)
        {
            rules = new List<CssRule>();
            //PreliminaryValidation(file);
            ExtractRules(file);
        }

            private static void PreliminaryValidation(string file)
                {
                    if (string.IsNullOrWhiteSpace(file))
                        throw new InvalidCssFileException("Error! CSS file is empty or white space.");
                }

            private void ExtractRules(string file)
            {
                var splitFile = SplitWithSeparatorIncluded(file, '}');

                foreach (var rule in splitFile)
                {
                    if (!string.IsNullOrWhiteSpace(rule))
                        rules.Add(new CssRule(rule));
                }
            }
    }

    public class InvalidCssFileException : Exception
    {
        public InvalidCssFileException(string message) : base(message) { }
    }
}
