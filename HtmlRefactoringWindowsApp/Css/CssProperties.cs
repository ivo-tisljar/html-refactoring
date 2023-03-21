using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlRefactoringWindowsApp.Css
{
    public class CssProperties
    {
        public CssProperties(string properties)
        {
            if (!string.IsNullOrWhiteSpace(properties))
            {
                var property = new CssProperty(properties);
            }
        }

        public int Count()
        { 
            return 0; 
        }
    }
}
