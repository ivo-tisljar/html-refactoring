
using HtmlRefactoringWindowsApp.Articles;
using HtmlRefactoringWindowsApp.Temp;
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
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand(";2;A;B;C"));
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("0;2;A;B;C"));
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("ab;2;A;B;C"));
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("123;2;A;B;C"));
        }

        [Fact]
        public void WhenCreatingMagazineBrandIfWebIDIsInvalid_Throws()
        {
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("1;;Abc defg;Hijk;L"));
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("1;00;Abc defg;Hijk;L"));
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("1;abc;Abc defg;Hijk;L"));
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("1;1000;Abc defg;Hijk;L"));
        }

        [Fact]
        public void WhenCreatingMagazineBrandIfNameIsInvalid_Throws()
        {
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("1;2;;Hijk;L"));
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("1;2;abc;Hijk;L"));
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("1;2;Ab-c;Hijk;L"));
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("1;2;Abcd7;Hijk;L"));
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("1;2;Abc,de;Hijk;L"));
        }

        [Fact]
        public void WhenCreatingMagazineBrandIfLabelIsInvalid_Throws()
        {
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("1;2;Abc defg;;L"));
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("1;2;Abc defg;Hi;L"));
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("1;2;Abc defg;hij;L"));
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("1;2;Abc defg;H i;L"));
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("1;2;Abc defg;Hij�;L"));
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("1;2;Abc defg;h5ij;L"));
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("1;2;Abc defg;H,hi;L"));
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("1;2;Abc defg;Hijkl;L"));
        }

        [Fact]
        public void WhenCreatingMagazineBrandIfLeadCharIsInvalid_Throws()
        {
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("1;2;Abc defg;Hij;"));
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("1;2;Abc defg;Hij; "));
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("1;2;Abc defg;Hijk;0"));
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("1;2;Abc defg;Hijk;�"));
            Throws<InvalidMagazineBrandException>(() => new MagazineBrand("1;2;Abc defg;Hijk;x"));
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
            Equal("Ivan PETAR�I�", new Article("a",
                  "Ivan PETAR�I�, stru�. spec. oec. zamjenik glavne urednice", "c", "d").AuthorNameWithoutTitles());

            Equal("Tamara CIRKVENI FILIPOVI�", new Article("a",
                  "Dr. sc. Tamara CIRKVENI FILIPOVI�, prof. v. �k. i ovl. ra�.", "c", "d").AuthorNameWithoutTitles());

            Equal("Vlado BRKANI�", new Article("a",
                  "Dr. sc. Vlado BRKANI� , prof. stru�. stud., ovl. ra�. i ovl. rev.", "c", "d").AuthorNameWithoutTitles());
        }

        #endregion
    }
}