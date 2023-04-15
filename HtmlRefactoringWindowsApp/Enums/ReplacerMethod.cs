
using System.Xml.Linq;

namespace HtmlRefactoringWindowsApp.Enums
{
    public enum ReplacerMethod
    {
        Text = 0,
        Extended = 1,
        Regex =2
    }

    public static class StringExtensionsForreplacerMethodString
    {
        public static ReplacerMethod ToReplacerMethod(this string replacerMethodString)
        {
            return (ReplacerMethod)Enum.Parse(typeof(ReplacerMethod), replacerMethodString);
        }
    }
}
