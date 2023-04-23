
using static HtmlRefactoringWindowsApp.Utils.StringUtils;

namespace HtmlRefactoringWindowsApp.Css
{
    public class CssFile
    {
        private const char rightBrace = '}';

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
            ExtractRules(file);
        }

            private void ExtractRules(string file)
            {
                var rulesArray= SplitStringWithSeparatorIncluded(file, rightBrace);

                foreach (var rule in rulesArray)
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
