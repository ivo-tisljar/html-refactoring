using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTML_Refactoring_WinForm
{
    public class Article
    {
        public string Title { get; }                    

        public string AuthorNameWithTitles { get; }     

        public string InputRelativePath { get; }                                // relative path to the root directory of the Magazine 

        public string InputFileName { get; }

        private string ValidateNotNullAndNotWhiteSpace(string paramValue, string paramName)
        {
            if (paramValue == null)
            {
                throw new ArgumentNullException($"Invalid value! {paramName} is null.");
            }
            if (string.IsNullOrWhiteSpace(paramValue))
            {
                throw new ArgumentOutOfRangeException($"Invalid value! {paramName} is empty or contains only white-space character.");
            }
            return paramValue;
        }

        public Article(string title, string authorNameWithTitles, string inputRelativePath, string inputFileName)
        {
            Title = ValidateNotNullAndNotWhiteSpace(title, "Title");
            AuthorNameWithTitles = ValidateNotNullAndNotWhiteSpace(authorNameWithTitles, "AuthorNameWithTitles");
            InputRelativePath = ValidateNotNullAndNotWhiteSpace(inputRelativePath, "InputRelativePath");
            InputFileName = ValidateNotNullAndNotWhiteSpace(inputFileName, "InputFileName");
        }

        public string AuthorNameWithoutTitles()
        { 
            return AuthorNameWithTitles;
        }

    }
}