
namespace HtmlRefactoringWindowsApp.Refactoring
{
    public class Replacers
    {
        private int count = 0;

        public int Count { get { return count; } }

        public Replacers(string replacersText)
        {
            if (!string.IsNullOrWhiteSpace(replacersText))
            {
                var replacer = new Replacer(replacersText);
                count = 1;
            }
        }
    }
}
