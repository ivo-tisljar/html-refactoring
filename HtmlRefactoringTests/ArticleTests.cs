//using HtmlRefactoringWindowsApp;
using HtmlRefactoringConsole;

namespace HtmlRefactoringTests
{
    public class ArticleTests
    {
        [Fact]
        public void Article_Title_Successful_Initialization()
        {
            const string title = "Title";

            var article = new Article(title, "2", "3", "4");

            Assert.Equal(title, article.Title);
        }

        [Fact]
        public void Article_Title_When_Empty_Throws()
        {
            const string title = "";

            Assert.Throws<ArgumentOutOfRangeException>(() => new Article(title, "2", "3", "4"));
        }

        [Fact]
        public void Article_Title_When_WhiteSpace_Throws()
        {
            const string title = " \t\r\n";

            Assert.Throws<ArgumentOutOfRangeException>(() => new Article(title, "2", "3", "4"));
        }

        [Fact]
        public void Article_AuthorNameWithTitles_When_Null_Throws()
        {
            const string authorNameWithTitles = "AuthorNameWithTitles";

            var article = new Article("1", authorNameWithTitles, "3", "4");

            Assert.Equal(authorNameWithTitles, article.AuthorNameWithTitles);
        }

        [Fact]
        public void Article_AuthorNameWithTitles_When_Empty_Throws()
        {
            const string authorNameWithTitles = "";

            Assert.Throws<ArgumentOutOfRangeException>(() => new Article("1", authorNameWithTitles, "3", "4"));
        }

        [Fact]
        public void Article_AuthorNameWithTitles_When_WhiteSpace_Throws()
        {
            const string authorNameWithTitles = " \t\r\n";

            Assert.Throws<ArgumentOutOfRangeException>(() => new Article("1", authorNameWithTitles, "3", "4"));
        }

        [Fact]
        public void Article_InputRelativePath_Successful_Initialization()
        {
            const string inputRelativePath = "InputRelativePath";

            var article = new Article("1", "2", inputRelativePath, "4");

            Assert.Equal(inputRelativePath, article.InputRelativePath);
        }

        [Fact]
        public void Article_InputRelativePath_When_Empty_Throws()
        {
            const string inputRelativePath = "";

            Assert.Throws<ArgumentOutOfRangeException>(() => new Article("1", "2", inputRelativePath, "4"));
        }

        [Fact]
        public void Article_InputRelativePath_When_WhiteSpace_Throws()
        {
            const string inputRelativePath = " \t\r\n";

            Assert.Throws<ArgumentOutOfRangeException>(() => new Article("1", "2", inputRelativePath, "4"));
        }

        [Fact]
        public void Article_InputFileName_Successful_Initialization()
        {
            const string inputFileName = "InputFileName";

            var article = new Article("1", "2", "3", inputFileName);

            Assert.Equal(inputFileName, article.InputFileName);
        }

        [Fact]
        public void Article_InputFileName_When_Empty_Throws()
        {
            const string inputFileName = "";

            Assert.Throws<ArgumentOutOfRangeException>(() => new Article("1", "2", "3", inputFileName));
        }

        [Fact]
        public void Article_InputFileName_When_WhiteSpace_Throws()
        {
            const string inputFileName = " \t\r\n";

            Assert.Throws<ArgumentOutOfRangeException>(() => new Article("1", "2", "3", inputFileName));
        }
    }
}