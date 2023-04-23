
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
            Throws<MissingPropertyValueException>(() => new CssProperty("-x:"));
            Throws<MissingPropertyValueException>(() => new CssProperty(" _x:"));
            Throws<MissingPropertyValueException>(() => new CssProperty("x-1: "));
        }

        [Fact]
        public void AfterCreatingCssPropery_CanReadPropertyName()
        {
            Equal("_x", new CssProperty("_x :0").Name);
            Equal("x-y", new CssProperty(" x-y :0").Name);
            Equal("x2", new CssProperty("x2:0").Name);
        }

        [Fact]
        public void AfterCreatingCssProperty_CanReadPropertyValue()
        {
            Equal("0", new CssProperty("x:0").Value);
            Equal("12 13", new CssProperty("x: 12 13 ").Value);
            Equal("čžš", new CssProperty("x:    čžš\r\n").Value);
        }

        #endregion

        #region CssPropertiesTests

        [Fact]
        public void AfterCreatingCssProperties_CountOfProperties_IsZero()
        {
            Equal(0, new CssProperties("").Count);
        }

        [Fact]
        public void WhenCreatingCssProperties_IfAnyOfIndividualPropertiesIsInvalid_Throws()
        {
            ThrowsAny<CssPropertyException>(() => new CssProperties("a"));
            ThrowsAny<CssPropertyException>(() => new CssProperties("2:"));
            ThrowsAny<CssPropertyException>(() => new CssProperties("c-3:"));
            ThrowsAny<CssPropertyException>(() => new CssProperties("c-3:0;x;"));
            ThrowsAny<CssPropertyException>(() => new CssProperties("c-3:0;x:a;z"));
            ThrowsAny<CssPropertyException>(() => new CssProperties("c-3:0;x;a:x"));
        }

        [Fact]
        public void AfterCreatingCssProperties_WithOneProperty_CountOfPropertiesIsOne()
        {
            Equal(1, new CssProperties("x:0").Count);
        }

        [Fact]
        public void AfterCreatingCssProperties_WithTwoProperties_CountOfPropertiesIsTwo()
        {
            Equal(2, new CssProperties("x:0;y:1").Count);
        }

        [Fact]
        public void AfterCreatingCssProperties_CanIndex_IndividualProperties()
        {
            Equal("2", new CssProperties("X:0;y:1;Z:2")[2].Value);
        }

        [Fact]
        public void AfterCreatingCssProperties_CanRead_IndividualPropertyNamesAndValues()
        {
            var cssProperties = new CssProperties("X:0;y:1;Z:2");

            Equal("x", cssProperties[0].Name);
            Equal("0", cssProperties[0].Value);

            Equal("y", cssProperties[1].Name);
            Equal("1", cssProperties[1].Value);

            Equal("z", cssProperties[2].Name);
            Equal("2", cssProperties[2].Value);

            Equal(3, cssProperties.Count);
        }

        [Fact]
        public void AfterCreatingCssProperties_CanRead_RealWorldIndividualPropertyNamesAndValues()
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

        [Fact]
        public void AfterCreatingCssProperties_CanAssignAndRead_IndividualCssProperty()
        {
            var cssProperty = new CssProperties("X:0;y:1;Z:2")[2];

            Equal("z", cssProperty.Name);
            Equal("2", cssProperty.Value);
        }

        [Fact]
        public void AfterCreatingCssProperties_IfIndexOfPropertiesIsOutOfRange_Throws()
        {
            var cssProperties = new CssProperties("a:0; b:1; c:2");

            Throws<ArgumentOutOfRangeException>(() => cssProperties[-1].Name);
            Throws<ArgumentOutOfRangeException>(() => cssProperties[3].Value);
        }

        #endregion

        #region CssSelectorTests

        [Fact]
        public void WhenCreatingCssSelector_IfInvalid_Throws()
        {
            Throws<InvalidSelectorException>(() => new CssSelector(""));
            Throws<InvalidSelectorException>(() => new CssSelector("0"));
            Throws<InvalidSelectorException>(() => new CssSelector("."));
            Throws<InvalidSelectorException>(() => new CssSelector("#"));
            Throws<InvalidSelectorException>(() => new CssSelector("x#"));
            Throws<InvalidSelectorException>(() => new CssSelector("x y"));
            Throws<InvalidSelectorException>(() => new CssSelector("šč"));
        }

        [Fact]
        public void AfterCreatingCssSelector_CanRead_Selector()
        {
            Equal("x", new CssSelector("x ").Selector);
            Equal("#x", new CssSelector("#x").Selector);
            Equal(".x", new CssSelector(" .x").Selector);
            Equal("x.y", new CssSelector("x.y").Selector);
        }

        [Fact]
        public void AfterCreatingCssSelector_CanRead_Element()
        {
            Null(new CssSelector("#x").Element);
            Null(new CssSelector(".x").Element);
            Equal("x", new CssSelector("x").Element);
            Equal("x", new CssSelector("x.y").Element);
        }

        [Fact]
        public void AfterCreatingCssSelector_CanRead_ID()
        {
            Null (new CssSelector("x").ID);
            Null (new CssSelector(".x").ID);
            Null (new CssSelector("x.y").ID);
            Equal("x", new CssSelector("#x").ID);
        }

        [Fact]
        public void AfterCreatingCssSelector_CanRead_Class()
        {
            Null(new CssSelector("x").Class);
            Null(new CssSelector("#x").Class);
            Equal("x", new CssSelector(".x").Class);
            Equal("y", new CssSelector("x.y").Class);
        }

        #endregion

        #region CssSelectorsTests

        [Fact]
        public void AfterCreatingCssSelectors_CountOfSelectors_IsZero()
        {
            Equal(0, new CssSelectors("").Count);
        }

        [Fact]
        public void WhenCreatingCssSelectors_IfCssSelectorIsInvalid_Throws()
        {
            Throws<InvalidSelectorException>(() => new CssSelectors("0"));
            Throws<InvalidSelectorException>(() => new CssSelectors("x y"));
        }

        [Fact]
        public void AfterCreatingCssSelectors_WithOneSelector_CountOfSelectorsIsOne()
        {
            Equal(1, new CssSelectors("x").Count);
        }

        [Fact]
        public void AfterCreatingCssSelectors_WithTwoSelectors_CountOfSelectorsIsTwo()
        {
            Equal(2, new CssSelectors("x, #y").Count);
        }

        [Fact]
        public void AfterCreatingCssSelectors_CanIndex_IndividualProperties()
        {
            Equal("x", new CssSelectors("x, #x, .x")[2].Class);
        }

        [Fact]
        public void AfterCreatingCssSelectors_CanRead_IndividualSelectorsAndTheirElementIDAndClass()
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
        public void AfterCreatingCssSelectors_CanRead_RealWorldSelectorsAndTheirElementIDAndClass()
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

        [Fact]
        public void AfterCreatingCssSelectors_CanAssignAndRead_IndividualCssSelector()
        {
            var cssSelector = new CssSelectors("x, #x, .x, x.y")[3];

            Equal("x.y", cssSelector.Selector);
            Equal("x", cssSelector.Element);
            Null(cssSelector.ID);
            Equal("y", cssSelector.Class);
        }

        [Fact]
        public void AfterCreatingCssSelectors_IfIndexOfSelectorsIsOutOfRange_Throws()
        {
            var cssSelectors = new CssSelectors("x.y, x, .y, #z");

            Throws<ArgumentOutOfRangeException>(() => cssSelectors[-1].Selector);
            Throws<ArgumentOutOfRangeException>(() => cssSelectors[4].Element);
        }

        #endregion

        #region CssRuleTests

        [Fact]
        public void WhenCreatingCssRule_IfHasInvalidBraces_Throws()
        {
            Throws<InvalidBracesException>(() => new CssRule("x x:0"));
            Throws<InvalidBracesException>(() => new CssRule("x{x:0"));
            Throws<InvalidBracesException>(() => new CssRule("x x:0}"));
            Throws<InvalidBracesException>(() => new CssRule("x}x:0{"));
        }

        [Fact]
        public void WhenCreatingCssRule_IfHasInvalidOrMissingSelector_Throws()
        {
            Throws<InvalidSelectorException>(() => new CssRule("{}"));
            Throws<InvalidSelectorException>(() => new CssRule("0{}"));
            Throws<InvalidSelectorException>(() => new CssRule("lišće{}"));
        }

        [Fact]
        public void WhenCreatingCssRule_IfHasInvalidProperty_Throws()
        {
            ThrowsAny<CssPropertyException>(() => new CssRule("x{0}"));
            ThrowsAny<CssPropertyException>(() => new CssRule("x,y{x:}"));
            ThrowsAny<CssPropertyException>(() => new CssRule(".x,y.y,z{:0}"));
            ThrowsAny<CssPropertyException>(() => new CssRule("#x{a:a;b;c:c}"));
        }

        [Fact]
        public void AfterCreatingCssRule_CanRead_IndividualSelectorsAndProperties()
        {
            var rule = new CssRule("x.y, x, .y, #z {a:0; b:1; c:2; d:3}");

            Equal(4, rule.CssSelectors.Count);

            Equal("x.y", rule.CssSelectors[0].Selector);
            Equal("x", rule.CssSelectors[1].Element);
            Equal("y", rule.CssSelectors[2].Class);
            Equal("z", rule.CssSelectors[3].ID);

            Equal(4, rule.CssProperties.Count);

            Equal("a", rule.CssProperties[0].Name);
            Equal("0", rule.CssProperties[0].Value);

            Equal("b", rule.CssProperties[1].Name);
            Equal("1", rule.CssProperties[1].Value);

            Equal("c", rule.CssProperties[2].Name);
            Equal("2", rule.CssProperties[2].Value);

            Equal("d", rule.CssProperties[3].Name);
            Equal("3", rule.CssProperties[3].Value);
        }

        [Fact]
        public void AfterCreatingCssRule_CanRead_RealWorldSelectorsAndProperties()
        {
            var rule = new CssRule("p, li {\n\tfont-family: \"arial\";\n\tfont-weight: bold;\n\tfont-size: 120%\n\t}");

            Equal(2, rule.CssSelectors.Count);

            Equal("p", rule.CssSelectors[0].Selector);
            Equal("li", rule.CssSelectors[1].Element);

            Equal(3, rule.CssProperties.Count);

            Equal("font-family", rule.CssProperties[0].Name);
            Equal("\"arial\"", rule.CssProperties[0].Value);

            Equal("font-weight", rule.CssProperties[1].Name);
            Equal("bold", rule.CssProperties[1].Value);

            Equal("font-size", rule.CssProperties[2].Name);
            Equal("120%", rule.CssProperties[2].Value);
        }

        #endregion

        #region CssFileTests

        [Fact]
        public void WhenCreatingCssFile_IfFileIsEmptyOrWhiteSpace_CountOfRulesIsZero()
        {
            Equal(0, new CssFile("").Count);
            Equal(0, new CssFile(" \t\r\n").Count);
        }

        [Fact]
        public void WhenCreatingCssFile_IfAnyCssRuleInCssFileHasInvalidBraces_Throws()
        {
            Throws<InvalidBracesException>(() => new CssFile("x x:0"));
            Throws<InvalidBracesException>(() => new CssFile("a{a:0}}"));
            Throws<InvalidBracesException>(() => new CssFile("a{{a:0}"));
            Throws<InvalidBracesException>(() => new CssFile("x x:0}"));
            Throws<InvalidBracesException>(() => new CssFile("x}x:0{"));
            Throws<InvalidBracesException>(() => new CssFile("a{a:0}\r\n x"));
            Throws<InvalidBracesException>(() => new CssFile("a{a:0}\r\n x x:0"));
            Throws<InvalidBracesException>(() => new CssFile("a{a:0}\r\n b{b:0}\n x x:0"));
            Throws<InvalidBracesException>(() => new CssFile("a{a:0}\r\n b{b:0}}\n x x:0\n c{c:0}"));
            Throws<InvalidBracesException>(() => new CssFile("x{x:0}x,y{{y:0}"));
        }

        [Fact]
        public void WhenCreatingCssFile_IfAnyCssRuleInCssFileHasInvalidSelector_Throws()
        {
            Throws<InvalidSelectorException>(() => new CssFile("'x{x:0}"));
            Throws<InvalidSelectorException>(() => new CssFile("a{a:0}\r\n 0b{b:0}\n\n c{c:0}"));
            Throws<InvalidSelectorException>(() => new CssFile("a{a:0}\r\n b{b:0}\n\n c c{c:0}"));
            Throws<InvalidSelectorException>(() => new CssFile("a{a:0}\r\n šč \n {šč:0}\n\n c.c{c:0}"));
        }

        [Fact]
        public void WhenCreatingCssFile_IfAnyCssRuleInCssFileHasInvalidProperty_Throws()
        {
            ThrowsAny<CssPropertyException>(() => new CssFile("x{0:0}"));
            ThrowsAny<CssPropertyException>(() => new CssFile("a{a:0}\r\n b{b b:0}\n\n c{c:0}"));
            ThrowsAny<CssPropertyException>(() => new CssFile("a{a:0}\r\n b \n {b \n : \n 0 \n }\n\n c.c{d.d:0}"));
            ThrowsAny<CssPropertyException>(() => new CssFile("a{a:0}\r\n sc \n {šč:0}\n\n šč{c:0}"));
        }

        [Fact]
        public void AfterCreatingCssFile_CountMaches_NumberOfRulesInFile()
        {
            Equal(1, new CssFile("a{a:0}").Count);
            Equal(2, new CssFile("a{a:0}\r\n b{b:0}\n").Count);
            Equal(3, new CssFile("a{\r\na:0;\r\n}\r\nb{\r\nb:0;\r\n}\r\nc.c{\r\nc:0\r\n}").Count);
            Equal(4, new CssFile(".a{\na:0;\n}\nb{\nb:0;\n}\nc.c,c{\nc:0\n}\n#d{\nd:0\n}").Count);
            Equal(7, new CssFile(".a{\na:0;\n}\nb{\nb:0;\n}\nc.c{\nc:0\n}\n#d,#d.d{\nd:0\n}\n#d{\na:0\n}\n#d{\nb:0\n}\n#d{\nc:0\n}").Count);
        }

        [Fact]
        public void AfterCreatingCssFile_CanIndex_IndividualRules()
        {
            Equal("b", new CssFile("a{a:0}\n b{b:0}")[1].CssProperties[0].Name);
        }

        [Fact]
        public void AfterCreatingCssFile_CanRead_RulesSelectorsAndProperties()
        {
            var cssFile = new CssFile(".a{\na:0;\n}\nb{\nb:7;\n}\ne.f,#g,.h,i{\nc:1;cc:22;ccc:333\n}\no.p{\nd:9\n}");

            Equal(".a", cssFile[0].CssSelectors[0].Selector);
            Equal("a", cssFile[0].CssSelectors[0].Class);
            Equal("a", cssFile[0].CssProperties[0].Name);
            Equal("0", cssFile[0].CssProperties[0].Value);

            Equal("b", cssFile[1].CssSelectors[0].Selector);
            Equal("b", cssFile[1].CssSelectors[0].Element);
            Equal("b", cssFile[1].CssProperties[0].Name);
            Equal("7", cssFile[1].CssProperties[0].Value);

            Equal("e.f", cssFile[2].CssSelectors[0].Selector);
            Equal("e", cssFile[2].CssSelectors[0].Element);
            Equal("f", cssFile[2].CssSelectors[0].Class);
            Equal("#g", cssFile[2].CssSelectors[1].Selector);
            Equal("g", cssFile[2].CssSelectors[1].ID);
            Equal(".h", cssFile[2].CssSelectors[2].Selector);
            Equal("h", cssFile[2].CssSelectors[2].Class);
            Equal("i", cssFile[2].CssSelectors[3].Selector);
            Equal("i", cssFile[2].CssSelectors[3].Element);

            Equal("c", cssFile[2].CssProperties[0].Name);
            Equal("1", cssFile[2].CssProperties[0].Value);
            Equal("cc", cssFile[2].CssProperties[1].Name);
            Equal("22", cssFile[2].CssProperties[1].Value);
            Equal("ccc", cssFile[2].CssProperties[2].Name);
            Equal("333", cssFile[2].CssProperties[2].Value);

            Equal("o.p", cssFile[3].CssSelectors[0].Selector);
            Equal("o", cssFile[3].CssSelectors[0].Element);
            Equal("p", cssFile[3].CssSelectors[0].Class);
            Equal("d", cssFile[3].CssProperties[0].Name);
            Equal("9", cssFile[3].CssProperties[0].Value);
        }

        [Fact]
        public void AfterCreatingCssFile_CanAssignAndRead_IndividualCssRule()
        {
            var cssRule = new CssFile(".a{\na:0;\n}\nb{\nb:7;\n}\ne.f,#g,.h,i{\nc:1;cc:22;ccc:333\n}\no.p{\nd:9\n}")[2];

            Equal("c", cssRule.CssProperties[0].Name);
            Equal("1", cssRule.CssProperties[0].Value);
            Equal("cc", cssRule.CssProperties[1].Name);
            Equal("22", cssRule.CssProperties[1].Value);
            Equal("ccc", cssRule.CssProperties[2].Name);
            Equal("333", cssRule.CssProperties[2].Value);
        }

        [Fact]
        public void AfterCreatingCssFile_IfIndexOfRulesIsOutOfRange_Throws()
        {
            var cssFile = new CssFile(".a{\na:0;\n}\nb{\nb:7;\n}\ne.f,#g,.h,i{\nc:1;cc:22;ccc:333\n}\no.p{\nd:9\n}");

            Throws<ArgumentOutOfRangeException>(() => cssFile[-1].CssSelectors);
            Throws<ArgumentOutOfRangeException>(() => cssFile[4].CssProperties);
        }

        #endregion

        #region CssMarginTests

        [Fact]
        public void WhenCreatingCssMargin_IfItisNonMarginProperty_Throws()
        {
            Throws<InvalidMarginException>(() => new CssMargin(new CssProperty("x:0")));
        }

        [Fact]
        public void WhenCreatingCssMargin_IfMarginPropertyNameIsInvalid_Throws()
        {
            Throws<InvalidMarginException>(() => new CssMargin(new CssProperty("margintop:0")));
            Throws<InvalidMarginException>(() => new CssMargin(new CssProperty("margin-botom:0")));
        }

        [Fact]
        public void WhenCreatingCssMargin_IfLengthIsInvalid_Throws()
        {
            Throws<InvalidMarginException>(() => new CssMargin(new CssProperty("margin:0xp")));
            Throws<InvalidMarginException>(() => new CssMargin(new CssProperty("margin:10 px")));
            Throws<InvalidMarginException>(() => new CssMargin(new CssProperty("margin:0vh 1vw")));
            Throws<InvalidMarginException>(() => new CssMargin(new CssProperty("margin:0 2cm 3px")));
            Throws<InvalidMarginException>(() => new CssMargin(new CssProperty("margin:0 1px 2em 3ex")));
            Throws<InvalidMarginException>(() => new CssMargin(new CssProperty("margin-top:0xp")));
            Throws<InvalidMarginException>(() => new CssMargin(new CssProperty("margin-top:1px 0px")));
        }

        [Fact]
        public void AfterCreatingCssMarginOnOneSide_CanRead_MarginWidthOfThatSide()
        {
            Equal("0", new CssMargin(new CssProperty("margin-top:0")).Top);
            Equal("12.34px", new CssMargin(new CssProperty("margin-right : \t 12.34px")).Right);
            Equal("-20em", new CssMargin(new CssProperty("margin-bottom: -20em")).Bottom);
            Equal("30%", new CssMargin(new CssProperty("margin-left \n : \n 30%")).Left);
        }

        [Fact]
        public void AfterCreatingCssMarginOnAllSides_CanRead_MarginWidthOfThatSide()
        {
            var cssMargin1 = new CssMargin(new CssProperty("margin:0"));
            Equal("0", cssMargin1.Top);
            Equal("0", cssMargin1.Right);
            Equal("0", cssMargin1.Bottom);
            Equal("0", cssMargin1.Left);

            var cssMargin2 = new CssMargin(new CssProperty("margin:-10px \t 20em"));
            Equal("-10px", cssMargin2.Top);
            Equal("20em", cssMargin2.Right);
            Equal("-10px", cssMargin2.Bottom);
            Equal("20em", cssMargin2.Left);

            var cssMargin3 = new CssMargin(new CssProperty("margin:1em auto\n1%"));
            Equal("1em", cssMargin3.Top);
            Equal("auto", cssMargin3.Right);
            Equal("1%", cssMargin3.Bottom);
            Equal("auto", cssMargin3.Left);

            var cssMargin4 = new CssMargin(new CssProperty("margin:1 2.2%\t-3.3em\r\n444.44px"));
            Equal("1", cssMargin4.Top);
            Equal("2.2%", cssMargin4.Right);
            Equal("-3.3em", cssMargin4.Bottom);
            Equal("444.44px", cssMargin4.Left);
        }

        #endregion
    }
}
