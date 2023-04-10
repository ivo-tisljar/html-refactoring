
using static HtmlRefactoringWindowsApp.Utils.StringUtils;

namespace HtmlRefactoringWindowsApp.Articles
{
    public class MagazineBrand
    {
        private const char csvSeparator = ';';

        private const int propertiesCount = 5;

        public MagazineBrand(string brand)
        {
            PreliminaryValidation(brand);
        }

            private static void PreliminaryValidation(string csvParameters)
            {
                if (string.IsNullOrWhiteSpace(csvParameters))
                    throw new MagazineBrandException($"Error! Parameter '{csvParameters}' contains only white space or is empty");

                if (CountCharInString(csvSeparator, csvParameters) + 1 != propertiesCount)
                    throw new MagazineBrandException($"Error! Parameter '{csvParameters}' does not contains {propertiesCount} field values separated by semicolon");
        }
    }

    public class MagazineBrandException : Exception
    {
        public MagazineBrandException(string message) : base(message) { }
    }
}
