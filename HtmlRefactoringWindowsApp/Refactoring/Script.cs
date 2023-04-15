
using static HtmlRefactoringWindowsApp.Utils.StringUtils;

namespace HtmlRefactoringWindowsApp.Refactoring
{
    public class Script
    {
        private const char csvSeparator = ';';

        private const int fieldsCount = 11;

        public Script(string csvFields)
        {
            PreliminaryValidation(csvFields);
            var fields = csvFields.Split(csvSeparator, StringSplitOptions.TrimEntries);

            //            magazine-brand;segment;tag-comparer;tag-input;class-comparer;class-input;refactoring-method;tag-output;class-output;data;info
        }

            private static void PreliminaryValidation(string csvFields)
            {
                    if (string.IsNullOrWhiteSpace(csvFields))
                        throw new InvalidScriptException($"Error! Script '{csvFields}' contains only white space or is empty");

                    if (CountCharInString(csvSeparator, csvFields) + 1 != fieldsCount)
                        throw new InvalidScriptException($"Error! Script '{csvFields}' does not contains {fieldsCount} field values separated by semicolons");
            }
    }

    public class InvalidScriptException : Exception
    {
        public InvalidScriptException(string message) : base(message) { }
    }
}
