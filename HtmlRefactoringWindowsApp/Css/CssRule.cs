
namespace HtmlRefactoringWindowsApp.Css
{
    public class CssRule
    {
        public CssRule(string rule)
        {
            var leftBraceIndex = rule.IndexOf('{');
            var rightBraceIndex = rule.IndexOf('}');

            if (((leftBraceIndex == -1) || (rightBraceIndex == -1)) || (leftBraceIndex > rightBraceIndex))
                throw new InvalidBracesException($"Error! Rule '{rule}' does not contain left & right braces '{{' & '}}' in the proper order.");
        }
    }

    public class InvalidBracesException : Exception
    {
        public InvalidBracesException(string message) : base(message) {}
    }

}
