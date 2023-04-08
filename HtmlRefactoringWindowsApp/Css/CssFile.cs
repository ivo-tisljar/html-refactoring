﻿
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
            ExtractRules(file);
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
