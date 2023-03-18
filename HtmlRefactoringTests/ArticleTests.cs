using HtmlRefactoringWindowsApp;
using static Xunit.Assert;

namespace HtmlRefactoringTests
{
    public class ArticleTests
    {
        [Fact]
        public void Article_Title_Successful_Initialization()
        {
            const string title = "Title";

            var article = new Article(title, "2", "3", "4");

            Equal(title, article.Title);
        }

        [Fact]
        public void Title_WhenEmptyThrows()
        {
            const string title = "";

            Throws<ArgumentOutOfRangeException>(() => new Article(title, "2", "3", "4"));
        }

        [Fact]
        public void Title_WhenWhiteSpaceThrows()
        {
            const string title = " \t\r\n";

            Throws<ArgumentOutOfRangeException>(() => new Article(title, "2", "3", "4"));
        }

        //[Fact]
        //public void AuthorNameWithTitles_WhenNullThrows()
        //{
        //    const string authorNameWithTitles = "AuthorNameWithTitles";

        //    var article = new Article("1", authorNameWithTitles, "3", "4");

        //    Equal(authorNameWithTitles, article.AuthorNameWithTitles);
        //}

        [Fact]
        public void AuthorNameWithTitles_WhenEmptyThrows()
        {
            const string authorNameWithTitles = "";

            Throws<ArgumentOutOfRangeException>(() => new Article("1", authorNameWithTitles, "3", "4"));
        }

        [Fact]
        public void Article_AuthorNameWithTitles_When_WhiteSpace_Throws()
        {
            const string authorNameWithTitles = " \t\r\n";

            Throws<ArgumentOutOfRangeException>(() => new Article("1", authorNameWithTitles, "3", "4"));
        }

        [Fact]
        public void Article_InputRelativePath_Successful_Initialization()
        {
            const string inputRelativePath = "InputRelativePath";

            var article = new Article("1", "2", inputRelativePath, "4");

            Equal(inputRelativePath, article.InputRelativePath);
        }

        [Fact]
        public void Article_InputRelativePath_When_Empty_Throws()
        {
            const string inputRelativePath = "";

            Throws<ArgumentOutOfRangeException>(() => new Article("1", "2", inputRelativePath, "4"));
        }

        [Fact]
        public void Article_InputRelativePath_When_WhiteSpace_Throws()
        {
            const string inputRelativePath = " \t\r\n";

            Throws<ArgumentOutOfRangeException>(() => new Article("1", "2", inputRelativePath, "4"));
        }

        [Fact]
        public void Article_InputFileName_Successful_Initialization()
        {
            const string inputFileName = "InputFileName";

            var article = new Article("1", "2", "3", inputFileName);

            Equal(inputFileName, article.InputFileName);
        }

        [Fact]
        public void Article_InputFileName_When_Empty_Throws()
        {
            const string inputFileName = "";

            Throws<ArgumentOutOfRangeException>(() => new Article("1", "2", "3", inputFileName));
        }

        [Fact]
        public void Article_InputFileName_When_WhiteSpace_Throws()
        {
            const string inputFileName = " \t\r\n";

            Throws<ArgumentOutOfRangeException>(() => new Article("1", "2", "3", inputFileName));
        }

        [Fact]
        public void Article_AuthorNameWithoutTitles_Ivan()
        {
            const string nameWithTitles = "Ivan PETAR�I�, stru�. spec. oec. zamjenik glavne urednice";
            const string nameWithoutTitles = "Ivan PETAR�I�";

            var article = new Article("1", nameWithTitles, "3", "4");

            string authorNameWithoutTitles = article.AuthorNameWithoutTitles();

            Equal(authorNameWithoutTitles, nameWithoutTitles);
        }

        [Fact]
        public void Article_AuthorNameWithoutTitles_Tamara()
        {
            const string nameWithTitles = "Dr. sc. Tamara CIRKVENI FILIPOVI�, prof. v. �k. i ovl. ra�.";
            const string nameWithoutTitles = "Tamara CIRKVENI FILIPOVI�";

            var article = new Article("1", nameWithTitles, "3", "4");

            string authorNameWithoutTitles = article.AuthorNameWithoutTitles();

            Equal(authorNameWithoutTitles, nameWithoutTitles);
        }

        [Fact]
        public void Article_AuthorNameWithoutTitles_Vlado()
        {
            const string nameWithTitles = "Dr. sc. Vlado BRKANI� , prof. stru�. stud., ovl. ra�. i ovl. rev.";
            const string nameWithoutTitles = "Vlado BRKANI�";

            var article = new Article("1", nameWithTitles, "3", "4");

            string authorNameWithoutTitles = article.AuthorNameWithoutTitles();

            Equal(authorNameWithoutTitles, nameWithoutTitles);
        }
    }
}