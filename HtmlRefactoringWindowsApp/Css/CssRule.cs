
namespace HtmlRefactoringWindowsApp.Css
{
    public class CssRule
    {
        private CssSelectors cssSelectors;

        private CssProperties cssProperties;

        public CssRule(string rule)
        {
            var leftBraceIndex = rule.IndexOf('{');
            var rightBraceIndex = rule.IndexOf('}');

            if (((leftBraceIndex == -1) || (rightBraceIndex == -1)) || (leftBraceIndex > rightBraceIndex))
                throw new InvalidBracesException($"Error! Rule '{rule}' does not contain left & right braces '{{' & '}}' in the proper order.");

            cssSelectors = new CssSelectors(rule[0..leftBraceIndex]);

            cssProperties = new CssProperties(rule[(leftBraceIndex + 1)..rightBraceIndex]);
        }
    }

    public class InvalidBracesException : Exception
    {
        public InvalidBracesException(string message) : base(message) {}
    }

}
