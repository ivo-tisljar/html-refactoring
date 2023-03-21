using HtmlRefactoringWindowsApp.Css;
using static Xunit.Assert;

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
            Throws<InvalidPropertyNameException>(() => new CssProperty("x y :0"));
        }

        [Fact]
        public void WhenMissingPropertyValue_Throws()
        {
            Throws<MissingPropertyValueException>(() => new CssProperty(" _x:"));
            Throws<MissingPropertyValueException>(() => new CssProperty("x-1: "));
        }

        [Fact]
        public void AfterConstruction_CanReadPropertyName()
        {
            Equal("_x", new CssProperty("_x :0").Name);
            Equal("x-y", new CssProperty(" x-y :0").Name);
            Equal("x2", new CssProperty("x2:0").Name);
        }

        [Fact]
        public void AfterConstruction_CanReadPropertyValue()
        {
            Equal("0", new CssProperty("x:0").Value);
            Equal("12 13", new CssProperty("x: 12 13 ").Value);
            Equal("čžš", new CssProperty("x:    čžš").Value);
        }

        //  properties can be empty
        //  there can be one property only
        //  there can be multiple properties separated by semicolon
        //  there can be new property
        //  there can be already existing property


        [Fact]
        public void CanCreateCssProperties()
        {
            var cssProperties = new CssProperties("");
        }

        [Fact]
        public void AfterCreatingCssProperties_CountOfPropertiesIsZero()
        {
            var cssProperties = new CssProperties("");
            Equal(0, cssProperties.Count());
        }

        [Fact]
        public void AfterCreatingWithOneInvalidProperty_Throws()
        {
            ThrowsAny<CssPropertyException>(() => new CssProperties("a"));
            ThrowsAny<CssPropertyException>(() => new CssProperty("2:"));
            ThrowsAny<CssPropertyException>(() => new CssProperty("c-3:"));
        }

        //[Fact]
        //public void AfterCreatingCssPropertiesWithOneProperty_CountOfPropertiesIsOne()
        //{
        //    var cssProperties = new CssProperties("x");
        //    Equal(1, cssProperties.Count());
        //}
    }
}
