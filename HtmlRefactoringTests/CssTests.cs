using HtmlRefactoringWindowsApp;
using static Xunit.Assert;
using HtmlRefactoringWindowsApp.Css;

namespace HtmlRefactoringTests
{
    public class CssTests
    {
        [Fact]
        public void WhenMissingColon_Throws()
        {
            Throws<MissingColonException>(() => new CssProperty(""));
            Throws<MissingColonException>(() => new CssProperty("x"));
        }

        [Fact]
        public void WhenMissingPropertyName_Throws()
        {
            Throws<MissingPropertyNameException>(() => new CssProperty(":"));
        }

        [Fact]
        public void WhenMissingPropertyValue_Throws()
        {
            Throws<MissingPropertyValueException>(() => new CssProperty("x:"));
        }
    }
}
