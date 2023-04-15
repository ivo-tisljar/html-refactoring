
using static HtmlRefactoringWindowsApp.Utils.StringUtils;

namespace HtmlRefactoringWindowsApp.Refactoring
{
    public class Replacer
    {
        private const char csvSeparator = ';';

        private const int fieldsCount = 3;

        public Replacer(string csvFields) 
        {
            PreliminaryValidation(csvFields);

        }

            private static void PreliminaryValidation(string csvFields)
            {
                if (string.IsNullOrWhiteSpace(csvFields))
                    throw new InvalidReplacerException($"Error! Replacer '{csvFields}' contains only white space or is empty");

                if (CountCharInString(csvSeparator, csvFields) + 1 != fieldsCount)
                    throw new InvalidReplacerException($"Error! Replacer '{csvFields}' does not contains {fieldsCount} field values separated by semicolons");
            }
    }
    
    public class InvalidReplacerException : Exception
    {
        public InvalidReplacerException(string message) : base(message) { }
    }
}
