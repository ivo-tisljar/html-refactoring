
using System.Data;
using System.Text.RegularExpressions;

namespace HtmlRefactoringWindowsApp.Css
{
    public class CssFile
    {
        public CssFile(string file)
        {
            PreliminaryValidation(file);

            var splitFile = file.Replace("}", "}}").Split('}');
            var cssRule = new CssRule("x{x:o}");

            foreach (var rule in splitFile)
            {
                if (!string.IsNullOrEmpty(rule))
                    cssRule = new CssRule(rule);
            }
        }

            private static void PreliminaryValidation(string file)
            {
                if (string.IsNullOrEmpty(file))
                    throw new InvalidCssFileException("Error! CSS file is empty or white space.");

                var reg = new Regex("^.*\\}\\s*\\}.*$");

                if (reg.IsMatch(file))
                    throw new InvalidBracesException("Error! Invalid right brace '}'");
            }

        }

    public class InvalidCssFileException : Exception
    {
        public InvalidCssFileException(string message) : base(message) { }
    }
}
