
using System.Text.RegularExpressions;

namespace HtmlRefactoringWindowsApp.Css

//  We are using simplified syntax for CSS selectors, validation rules covers all use cases that we face
{
    public class CssSelector
    {
        private const char idPrefix = '#';      //  in CSS selector, prefix for ID

        private const char classPrefix = '.';      //  in CSS selector, prefix for class

        public string Selector { get; }

        public string? Element { get; }

        public string? ID { get; }

        public string? Class { get; }

        public CssSelector(string selector)
        {
            Selector = InitSelector(selector.Trim());
            Element = InitElement(Selector);
            ID = InitID(Selector);
            Class = InitClass(Selector);
        }

            private static string InitSelector(string selector)
            {
                var reg = new Regex("^[\\.#a-zA-Z_-][0-9\\.a-zA-Z_-]*$");

                if (!reg.IsMatch(selector) || selector == classPrefix.ToString() || selector == idPrefix.ToString())
                    throw new InvalidSelectorException($"Error! Selector '{selector}' is invalid.");

                return selector;
            }

            private static string? InitElement(string selector)
            {
                if (selector[0] != classPrefix && selector[0] != idPrefix)
                    return ExtractElement(selector);
                else
                    return null;
            }

                private static string? ExtractElement(string selector)
                {
                    var indexDot = selector.IndexOf(classPrefix);

                    if (indexDot == -1)
                        return selector;
                    else
                        return selector[0..indexDot];
                }

            private static string? InitID(string selector)
            {
                if (selector[0] == idPrefix)
                    return (selector[1..]);
                else
                    return null;
            }

            private static string? InitClass(string selector)
            {
                var indexDot = selector.IndexOf(classPrefix);

                if (indexDot == -1)
                    return null;
                else
                    return selector[(indexDot + 1)..];
        }
    }

    public class InvalidSelectorException : Exception
    {
        public InvalidSelectorException(string message) : base(message) { }
    }
}
