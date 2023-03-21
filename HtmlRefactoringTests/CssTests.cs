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
        public void AfterCreatingCssPropertiesIfAnyOfIndividualPropertiesIsInvalid_Throws()
        {
            ThrowsAny<CssPropertyException>(() => new CssProperties("a"));
            ThrowsAny<CssPropertyException>(() => new CssProperties("2:"));
            ThrowsAny<CssPropertyException>(() => new CssProperties("c-3:"));
            ThrowsAny<CssPropertyException>(() => new CssProperties("c-3:0;x;"));
            ThrowsAny<CssPropertyException>(() => new CssProperties("c-3:0;x:a;z"));
            ThrowsAny<CssPropertyException>(() => new CssProperties("c-3:0;x;a:x"));
        }

        [Fact]
        public void AfterCreatingCssPropertiesWithOneProperty_CountOfPropertiesIsOne()
        {
            var cssProperties = new CssProperties("x:0");
            Equal(1, cssProperties.Count());
        }

        [Fact]
        public void AfterCreatingCssPropertiesWithTwoProperties_CountOfPropertiesIsTwo()
        {
            var cssProperties = new CssProperties("x:0;y:1");
            Equal(2, cssProperties.Count());
        }
    }
}
