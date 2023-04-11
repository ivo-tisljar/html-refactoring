
using static HtmlRefactoringWindowsApp.Utils.StringUtils;

namespace HtmlRefactoringWindowsApp.Articles
{
    public class Article
    {
        public string Title { get; }

        public string AuthorNameWithTitles { get; }

        public string InputRelativePath { get; }                                // relative path to the root directory of the Magazine 

        public string InputFileName { get; }

        public Article(string title, string authorNameWithTitles, string inputRelativePath, string inputFileName)
        {
            Title = ValidateIsNotEmptyNorWhiteSpace(title, "Title");
            AuthorNameWithTitles = ValidateIsNotEmptyNorWhiteSpace(authorNameWithTitles, "AuthorNameWithTitles");
            InputRelativePath = ValidateIsNotEmptyNorWhiteSpace(inputRelativePath, "InputRelativePath");
            InputFileName = ValidateIsNotEmptyNorWhiteSpace(inputFileName, "InputFileName");
        }

        public string AuthorNameWithoutTitles()
        {
            return StripTitlesFromName(AuthorNameWithTitles);
        }

    }
}
