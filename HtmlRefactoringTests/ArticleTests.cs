
using HtmlRefactoringWindowsApp;
using static Xunit.Assert;

namespace HtmlRefactoringTests
{
    public class ArticleTests
    {
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
    }
}
