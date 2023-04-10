using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlRefactoringWindowsApp.Articles
{
    public class MagazineBrand
    {
        public MagazineBrand(string brand)
        {
            if (string.IsNullOrWhiteSpace(brand))
            {
                throw new MagazineBrandException("Error! ");
            }

        }
    }

    public class MagazineBrandException : Exception
    {
        public MagazineBrandException(string message) : base(message) { }
    }
}
