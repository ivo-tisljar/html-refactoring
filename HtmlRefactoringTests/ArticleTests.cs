
using HtmlRefactoringWindowsApp;
using HtmlRefactoringWindowsApp.Articles;
using static Xunit.Assert;

namespace HtmlRefactoringTests
{
    public class ArticleTests
    {
        #region MagazineBrandTests

        [Fact]
        public void WhenCreatingMagazineBrandWithEmptyOrWhiteSpaceArgument_Throws()
        {
            Throws<MagazineBrandException>(() => new MagazineBrand(" \t"));
        }

        [Fact]
        public void WhenCreatingMagazineBrandWithInvalidNumberOfParametersInCsvArgument_Throws()
        {
            Throws<MagazineBrandException>(() => new MagazineBrand(" ;\t; ;"));
            Throws<MagazineBrandException>(() => new MagazineBrand("a;b;c;d;e;f"));
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
