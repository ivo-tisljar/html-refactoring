using HtmlRefactoringWindowsApp.Css;

namespace HtmlRefactoringTests
{
    public class CssMargin
    {
        private static string margin = "margin";
        private static string marginTop = "margin-top";
        private static string marginRight = "margin-right";
        private static string marginBottom = "margin-bottom";
        private static string marginLeft = "margin-left";

        public CssMargin(CssProperty cssProperty)
        {
            ValidateThatPropertyIsMargin(cssProperty);
        }

            private static void ValidateThatPropertyIsMargin(CssProperty cssProperty)
            {
                if ((cssProperty.Name != margin) && (cssProperty.Name != marginTop) && (cssProperty.Name != marginRight) && (cssProperty.Name != marginBottom) && 
                    (cssProperty.Name != marginLeft))
                    throw new InvalidMarginException($"Error! Property '{cssProperty.Name}:{cssProperty.Value}' does not define a margin.");
            }
    }

    public class InvalidMarginException : Exception
    {
        public InvalidMarginException(string message) : base(message) { }
    }
}