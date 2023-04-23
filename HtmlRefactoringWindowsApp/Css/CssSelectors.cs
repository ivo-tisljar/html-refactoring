
namespace HtmlRefactoringWindowsApp.Css
{
    public class CssSelectors
    {
        private const char csvSeparator = ',';      // in CSS rule, separator of multiple selectors

        public List<CssSelector> selectors;

        public int Count 
        {
            get { return selectors.Count; }
        }

        public CssSelector this[int index]
        {
            get { return selectors[index]; }
        }

        public CssSelectors(string selectorsText)
        {
            selectors = new List<CssSelector>();
            ExtractSelectors(selectorsText);
        }

            private void ExtractSelectors(string selectorsText)
            {
                var splitSelectors = selectorsText.Split(csvSeparator);
            
                foreach (var selector in splitSelectors) 
                { 
                    if (!string.IsNullOrWhiteSpace(selector))
                        selectors.Add(new CssSelector(selector));
                }
            }
    }
}
