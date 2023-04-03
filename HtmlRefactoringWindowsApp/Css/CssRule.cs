
namespace HtmlRefactoringWindowsApp.Css
{
    public class CssRule
    {
        public CssSelectors CssSelectors { get; }

        public CssProperties CssProperties { get; }

        public CssRule(string rule)
        {
            var leftBraceIndex = rule.IndexOf('{');
            var rightBraceIndex = rule.IndexOf('}');

            ValidateBraces(rule, leftBraceIndex, rightBraceIndex);

            CssSelectors = new CssSelectors(rule[0..leftBraceIndex]);
            CssProperties = new CssProperties(rule[(leftBraceIndex + 1)..rightBraceIndex]);
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
