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

        //public string PropertyName { get; set; }

        //public string PropertyValue { get; set; }

        public CssProperty(string property) 
        {
            var colonIndex = GetColonIndex(property);
            ExtractPropertyName(property, colonIndex);
            VerifyPropertyValue(property, colonIndex);
        }

        private int GetColonIndex(string property)
        {
            if (!property.Contains(Colon))
            {
                throw new MissingColonException($"Invalid value! Property '{property}' does not contains colon '{Colon}'.");
            }
            return property.IndexOf(Colon);
        }

        private void ExtractPropertyName(string property, int colonIndex)
        {
            if ((colonIndex == 0) || (string.IsNullOrWhiteSpace(property.Substring(0, colonIndex))))
            {
                throw new MissingPropertyNameException($"Invalid value! Property '{property}' does not contains property-name.");
            }
            //return property.Substring(0, colonIndex);
        }

        private void VerifyPropertyValue(string property, int colonIndex)
        {
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
