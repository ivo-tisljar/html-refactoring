namespace HtmlRefactoringWindowsApp.Css
{
    public class CssProperties
    {
        private List<CssProperty> properties;

        public CssProperty this[int index]
        {
            get { return properties[index]; }
        }

        public CssProperties(string propertiesText)
        {
            properties = new List<CssProperty>();
            ReadProperties(propertiesText);
        }

        public int Count()
        { 
            return properties.Count; 
        }

        //  function ReadProperties DOES NOT take quotes and apostrophes into considerations when spliting properitiesText, IT IS ACCEPTABLE!

            private void ReadProperties(string propertiesText)
            {
                var splitProperties = propertiesText.Split(';');

                foreach (var property in splitProperties)
                {
                    if (!string.IsNullOrWhiteSpace(property))
                        properties.Add(new CssProperty(property));
                }
            }
    }
}
