
using HtmlRefactoringWindowsApp.Css;
using HtmlRefactoringWindowsApp.Magazines;
using static Xunit.Assert;

namespace HtmlRefactoringTests
{
    public class MagazineTests
    {
        #region MagazineBrandTests

        [Fact]
        public void WhenCreatingMagazineBrand_WithEmptyOrWhiteSpaceArgument_Throws()
        {
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand(" \t"));
        }

        [Fact]
        public void WhenCreatingMagazineBrand_WithInvalidNumberOfParametersInCsvArgument_Throws()
        {
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("a;b;c;d"));
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("a;b;c;d;e;f"));
        }

        [Fact]
        public void WhenCreatingMagazineBrand_IfIDIsInvalid_Throws()
        {
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand(";2;A;B;C"));
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("0;2;A;B;C"));
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("ab;2;A;B;C"));
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("123;2;A;B;C"));
        }

        [Fact]
        public void WhenCreatingMagazineBrand_IfWebIDIsInvalid_Throws()
        {
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("1;;Abc defg;Hijk;L"));
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("1;00;Abc defg;Hijk;L"));
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("1;abc;Abc defg;Hijk;L"));
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("1;1000;Abc defg;Hijk;L"));
        }

        [Fact]
        public void WhenCreatingMagazineBrand_IfNameIsInvalid_Throws()
        {
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("1;2;;Hijk;L"));
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("1;2;abc;Hijk;L"));
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("1;2;Ab-c;Hijk;L"));
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("1;2;Abcd7;Hijk;L"));
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("1;2;Abc,de;Hijk;L"));
        }

        [Fact]
        public void WhenCreatingMagazineBrand_IfLabelIsInvalid_Throws()
        {
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("1;2;Abc defg;;L"));
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("1;2;Abc defg;Hi;L"));
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("1;2;Abc defg;hij;L"));
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("1;2;Abc defg;H i;L"));
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("1;2;Abc defg;Hijž;L"));
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("1;2;Abc defg;h5ij;L"));
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("1;2;Abc defg;H,hi;L"));
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("1;2;Abc defg;Hijkl;L"));
        }

        [Fact]
        public void WhenCreatingMagazineBrand_IfLeadCharIsInvalid_Throws()
        {
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("1;2;Abc defg;Hij;"));
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("1;2;Abc defg;Hij; "));
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("1;2;Abc defg;Hijk;0"));
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("1;2;Abc defg;Hijk;Š"));
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("1;2;Abc defg;Hijk;x"));
        }

        [Fact]
        public void AfterConstructionOfMagazineBrand_CanRead_AllProperties()
        {
            var magazineBrand1 = new MagazineBrand("1;2;Abc defg;Hijk;L");
            Equal(1, magazineBrand1.ID);
            Equal(2, magazineBrand1.WebID);
            Equal("Abc defg", magazineBrand1.Name);
            Equal("Hijk", magazineBrand1.Label);
            Equal('L', magazineBrand1.LeadChar);

            var magazineBrand2 = new MagazineBrand("9;99;RRiF;RRiF;R");
            Equal(9, magazineBrand2.ID);
            Equal(99, magazineBrand2.WebID);
            Equal("RRiF", magazineBrand2.Name);
            Equal("RRiF", magazineBrand2.Label);
            Equal('R', magazineBrand2.LeadChar);

            var magazineBrand3 = new MagazineBrand("99;999;Pravo i porezi;PiP;P");
            Equal(99, magazineBrand3.ID);
            Equal(999, magazineBrand3.WebID);
            Equal("Pravo i porezi", magazineBrand3.Name);
            Equal("PiP", magazineBrand3.Label);
            Equal('P', magazineBrand3.LeadChar);
        }

        #endregion

        #region MagazineBrandsTests

        [Fact]
        public void AfterCreatingMagazineBrands_CountOfIndividualMagazineBrands_IsZero()
        {
            Equal(0, new MagazineBrands("").Count);
        }

        [Fact]
        public void WhenCreatingMagazineBrands_IfAnyOfIndividualBrandsIsInvalid_Throws()
        {
            Throws<InvalidMagazineBrandException>(() => new MagazineBrands("7;88;Xyz;Xy;X"));
            Throws<InvalidMagazineBrandException>(() => new MagazineBrands("7;88;Xyz;Xyz;X\n8;89;Opq;Opq;9"));
            Throws<InvalidMagazineBrandException>(() => new MagazineBrands("7;88;Xyz;Xyz;X\n8;89;Opq;Opq;O\n6;A;Abc;Abc;A"));
        }

        [Fact]
        public void AfterCreatingMagazineBrands_WithOneBrand_CountOfBrandsIsOne()
        {
            Equal(1, new MagazineBrands("7;88;Xyz;Xyz;X").Count);
        }

        [Fact]
        public void AfterCreatingMagazineBrands_WithTwoBrands_CountOfBradnsIsTwo()
        {
            Equal(2, new MagazineBrands("7;88;Xyz;Xyz;X\n8;89;Opq;Opq;O").Count);
        }

        [Fact]
        public void AfterCreatingMagazineBrands_CanRead_IndividualFields()
        {
            var magazineBrands = new MagazineBrands("7;88;Xyz;Xyz;X\n8;89;Opq;Opq;O");

            Equal(7 , magazineBrands[0].ID);
            //Equal("0", magazineBrands[0].Value);

        }

        //[Fact]
        //public void AfterCreatingCssProperties_CanRead_RealWorldIndividualPropertyNamesAndValues()
        //{
        //    var cssProperties = new CssProperties("border-collapse:collapse;\r\n\tborder-color\t:\t#000000;\r\n\tborder-style : solid;\r\n\t" +
        //                                          "border-width:1px;\r\n\tmargin-bottom:-4px;\r\n\tmargin-top:4px;\r\n\t" +
        //                                          "font-family:\"Myriad Pro\", sans-serif;");

        //    Equal("border-collapse", cssProperties[0].Name);
        //    Equal("collapse", cssProperties[0].Value);

        //    Equal("border-color", cssProperties[1].Name);
        //    Equal("#000000", cssProperties[1].Value);

        //    Equal("border-style", cssProperties[2].Name);
        //    Equal("solid", cssProperties[2].Value);

        //    Equal("border-width", cssProperties[3].Name);
        //    Equal("1px", cssProperties[3].Value);

        //    Equal("margin-bottom", cssProperties[4].Name);
        //    Equal("-4px", cssProperties[4].Value);

        //    Equal("margin-top", cssProperties[5].Name);
        //    Equal("4px", cssProperties[5].Value);

        //    Equal("font-family", cssProperties[6].Name);
        //    Equal("\"Myriad Pro\", sans-serif", cssProperties[6].Value);

        //    Equal(7, cssProperties.Count);
        //}

        //[Fact]
        //public void AfterCreatingCssProperties_CanAssignAndRead_IndividualCssProperty()
        //{
        //    var cssProperty = new CssProperties("X:0;y:1;Z:2")[2];

        //    Equal("z", cssProperty.Name);
        //    Equal("2", cssProperty.Value);
        //}

        //[Fact]
        //public void AfterCreatingCssProperties_IfIndexOfPropertiesIsOutOfRange_Throws()
        //{
        //    var cssProperties = new CssProperties("a:0; b:1; c:2");

        //    Throws<ArgumentOutOfRangeException>(() => cssProperties[-1].Name);
        //    Throws<ArgumentOutOfRangeException>(() => cssProperties[3].Value);
        //}

        #endregion
    }
}
