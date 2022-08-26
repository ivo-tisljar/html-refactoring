using HtmlRefactoringConsole;
using HtmlRefactoringConsole.Utils;

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

        [Fact]
        public void Article_AuthorNameWithoutTitles_Nada()
        {
            const string nameWithTitles = "Mr. sc. Nada DREMEL, dipl. oec., ovl. raè. i ovl. por. savj.";
            const string nameWithoutTitles = "Nada DREMEL";

            string nameStripedOfTitles = StringUtils.StripTitlesFromName(nameWithTitles);

            Assert.Equal(nameStripedOfTitles, nameWithoutTitles);
        }

        [Fact]
        public void Article_AuthorNameWithoutTitles_Ivan()
        {
            const string nameWithTitles = "Priredio: Ivan PETARÈIÆ, struè. spec. oec.";
            const string nameWithoutTitles = "Ivan PETARÈIÆ";

            string nameStripedOfTitles = StringUtils.StripTitlesFromName(nameWithTitles);

            Assert.Equal(nameStripedOfTitles, nameWithoutTitles);
        }

        [Fact]
        public void Article_AuthorNameWithoutTitles_Anamarija()
        {
            const string nameWithTitles = "Anamarija WAGNER, dipl. oec., ovl. rev. i ACCA";
            const string nameWithoutTitles = "Anamarija WAGNER";

            string nameStripedOfTitles = StringUtils.StripTitlesFromName(nameWithTitles);

            Assert.Equal(nameStripedOfTitles, nameWithoutTitles);
        }

        [Fact]
        public void Article_AuthorNameWithoutTitles_Tamara()
        {
            const string nameWithTitles = "Dr. sc. Tamara CIRKVENI FILIPOVIÆ, glavna urednica";
            const string nameWithoutTitles = "Tamara CIRKVENI FILIPOVIÆ";

            string nameStripedOfTitles = StringUtils.StripTitlesFromName(nameWithTitles);

            Assert.Equal(nameStripedOfTitles, nameWithoutTitles);
        }

        [Fact]
        public void Article_AuthorNameWithoutTitles_Marijana()
        {
            const string nameWithTitles = "Marijana RADUSIN LIPOŠINOVIÆ, dipl. oec., univ. spec. oec. i ovl. raè.";
            const string nameWithoutTitles = "Marijana RADUSIN LIPOŠINOVIÆ";

            string nameStripedOfTitles = StringUtils.StripTitlesFromName(nameWithTitles);

            Assert.Equal(nameStripedOfTitles, nameWithoutTitles);
        }

        [Fact]
        public void Article_AuthorNameWithoutTitles_Vinko()
        {
            const string nameWithTitles = "Prof. dr. sc. Vinko BELAK";
            const string nameWithoutTitles = "Vinko BELAK";

            string nameStripedOfTitles = StringUtils.StripTitlesFromName(nameWithTitles);

            Assert.Equal(nameStripedOfTitles, nameWithoutTitles);
        }

        [Fact]
        public void Article_AuthorNameWithoutTitles_Jasna()
        {
            const string nameWithTitles = "Jasna VUK, dipl. oec. i ovl. raè.*";
            const string nameWithoutTitles = "Jasna VUK";

            string nameStripedOfTitles = StringUtils.StripTitlesFromName(nameWithTitles);

            Assert.Equal(nameStripedOfTitles, nameWithoutTitles);
        }

        [Fact]
        public void Article_AuthorNameWithoutTitles_Tamara_2()
        {
            const string nameWithTitles = "Dr. sc. Tamara CIRKVENI FILIPOVIÆ, prof. v. šk. i ovl. raè.";
            const string nameWithoutTitles = "Tamara CIRKVENI FILIPOVIÆ";

            string nameStripedOfTitles = StringUtils.StripTitlesFromName(nameWithTitles);

            Assert.Equal(nameStripedOfTitles, nameWithoutTitles);
        }
    }
}