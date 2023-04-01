
using System.Data;
using System.Text.RegularExpressions;

namespace HtmlRefactoringWindowsApp.Css
{
    public class CssFile
    {
        public CssFile(string file)
        {
            if (string.IsNullOrEmpty(file)) 
                throw new InvalidCssFileException("Error! CSS file is empty or white space.");

            var reg = new Regex("^.*\\}\\s*\\}.*$");

            if (reg.IsMatch(file))
                throw new InvalidBracesException("Error! Invalid right brace '}'");

            var splitFile = file.Split('}');
            var cssRule = new CssRule("x{x:o}");

            foreach (var rule in splitFile)
            {
                if (!string.IsNullOrEmpty(rule))
                    cssRule = new CssRule(rule + '}');
            }
        }
    }
    public class InvalidCssFileException : Exception
    {
        public InvalidCssFileException(string message) : base(message) { }
    }
}
