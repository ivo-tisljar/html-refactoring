
using HtmlRefactoringWindowsApp.Css;

namespace HtmlRefactoringWindowsApp.Refactoring
{
    public class Replacers
    {
        private const char csvSeparator = '█';      //  in replacers file, separator between individual replacers

        private List<Replacer> replacers;

        public int Count { get { return replacers.Count; } }

        public Replacer this[int index]
        {
            get { return replacers[index]; }
        }

        public Replacers(string replacersText)
        {
            replacers = new List<Replacer>();

            var replacersArray = replacersText.Split(csvSeparator);

            foreach (var replacerText in replacersArray)
            { 
                if (!string.IsNullOrWhiteSpace(replacerText))
                    replacers.Add(new Replacer(replacerText));
            }
        }
    }
}
