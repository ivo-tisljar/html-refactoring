
namespace HtmlRefactoringWindowsApp.Css
{
    public class CssRule
    {
        private readonly CssSelectors cssSelectors;

        private readonly CssProperties cssProperties;

        public CssRule(string rule)
        {
            var leftBraceIndex = rule.IndexOf('{');
            var rightBraceIndex = rule.IndexOf('}');

            ValidateBraces(rule, leftBraceIndex, rightBraceIndex);

            cssSelectors = new CssSelectors(rule[0..leftBraceIndex]);
            cssProperties = new CssProperties(rule[(leftBraceIndex + 1)..rightBraceIndex]);
        }


        private static void ValidateBraces(string rule, int leftBraceIndex, int rightBraceIndex)
        {
            if ((leftBraceIndex == -1) || (rightBraceIndex == -1) || (leftBraceIndex > rightBraceIndex) ||
                (rule[(leftBraceIndex + 1)..rightBraceIndex].IndexOf('{') != -1))
            {
                throw new InvalidBracesException($"Error! Rule '{rule}' does not contain left & right braces '{{' & '}}' in the proper order.");
            }
        }
    }

    public class InvalidBracesException : Exception
    {
        public InvalidBracesException(string message) : base(message) { }
    }
}
