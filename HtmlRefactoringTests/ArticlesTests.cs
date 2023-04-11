
using HtmlRefactoringWindowsApp.Articles;
using static Xunit.Assert;

namespace HtmlRefactoringTests
{
    public class ArticlesTests
    {
        #region MagazineBrandTests

        [Fact]
        public void WhenCreatingMagazineBrandWithEmptyOrWhiteSpaceArgument_Throws()
        {
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand(" \t"));
        }

        [Fact]
        public void WhenCreatingMagazineBrandWithInvalidNumberOfParametersInCsvArgument_Throws()
        {
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand(" ;\t; ;"));
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("a;b;c;d;e;f"));
        }

        [Fact]
        public void WhenCreatingMagazineBrandIfIDIsInvalid_Throws()
        {
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("0;2;A;B;C"));
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("ab;2;A;B;C"));
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("123;2;A;B;C"));
        }

        [Fact]
        public void WhenCreatingMagazineBrandIfWebIDIsInvalid_Throws()
        {
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("1;00;Abc defg;Hijk;L"));
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("1;abc;Abc defg;Hijk;L"));
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("1;1000;Abc defg;Hijk;L"));
        }

        [Fact]
        public void WhenCreatingMagazineBrandIfNameIsInvalid_Throws()
        {
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("1;2;abc;Hijk;L"));
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("1;2;Ab-c;Hijk;L"));
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("1;2;Abcd7;Hijk;L"));
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("1;2;Abc,de;Hijk;L"));
        }

        [Fact]
        public void WhenCreatingMagazineBrandIfLabelIsInvalid_Throws()
        {
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("1;2;Abc defg;Hij;L"));
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("1;2;Abc defg;hijk;L"));
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("1;2;Abc defg;H ij;L"));
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("1;2;Abc defg;Hij5;L"));
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("1;2;Abc defg;H,hi;L"));
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("1;2;Abc defg;Hijkl;L"));
        }

        [Fact]
        public void AfterConstructionOfMagazineBrand_CanReadAllProperties()
        {
            var magazineBrand1 = new MagazineBrand("1;2;Abc defg;Hijk;L");
            Equal(1, magazineBrand1.ID);
            Equal(2, magazineBrand1.WebID);
            Equal("Abc defg", magazineBrand1.Name);
            Equal("Hijk", magazineBrand1.Label);
            Equal('L', magazineBrand1.LeadChar);
        }

        #endregion

        #region ArticleTests

        [Fact]
        public void WhenTitleIsEmptyOrWhiteSpace_Throws()
        {
            Throws<ArgumentOutOfRangeException>(() => new Article("", "b", "c", "d"));
            Throws<ArgumentOutOfRangeException>(() => new Article(" \t\r\n", "b", "c", "d"));
        }

        [Fact]
        public void AfterCreatingArticle_CanReadTitle()
        {
            const string title = "Title";
            Equal(title, new Article(title, "b", "c", "d").Title);
        }

        [Fact]
        public void WhenAuthorNameWithTitlesIsEmptyOrWhiteSpace_Throws()
        {
            Throws<ArgumentOutOfRangeException>(() => new Article("a", "", "c", "d"));
            Throws<ArgumentOutOfRangeException>(() => new Article("a", " \t\r\n", "c", "d"));
        }

        [Fact]
        public void AfterCreatingArticle_CanReadAuthorNameWithTitles()
        {
            const string authorNameWithTitles = "Author Name with Titles";

            Equal(authorNameWithTitles, new Article("a", authorNameWithTitles, "c", "d").AuthorNameWithTitles);
        }

        [Fact]
        public void WhenInputRelativePathIsEmptyOrWhiteSpace_Throws()
        {
            Throws<ArgumentOutOfRangeException>(() => new Article("a", "b", "", "d"));
            Throws<ArgumentOutOfRangeException>(() => new Article("a", "b", " \t\r\n", "d"));
        }

        [Fact]
        public void Article_InputRelativePath_Successful_Initialization()
        {
            const string inputRelativePath = "Input Relative Path";

            Equal(inputRelativePath, new Article("a", "b", inputRelativePath, "d").InputRelativePath);
        }

        [Fact]
        public void WhenInputFileNameIsEmptyOrWhiteSpace_Throws()
        {
            Throws<ArgumentOutOfRangeException>(() => new Article("a", "b", "c", ""));
            Throws<ArgumentOutOfRangeException>(() => new Article("a", "b", "c", " \t\r\n"));
        }

        [Fact]
        public void Article_InputFileName_Successful_Initialization()
        {
            const string inputFileName = "Input File Name";

            Equal(inputFileName, new Article("a", "b", "c", inputFileName).InputFileName);
        }

        [Fact]
        public void Article_AuthorNameWithoutTitles()
        {
            Equal("Ivan PETARÈIÆ", new Article("a",
                  "Ivan PETARÈIÆ, struè. spec. oec. zamjenik glavne urednice", "c", "d").AuthorNameWithoutTitles());

            Equal("Tamara CIRKVENI FILIPOVIÆ", new Article("a",
                  "Dr. sc. Tamara CIRKVENI FILIPOVIÆ, prof. v. šk. i ovl. raè.", "c", "d").AuthorNameWithoutTitles());

            Equal("Vlado BRKANIÆ", new Article("a",
                  "Dr. sc. Vlado BRKANIÆ , prof. struè. stud., ovl. raè. i ovl. rev.", "c", "d").AuthorNameWithoutTitles());
        }

        #endregion

        #region MagazineBrandTests

        [Fact]
        public void MagazineBrand_IsDefined_True()
        {
            bool isDefined = true;

            foreach (MagazineBrandEx magazineBrand in (MagazineBrandEx[])Enum.GetValues(typeof(MagazineBrandEx)))
            {
                isDefined &= magazineBrand.IsDefined();
            }
            True(isDefined);
        }

        [Fact]
        public void MagazineBrand_IsDefined_False()
        {
            MagazineBrandEx prevToMinElement = (MagazineBrandEx)(Enum.GetValues(typeof(MagazineBrandEx)).Cast<int>().Min() - 1);
            False(prevToMinElement.IsDefined());

            MagazineBrandEx succToMaxElement = (MagazineBrandEx)(Enum.GetValues(typeof(MagazineBrandEx)).Cast<int>().Max() + 1);
            False(succToMaxElement.IsDefined());
        }

        [Fact]
        public void MagazineBrand_Unknown_Label()
        {
            MagazineBrandEx succToMaxElement = (MagazineBrandEx)(Enum.GetValues(typeof(MagazineBrandEx)).Cast<int>().Max() + 1);

            Throws<ArgumentOutOfRangeException>(() => succToMaxElement.GetLabel());
        }

        [Fact]
        public void MagazineBrand_RRiF_Label()
        {
            Equal("RRiF", MagazineBrandEx.RRiF.GetLabel());
        }

        [Fact]
        public void MagazineBrand_PiP_Name()
        {
            Equal("Pravo i porezi", MagazineBrandEx.PiP.GetName());
        }

        [Fact]
        public void MagazineBrand_Proracuni_LeadChar()
        {
            Equal("P", MagazineBrandEx.Proracuni.GetLeadChar());
        }

        [Fact]
        public void MagazineBrand_Neprofitni_WebID()
        {
            Equal(7, MagazineBrandEx.Neprofitni.GetWebID());
        }

        #endregion
    }
}
