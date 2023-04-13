
using static HtmlRefactoringWindowsApp.Utils.StringUtils;

namespace HtmlRefactoringWindowsApp.Articles
{
    public class MagazineBrand
    {
        private const char csvSeparator = ';';

        private const int fieldsCount = 5;

        public int ID { get; }

        public int WebID { get; }

        public string Name { get; }

        public string Label { get; }

        public char LeadChar { get; }

        public MagazineBrand(string brand)
        {
            PreliminaryValidation(brand);
            var fields = brand.Split(csvSeparator, StringSplitOptions.TrimEntries);
            ID = InitID(fields[0]);
            WebID = InitWebID(fields[1]);
            Name = InitName(fields[2]);
            Label = InitLabel(fields[3]);
            LeadChar = InitLeadChar(fields[4]);
        }

            private static void PreliminaryValidation(string csvFields)
                {
                    if (string.IsNullOrWhiteSpace(csvFields))
                        throw new InvalidMagazineBrandException($"Error! Parameter '{csvFields}' contains only white space or is empty");

                    if (CountCharInString(csvSeparator, csvFields) + 1 != fieldsCount)
                        throw new InvalidMagazineBrandException($"Error! Parameter '{csvFields}' does not contains {fieldsCount} field values separated by semicolon");
                }

            private static int InitID(string field)
            {
                if (!IsNaturalNumberUpToMaxDigitsCount(field, 2))
                    throw new InvalidMagazineBrandException($"Error! Integer in range 1..99 expected, '{field}' is invalid value for ID");

                return int.Parse(field);
            }

            private static int InitWebID(string field)
            {
                if (!IsNaturalNumberUpToMaxDigitsCount(field, 3))
                    throw new InvalidMagazineBrandException($"Error! Integer in range 1..999 expected, '{field}' is invalid value for WebID");

                return int.Parse(field);
            }

            private static string InitName(string field)
            {
                if ((field.Length == 0) || !IsAsciiHrLettersOrSpace(field) || !IsAsciiHrLetterUpper(field[0]) || (field.Trim() != field))
                    throw new InvalidMagazineBrandException($"Error! One or more word is expected, first letter of name should be capitalized, allowed characters " + 
                                                            $"are letters of English & Croatian alphabet & space, name should be trimmed of leading and trailing " +
                                                            $"spaces, '{field}' is invalid value for Name");
                return field;
            }

            private static string InitLabel(string field)
            {
                if ((field.Length < 3) || (field.Length > 4) || !IsAsciiLetters(field) || !Char.IsAsciiLetterUpper(field[0]))
                    throw new InvalidMagazineBrandException($"Error! Three or four letter word is expected, first letter of label should be capitalized, allowed " +
                                                            $"characters are letters of English alphabet, '{field}' is invalid value for Label");
                return field;
            }

            private static char InitLeadChar(string field)
            {
                if ((field.Length != 1) || !Char.IsAsciiLetterUpper(field[0]))
                    throw new InvalidMagazineBrandException($"Error! One uppercase letter of English alphabet is expected, '{field}' is invalid value for LeadChar");

                return (field[0]);
            }
    }

    public class InvalidMagazineBrandException : Exception
    {
        public InvalidMagazineBrandException(string message) : base(message) { }
    }
}
