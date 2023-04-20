
using HtmlRefactoringWindowsApp.Enums;
using System.Text.RegularExpressions;
using static HtmlRefactoringWindowsApp.Utils.StringUtils;

namespace HtmlRefactoringWindowsApp.Refactoring
{
    public class Replacer
    {
        private const char csvSeparator = '\0';

        private const int fieldsCount = 4;

        public ReplacerMethod ReplacerMethod { get; }

        public string OldValue { get; }

        public string NewValue { get; }

        public string Info { get; }

        public Replacer(string csvFields) 
        {
            PreliminaryValidation(csvFields);
            var fields = csvFields.Split(csvSeparator);
            ReplacerMethod = InitReplacerMethod(fields[0]);
            OldValue = InitOldValue(fields[1]);
            NewValue = fields[2];
            Info = fields[3];
        }

        public string Replace(string str)
        {
            switch (ReplacerMethod)
            {
                case ReplacerMethod.Text:
                    return str.Replace(OldValue, NewValue);

                case ReplacerMethod.Regex:
                    return new Regex(OldValue).Replace(str, NewValue);
            }

            return str;
        }

            private static void PreliminaryValidation(string csvFields)
                {
                    if (string.IsNullOrWhiteSpace(csvFields))
                        throw new ReplacerIsEmptyException($"Error! Replacer '{csvFields}' contains only white space or is empty");

                    if (CountCharInString(csvSeparator, csvFields) + 1 != fieldsCount)
                        throw new InvalidFieldCountInReplacerException($"Error! Replacer '{csvFields}' does not contains {fieldsCount} field values separated by semicolons");
                }

            private static ReplacerMethod InitReplacerMethod(string field)
            {
                try
                {
                    return field.ToReplacerMethod();
                }
                catch (Exception Ex)
                {
                    throw new InvalidReplacerMethodException($"Error! '{field}' is invalid value for replacer-method\r\n" + Ex);
                }
            }

            private static string InitOldValue(string field)
            {
                if (field == "")
                    throw new InvalidOldValueException($"Error! Old value of replacer is empty");

                return field;
            }
    }

    public class InvalidReplacerException : Exception
    {
        public InvalidReplacerException(string message) : base(message) { }
    }

    public class ReplacerIsEmptyException : InvalidReplacerException
    {
        public ReplacerIsEmptyException(string message) : base(message) { }
    }

    public class InvalidFieldCountInReplacerException : InvalidReplacerException
    {
        public InvalidFieldCountInReplacerException(string message) : base(message) { }
    }

    public class InvalidReplacerMethodException : InvalidReplacerException
    {
        public InvalidReplacerMethodException(string message) : base(message) { }
    }

    public class InvalidOldValueException : InvalidReplacerException
    {
        public InvalidOldValueException(string message) : base(message) { }
    }
}
