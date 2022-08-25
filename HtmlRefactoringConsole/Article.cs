using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlRefactoringConsole.Utils;

namespace HtmlRefactoringConsole
{
    public class Article
    {
        public string Title { get; }

        public string AuthorNameWithTitles { get; }

        public string InputRelativePath { get; }                                // relative path to the root directory of the Magazine 

        public string InputFileName { get; }

        public Article(string title, string authorNameWithTitles, string inputRelativePath, string inputFileName)
        {
            Title = StringUtils.ValidateNotWhiteSpace(title, "Title");
            AuthorNameWithTitles = StringUtils.ValidateNotWhiteSpace(authorNameWithTitles, "AuthorNameWithTitles");
            InputRelativePath = StringUtils.ValidateNotWhiteSpace(inputRelativePath, "InputRelativePath");
            InputFileName = StringUtils.ValidateNotWhiteSpace(inputFileName, "InputFileName");
        }

        public string AuthorNameWithoutTitles()
        {
            return AuthorNameWithTitles;
        }

    }
}
