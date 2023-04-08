
using System.Text.RegularExpressions;

namespace HtmlRefactoringWindowsApp.Css
{
    public class CssTypes
    {
        //  px, em and % are the only three units used in CSS files exported from InDesign

        public static bool IsValidCssLength(string cssLength)
        {
            var reg = new Regex("^(auto|-?\\d+(\\.\\d+)?(px|em|%)?)$");

            return reg.IsMatch(cssLength);
        }
    }
}
