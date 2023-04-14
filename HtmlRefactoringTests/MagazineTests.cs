
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
            Throws<InvalidMagazineBrandException>(() => new MagazineBrands("7;88;Xyz;Xy;X\n8;89;Opq;Op;O"));
            Throws<InvalidMagazineBrandException>(() => new MagazineBrands("7;88;Xyz;Xy;X"));
            Throws<InvalidMagazineBrandException>(() => new MagazineBrands("7;88;Xyz;Xy;X"));
        }

        #endregion
    }
}
