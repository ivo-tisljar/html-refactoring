using System.Text.RegularExpressions;

namespace HtmlRefactoringWindowsApp.Css
{
    public class CssSelector
    {
        public CssSelector(string selector)
        {
            ValidateSelector(selector);
        }

        private void ValidateSelector(string selector)
        {
            var reg = new Regex("^[\\.#a-zA-Z_-][0-9\\.a-zA-Z_-]*$");

            if ((!reg.IsMatch(selector)) || (selector == ".") || (selector == "#"))
                throw new InvalidSelectorException($"Error! Selector '{selector}' is invalid.");
        }
    }

    public class InvalidSelectorException : Exception
    {
        public InvalidSelectorException(string message) : base(message) { }
    }
}
