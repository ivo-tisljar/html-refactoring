using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace HtmlRefactoringWindowsApp.Css
{
    public class CssProperty
    {
        private const char Colon = ':';

        //public string PropertyName { get; set; }

        //public string PropertyValue { get; set; }

        public CssProperty(string property) 
        {
            var colonIndex = FetchColonIndex(property);
            VerifyPropertyName(property, colonIndex);
            VerifyPropertyValue(property, colonIndex);
        }

        private int FetchColonIndex(string property)
        {
            if (!property.Contains(Colon))
            {
                throw new MissingColonException($"Invalid value! Property '{property}' does not contains colon '{Colon}'.");
            }
            return property.IndexOf(Colon);
        }

        private void VerifyPropertyName(string property, int colonIndex)
        {
            var reg = new Regex("^[a-zA-Z_-][0-9a-zA-Z_-]*\\s*$");

            if (!reg.IsMatch(property[..colonIndex]))
            {
                throw new InvalidPropertyNameException($"Invalid value! Property '{property}' has invalid property-name.");
            }
            //return property[..colonIndex];
        }

        private void VerifyPropertyValue(string property, int colonIndex)
        {
            if (string.IsNullOrWhiteSpace(property[(colonIndex + 1)..]))
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
    public class InvalidPropertyNameException : Exception
    {
        public InvalidPropertyNameException(string message) : base(message)
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
