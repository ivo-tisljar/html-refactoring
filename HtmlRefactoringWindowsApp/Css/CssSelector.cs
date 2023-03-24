using System.Text.RegularExpressions;

namespace HtmlRefactoringWindowsApp.Css
{
    public class CssSelector
    {
        public string Selector { get; }

        public CssSelector(string selector)
        {
            Selector = InitSelector(selector.Trim());
        }

        private string InitSelector(string selector)
        {
            var reg = new Regex("^[\\.#a-zA-Z_-][0-9\\.a-zA-Z_-]*$");

            if ((!reg.IsMatch(selector)) || (selector == ".") || (selector == "#"))
                throw new InvalidSelectorException($"Error! Selector '{selector}' is invalid.");

            return selector;
        }
    }

    public class InvalidSelectorException : Exception
    {
        public InvalidSelectorException(string message) : base(message) { }
    }
}
