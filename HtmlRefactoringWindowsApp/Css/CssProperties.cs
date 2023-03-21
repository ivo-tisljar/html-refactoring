using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HtmlRefactoringWindowsApp.Css
{
    public class CssProperties
    {
        private const char semicolon = ';';

        private List<CssProperty> properties;

        public CssProperties(string propertiesText)
        {
            properties = new List<CssProperty>();
            ReadProperties(propertiesText);
        }

        public CssProperty this[int index]
        {
            get { return properties[index]; }
        }

        public int Count()
        { 
            return properties.Count; 
        }

        //  function ReadProperties DOES NOT take quotes and apostrophes into considerations when spliting properitiesText, IT IS ACCEPTABLE!

        public void ReadProperties(string propertiesText)
        {
            var splitProperties = propertiesText.Split(semicolon);
            foreach (var property in splitProperties)
            {
                if (!string.IsNullOrWhiteSpace(property))
                {
                    properties.Add(new CssProperty(property));
                }
            }
        }
    }
}
