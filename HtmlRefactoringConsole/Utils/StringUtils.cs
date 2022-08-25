using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlRefactoringConsole.Utils
{
    internal class StringUtils
    {
        public static string ValidateNotWhiteSpace(string paramValue, string paramName)
        {
            if (string.IsNullOrWhiteSpace(paramValue))
            {
                throw new ArgumentOutOfRangeException($"Invalid value! {paramName} is empty or contains only white-space character.");
            }
            return paramValue;
        }
    }
}
