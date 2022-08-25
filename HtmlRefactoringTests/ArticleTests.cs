using HtmlRefactoringWindowsApp;
//using HtmlRefactoringConsole;

namespace HtmlRefactoringTests
{
    public class ArticleTests
    {
        [Fact]
        public void ArticleConstruction_Title_()
        {
            const string title = "Title";
            const string authorNameWithTitles = "AuthorNameWithTitles";
            const string inputRelativePath = "InputRelativePath";
            const string inputFileName = "InputFileName";

            var article = new Article(title, authorNameWithTitles, inputRelativePath, inputFileName);

            Assert.Equal(title, article.Title);
        }
    }
}