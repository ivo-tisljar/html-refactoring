
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
            Equal(0, cssProperties.Count);
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
            Equal(1, cssProperties.Count);
        }

        [Fact]
        public void AfterCreatingCssPropertiesWithTwoProperties_CountOfPropertiesIsTwo()
        {
            var cssProperties = new CssProperties("x:0;y:1");
            Equal(2, cssProperties.Count);
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

            Equal(3,   cssProperties.Count);
        }

        [Fact]
        public void AfterCreatingCssProperties_CanReadRealWorldIndividualPropertyNamesAndValues()
        {
            var cssProperties = new CssProperties("border-collapse:collapse;\r\n\tborder-color\t:\t#000000;\r\n\tborder-style : solid;\r\n\t" +
                                                  "border-width:1px;\r\n\tmargin-bottom:-4px;\r\n\tmargin-top:4px;\r\n\t" +
                                                  "font-family:\"Myriad Pro\", sans-serif;");

            Equal("border-collapse", cssProperties[0].Name);
            Equal("collapse", cssProperties[0].Value);

            Equal("border-color", cssProperties[1].Name);
            Equal("#000000", cssProperties[1].Value);

            Equal("border-style", cssProperties[2].Name);
            Equal("solid", cssProperties[2].Value);

            Equal("border-width", cssProperties[3].Name);
            Equal("1px", cssProperties[3].Value);

            Equal("margin-bottom", cssProperties[4].Name);
            Equal("-4px", cssProperties[4].Value);

            Equal("margin-top", cssProperties[5].Name);
            Equal("4px", cssProperties[5].Value);

            Equal("font-family", cssProperties[6].Name);
            Equal("\"Myriad Pro\", sans-serif", cssProperties[6].Value);

            Equal(7, cssProperties.Count);
        }

        #endregion

        #region CssSelectorTests

        [Fact]
        public void WhenInvalidSelector_Throws()
        {
            Throws<InvalidSelectorException>(() => new CssSelector(""));
            Throws<InvalidSelectorException>(() => new CssSelector("0"));
            Throws<InvalidSelectorException>(() => new CssSelector("."));
            Throws<InvalidSelectorException>(() => new CssSelector("#"));
            Throws<InvalidSelectorException>(() => new CssSelector("x#"));
            Throws<InvalidSelectorException>(() => new CssSelector("šč"));
        }

        [Fact]
        public void AfterConstruction_CanReadSelector()
        {
            Equal("x", new CssSelector("x ").Selector);
            Equal("#x", new CssSelector("#x").Selector);
            Equal(".x", new CssSelector(" .x").Selector);
            Equal("x.y", new CssSelector("x.y").Selector);
        }

        [Fact]
        public void AfterConstruction_CanReadElement()
        {
            Null(new CssSelector("#x").Element);
            Null(new CssSelector(".x").Element);
            Equal("x", new CssSelector("x").Element);
            Equal("x", new CssSelector("x.y").Element);
        }

        [Fact]
        public void AfterConstruction_CanReadID()
        {
            Null (new CssSelector("x").ID);
            Null (new CssSelector(".x").ID);
            Null (new CssSelector("x.y").ID);
            Equal("x", new CssSelector("#x").ID);
        }

        [Fact]
        public void AfterConstruction_CanReadClass()
        {
            Null(new CssSelector("x").Class);
            Null(new CssSelector("#x").Class);
            Equal("x", new CssSelector(".x").Class);
            Equal("y", new CssSelector("x.y").Class);
        }

        #endregion

        #region CssSelectorsTests

        [Fact]
        public void AfterCreatingCssSelectors_CountOfSelectorsIsZero()
        {
            var cssSelectors = new CssSelectors("");
            Equal(0, cssSelectors.Count);
        }

        [Fact]
        public void AfterCreatingCssSelectors_IfCssSelectorIsInvalidThrows()
        {
            Throws<InvalidSelectorException>(() => new CssSelectors("0"));
        }
        [Fact]
        public void AfterCreatingCssSelectorsWithOneSelector_CountOfSelectorsIsOne()
        {
            var cssSelectors = new CssSelectors("x");
            Equal(1, cssSelectors.Count);
        }

        [Fact]
        public void AfterCreatingCssSelectorsWithTwoSelectors_CountOfSelectorsIsTwo()
        {
            var cssSelectors = new CssSelectors("x, y");
            Equal(2, cssSelectors.Count);
        }

        [Fact]
        public void AfterCreatingCssSelectors_CanReadIndividualSelectorsAndTheirElementIDAndClass()
        {
            var cssSelectors = new CssSelectors("x, #x, .x, x.y");

            Equal("x", cssSelectors[0].Selector);
            Equal("x", cssSelectors[0].Element);
            Null(cssSelectors[0].ID);
            Null(cssSelectors[0].Class);

            Equal("#x", cssSelectors[1].Selector);
            Null(cssSelectors[1].Element);
            Equal("x", cssSelectors[1].ID);
            Null(cssSelectors[1].Class);

            Equal(".x", cssSelectors[2].Selector);
            Null(cssSelectors[2].Element);
            Null(cssSelectors[2].ID);
            Equal("x", cssSelectors[2].Class);

            Equal("x.y", cssSelectors[3].Selector);
            Equal("x", cssSelectors[3].Element);
            Null(cssSelectors[3].ID);
            Equal("y", cssSelectors[3].Class);

            Equal(4, cssSelectors.Count);
        }

        [Fact]
        public void AfterCreatingCssSelectors_CanReadRealWorldSelectorsAndTheirElementIDAndClass()
        {
            var cssSelectors = new CssSelectors(" table.No-Table-Style , .Bold-italic, #_idContainer001, body");

            Equal("table.No-Table-Style", cssSelectors[0].Selector);
            Equal("table", cssSelectors[0].Element);
            Null(cssSelectors[0].ID);
            Equal("No-Table-Style", cssSelectors[0].Class);

            Equal(".Bold-italic", cssSelectors[1].Selector);
            Null(cssSelectors[1].Element);
            Null(cssSelectors[1].ID);
            Equal("Bold-italic", cssSelectors[1].Class);

            Equal("#_idContainer001", cssSelectors[2].Selector);
            Null(cssSelectors[2].Element);
            Equal("_idContainer001", cssSelectors[2].ID);
            Null(cssSelectors[2].Class);

            Equal("body", cssSelectors[3].Selector);
            Equal("body", cssSelectors[3].Element);
            Null(cssSelectors[3].ID);
            Null(cssSelectors[3].Class);

            Equal(4, cssSelectors.Count);
        }

        #endregion

        #region CssRuleTests

        [Fact]
        public void WhenCssRuleHasInvalidBraces_Throws()
        {
            Throws<InvalidBracesException>(() => new CssRule("x x:0"));
            Throws<InvalidBracesException>(() => new CssRule("x{x:0"));
            Throws<InvalidBracesException>(() => new CssRule("x x:0}"));
            Throws<InvalidBracesException>(() => new CssRule("x}x:0{"));
        }

        [Fact]
        public void WhenCssRuleHasInvalidSelector_Throws()
        {
            Throws<InvalidSelectorException>(() => new CssRule("0{}"));
            Throws<InvalidSelectorException>(() => new CssRule("lišće{}"));
        }

        [Fact]
        public void WhenCssRuleHasInvalidProperty_Throws()
        {
            ThrowsAny<CssPropertyException>(() => new CssRule("x{0}"));
            ThrowsAny<CssPropertyException>(() => new CssRule("x,y{x:}"));
            ThrowsAny<CssPropertyException>(() => new CssRule(".x,y.y,z{:0}"));
            ThrowsAny<CssPropertyException>(() => new CssRule("#x{a:a;b;c:c}"));
        }

        #endregion

        #region CssFileTests

        [Fact]
        public void CanCreateCssTest()
        {
            var cssFile = new CssFile();
        }


        #endregion
    }
}
