
using HtmlRefactoringWindowsApp.Enums;
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
            OldValue = fields[1];
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
                    return str;
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
}
