using HtmlRefactoringWindowsApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Title = StringUtils.ValidateNotEmptyOrWhiteSpace(title, "Title");
            AuthorNameWithTitles = StringUtils.ValidateNotEmptyOrWhiteSpace(authorNameWithTitles, "AuthorNameWithTitles");
            InputRelativePath = StringUtils.ValidateNotEmptyOrWhiteSpace(inputRelativePath, "InputRelativePath");
            InputFileName = StringUtils.ValidateNotEmptyOrWhiteSpace(inputFileName, "InputFileName");
        }

        public string AuthorNameWithoutTitles()
        {
            return StringUtils.StripTitlesFromName(AuthorNameWithTitles);
        }

    }
}