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

        private readonly string name;
        public string Name { get { return name; } }

        private readonly string value;
        public string Value { get { return value; } }

        public CssProperty(string property) 
        {
            var colonIndex = FetchColonIndex(property);
            name = InitPropertyName(property, colonIndex);
            value = InitPropertyValue(property, colonIndex);
        }

        private int FetchColonIndex(string property)
        {
            if (!property.Contains(Colon))
            {
                throw new MissingColonException($"Error! Property '{property}' does not contains colon '{Colon}'.");
            }
            return property.IndexOf(Colon);
        }

        private string InitPropertyName(string property, int colonIndex)
        {
            var reg = new Regex("^\\s*[a-zA-Z_-][0-9a-zA-Z_-]*\\s*$");

            if (!reg.IsMatch(property[..colonIndex]))
            {
                throw new InvalidPropertyNameException($"Error! Property '{property}' does not contain or has invalid property-name.");
            }
            return property[..colonIndex].Trim();
        }

        private string InitPropertyValue(string property, int colonIndex)
        {
            if (string.IsNullOrWhiteSpace(property[(colonIndex + 1)..]))
            {
                throw new MissingPropertyValueException($"Error! Property '{property}' does not contains property-value.");
            }
            return property[(colonIndex + 1)..].Trim();
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
