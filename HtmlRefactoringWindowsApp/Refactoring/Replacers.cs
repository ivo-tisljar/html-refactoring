
namespace HtmlRefactoringWindowsApp.Refactoring
{
    public class Replacers
    {
        private const char csvSeparator = '█';

        private int count = 0;

        public int Count { get { return count; } }

        public Replacers(string replacersText)
        {
            if (!string.IsNullOrWhiteSpace(replacersText))
            {
                var replacers = replacersText.Split(csvSeparator);

                foreach (var replacerText in replacers)
                { 
                var replacer = new Replacer(replacerText);
                count++;
                }
            }
        }
    }
}
