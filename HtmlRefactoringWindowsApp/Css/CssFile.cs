
using System.Data;

namespace HtmlRefactoringWindowsApp.Css
{
    public class CssFile
    {
        public CssFile(string file)
        {
            if (string.IsNullOrEmpty(file))
                throw new InvalidCssFileException("Error! CSS file is empty or white space.");

            var splitFile = file.Split('}');
            var cssRule = new CssRule("");

            foreach (var rule in splitFile)

                if (string.IsNullOrEmpty(rule))
                    cssRule = new CssRule(rule + '}');
        }
    }
    public class InvalidCssFileException : Exception
    {
        public InvalidCssFileException(string message) : base(message) { }
    }
}
