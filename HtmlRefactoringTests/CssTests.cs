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
            Throws<MissingColonException>(() => new CssProperty("x=0"));
        }

        [Fact]
        public void WhenInvalidPropertyName_Throws()
        {
            Throws<InvalidPropertyNameException>(() => new CssProperty(":"));
            Throws<InvalidPropertyNameException>(() => new CssProperty(" :"));
            Throws<InvalidPropertyNameException>(() => new CssProperty("0:"));
            Throws<InvalidPropertyNameException>(() => new CssProperty("9a:0"));
        }

        [Fact]
        public void WhenMissingPropertyValue_Throws()
        {
            Throws<MissingPropertyValueException>(() => new CssProperty("x:"));
            Throws<MissingPropertyValueException>(() => new CssProperty("x: "));
        }

        //[Fact]
        //public void AfterConstruction_CanReadPropertyName()
        //{
        //    var property = new CssProperty("x:");

        //Throws<InvalidPropertyNameException>(() => new CssProperty("w :"));

        //Equals 
        //}
    }
}
