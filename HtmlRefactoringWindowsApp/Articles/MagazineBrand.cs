
using static HtmlRefactoringWindowsApp.Utils.StringUtils;

namespace HtmlRefactoringWindowsApp.Articles
{
    public class MagazineBrand
    {
        private const char csvSeparator = ';';

        private const int propertiesCount = 5;

        public int ID { get; }

        public int WebID { get; }

        public string Name { get; }

        public string Label { get; }

        public char LeadChar { get; }

        public MagazineBrand(string brand)
        {
            PreliminaryValidation(brand);
            var fields = brand.Split(csvSeparator);
            ID = InitID(fields[0]);
            WebID = InitWebID(fields[1]);
            Name = InitName(fields[2]);
            Label = InitLabel(fields[3]);
            LeadChar = InitLeadChar(fields[4]);
        }

        private static void PreliminaryValidation(string csvParameters)
            {
                if (string.IsNullOrWhiteSpace(csvParameters))
                    throw new MagazineBrandException($"Error! Parameter '{csvParameters}' contains only white space or is empty");

                if (CountCharInString(csvSeparator, csvParameters) + 1 != propertiesCount)
                    throw new MagazineBrandException($"Error! Parameter '{csvParameters}' does not contains {propertiesCount} field values separated by semicolon");
            }

            private static int InitID(string field)
            {
                return int.Parse(field);
            }

            private static int InitWebID(string field)
            {
                return int.Parse(field);
            }

            private static string InitName(string field)
            {
                return field;
            }

            private static string InitLabel(string field)
            {
                return field;
            }

            private static char InitLeadChar(string field)
            {
                return (field[0]);
            }
    }

    public class MagazineBrandException : Exception
    {
        public MagazineBrandException(string message) : base(message) { }
    }
}
