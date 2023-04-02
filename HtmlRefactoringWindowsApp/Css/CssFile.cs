
using System.Data;
using System.Text.RegularExpressions;
using static HtmlRefactoringWindowsApp.Utils.StringUtils;

namespace HtmlRefactoringWindowsApp.Css
{
    public class CssFile
    {
        public CssFile(string file)
        {
            PreliminaryValidation(file);

            var splitFile = SplitWithSeparatorIncluded(file, '}');
            CssRule cssRule;

            foreach (var rule in splitFile)
            {
                if (!string.IsNullOrWhiteSpace(rule))
                    cssRule = new CssRule(rule);
            }
        }

            private static void PreliminaryValidation(string file)
            {
                if (string.IsNullOrWhiteSpace(file))
                    throw new InvalidCssFileException("Error! CSS file is empty or white space.");
            }

        }

    public class InvalidCssFileException : Exception
    {
        public InvalidCssFileException(string message) : base(message) { }
    }
}
