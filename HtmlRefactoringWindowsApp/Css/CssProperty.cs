using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlRefactoringWindowsApp.Css
{
    public class CssProperty
    {
        private const char Colon = ':';

        public CssProperty(string property) 
        {
            VerifyColon(property);
            VerifyPropertyName(property);
            VerifyPropertyValue(property);
        }

        private void VerifyColon(string property)
        {
            if (!property.Contains(Colon))
            {
                throw new MissingColonException($"Invalid value! Property '{property}' does not contains colon '{Colon}'.");
            }
        }

        private void VerifyPropertyName(string property)
        {
            var colonIndex = property.IndexOf(Colon);

            if ((colonIndex == 0) || (string.IsNullOrWhiteSpace(property.Substring(0, colonIndex))))
            {
                throw new MissingPropertyNameException($"Invalid value! Property '{property}' does not contains property-name.");
            }
        }

        private void VerifyPropertyValue(string property)
        {
            var colonIndex = property.IndexOf(Colon);

            if (string.IsNullOrWhiteSpace(property.Substring(colonIndex + 1)))
            {
                throw new MissingPropertyValueException($"Invalid value! Property '{property}' does not contains property-value.");
            }
        }
    }
    public class MissingColonException : Exception
    {
        public MissingColonException(string message) : base(message)
        {
        }
    }
    public class MissingPropertyNameException : Exception
    {
        public MissingPropertyNameException(string message) : base(message)
        {
        }
    }
    public class MissingPropertyValueException : Exception
    {
        public MissingPropertyValueException(string message) : base(message)
        {
        }
    }
}
