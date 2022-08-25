//using HtmlRefactoringWindowsApp;
using HtmlRefactoringConsole;

namespace HtmlRefactoringTests
{
    public class ArticleTests
    {
        [Fact]
        public void ArticleConstruction_Title_()
        {
            const string title = "Title";

            var article = new Article(title, "", "", "");

            Assert.Equal(title, article.Title);
        }
    }
}