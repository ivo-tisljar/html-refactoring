using HtmlRefactoringWindowsApp.Css;

namespace HtmlRefactoringTests
{
    public class CssMargin
    {
        private static string margin = "margin";

        public CssMargin(CssProperty cssProperty)
        {
            ValidateThatPropertyIsMargin(cssProperty);
        }

            private static void ValidateThatPropertyIsMargin(CssProperty cssProperty)
            {
                if ((cssProperty.Name.Length < margin.Length) || (cssProperty.Name[..margin.Length] != margin) || !ValidateMarginSufix(cssProperty.Name[margin.Length..]))
                    throw new InvalidMarginException($"Error! Property '{cssProperty.Name}:{cssProperty.Value}' does not define a margin.");
            }

                private static bool ValidateMarginSufix(string sufix)
                {
                    return (sufix == "") || (sufix == "-top") || (sufix == "-right") || (sufix == "-bottom") || (sufix == "-left");
                }
    }

    public class InvalidMarginException : Exception
    {
        public InvalidMarginException(string message) : base(message) { }
    }
}