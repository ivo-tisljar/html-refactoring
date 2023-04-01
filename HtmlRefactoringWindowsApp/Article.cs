using HtmlRefactoringWindowsApp.Utils;

namespace HtmlRefactoringWindowsApp
{
    public class Article
    {
        public string Title { get; }

        public string AuthorNameWithTitles { get; }

        public string InputRelativePath { get; }                                // relative path to the root directory of the Magazine 

        public string InputFileName { get; }

        public Article(string title, string authorNameWithTitles, string inputRelativePath, string inputFileName)
        {
            Title = StringUtils.ValidateIsNotEmptyAndIsNotWhiteSpace(title, "Title");
            AuthorNameWithTitles = StringUtils.ValidateIsNotEmptyAndIsNotWhiteSpace(authorNameWithTitles, "AuthorNameWithTitles");
            InputRelativePath = StringUtils.ValidateIsNotEmptyAndIsNotWhiteSpace(inputRelativePath, "InputRelativePath");
            InputFileName = StringUtils.ValidateIsNotEmptyAndIsNotWhiteSpace(inputFileName, "InputFileName");
        }

        public string AuthorNameWithoutTitles()
        {
            return StringUtils.StripTitlesFromName(AuthorNameWithTitles);
        }

    }
}