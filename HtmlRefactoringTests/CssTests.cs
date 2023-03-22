using HtmlRefactoringWindowsApp.Css;
using static Xunit.Assert;

namespace HtmlRefactoringTests
{
    public class CssTests
    {
        #region CssPropertyTests
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
        #endregion

        #region CssPropertiesTests
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

        [Fact]
        public void AfterCreatingCssProperties_CanReadIndividualPropertyNamesAndValues()
        {
            var cssProperties = new CssProperties("x:0;y:1;z:2");
            Equal("x", cssProperties[0].Name);
            Equal("0", cssProperties[0].Value);
            Equal("y", cssProperties[1].Name);
            Equal("1", cssProperties[1].Value);
            Equal("z", cssProperties[2].Name);
            Equal("2", cssProperties[2].Value);
        }

        //  there can be already existing property

        [Fact]
        public void AfterCreatingCssProperties_CanReadRealWorldIndividualPropertyNamesAndValues()
        {
            var cssProperties = new CssProperties("border-collapse:collapse;\r\n\tborder-color\t:\t#000000;\r\n\tborder-style : solid;\r\n\tborder-width:1px;\r\n\t" + 
                                                  "margin-bottom:-4px;\r\n\tmargin-top:4px;");
            Equal("border-collapse", cssProperties[0].Name);
            Equal("collapse",        cssProperties[0].Value);
            Equal("border-color",    cssProperties[1].Name);
            Equal("#000000",          cssProperties[1].Value);
            Equal("border-style",    cssProperties[2].Name);
            Equal("solid",           cssProperties[2].Value);
            Equal("border-width",    cssProperties[3].Name);
            Equal("1px",             cssProperties[3].Value);
            Equal("margin-bottom",   cssProperties[4].Name);
            Equal("-4px",            cssProperties[4].Value);
            Equal("margin-top",      cssProperties[5].Name);
            Equal("4px",             cssProperties[5].Value);
        }
        #endregion

        #region CssRuleTests
        [Fact]
        public void WhenCssRuleHasInvalidBraces_Throws ()
        {
            Throws<InvalidBracesException>(() => new CssRule("x x:0"));
            Throws<InvalidBracesException>(() => new CssRule("x{x:0"));
            Throws<InvalidBracesException>(() => new CssRule("x x:0}"));
            Throws<InvalidBracesException>(() => new CssRule("x}x:0{"));
        }
        #endregion
    }
}
