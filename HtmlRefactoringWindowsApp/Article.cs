using HtmlRefactoringWindowsApp.Utils;
using static HtmlRefactoringWindowsApp.Utils.StringUtils;

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
            Title = ValidateIsNotEmptyAndIsNotWhiteSpace(title, "Title");
            AuthorNameWithTitles = ValidateIsNotEmptyAndIsNotWhiteSpace(authorNameWithTitles, "AuthorNameWithTitles");
            InputRelativePath = ValidateIsNotEmptyAndIsNotWhiteSpace(inputRelativePath, "InputRelativePath");
            InputFileName = ValidateIsNotEmptyAndIsNotWhiteSpace(inputFileName, "InputFileName");
        }

        public string AuthorNameWithoutTitles()
        {
            return StripTitlesFromName(AuthorNameWithTitles);
        }

    }
}