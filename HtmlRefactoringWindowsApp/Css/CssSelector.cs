using System.Text.RegularExpressions;

namespace HtmlRefactoringWindowsApp.Css

//  We are using simplified syntax for CSS selectors, which covers all use cases that we face
{
    public class CssSelector
    {
        public string Selector { get; }

        public string? Element { get; }

        public CssSelector(string selector)
        {
            Selector = InitSelector(selector.Trim());
            Element = InitElement(Selector);
        }

        private string InitSelector(string selector)
        {
            var reg = new Regex("^[\\.#a-zA-Z_-][0-9\\.a-zA-Z_-]*$");

            if ((!reg.IsMatch(selector)) || (selector == ".") || (selector == "#"))
                throw new InvalidSelectorException($"Error! Selector '{selector}' is invalid.");

            return selector;
        }

        private string? InitElement(string selector)
        {
            if ((selector[..1] != ".") && (selector[..1] != "#"))
                return ExtractElement(selector);
            else
                return null;
        }

        private string? ExtractElement(string selector)
        {
            var indexDot = selector.IndexOf('.');

            if (indexDot == -1)
                return selector;
            else
                return selector[0..indexDot];
        }
    }

    public class InvalidSelectorException : Exception
    {
        public InvalidSelectorException(string message) : base(message) { }
    }
}
