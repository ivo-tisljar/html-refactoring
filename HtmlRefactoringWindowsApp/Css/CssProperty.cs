using System.Text.RegularExpressions;

namespace HtmlRefactoringWindowsApp.Css
{
    public class CssProperty
    {
        private const char Colon = ':';

        public string Name { get; }

        public string Value { get; }

        public CssProperty(string property)
        {
            var colonIndex = FetchColonIndex(property);
            Name = InitPropertyName(property[..colonIndex].Trim());
            Value = InitPropertyValue(property[(colonIndex + 1)..].Trim());
        }

        private int FetchColonIndex(string property)
        {
            if (!property.Contains(Colon))
            {
                throw new MissingColonException($"Error! Property '{property}' does not contains colon '{Colon}'.");
            }
            return property.IndexOf(Colon);
        }

        //  Constructor CssProperty with RegEx is 5 times slower (200.000 properties/sec) than version with if & for-loop validation function

        private string InitPropertyName(string propertyName)
        {
            var reg = new Regex("^[a-zA-Z_-][0-9a-zA-Z_-]*$");

            if (!reg.IsMatch(propertyName))
            {
                throw new InvalidPropertyNameException($"Error! Property '{propertyName}' does not contain or has invalid property-name.");
            }
            return propertyName;
        }

        private string InitPropertyValue(string propertyValue)
        {
            if (string.IsNullOrWhiteSpace(propertyValue))
            {
                throw new MissingPropertyValueException($"Error! Property '{propertyValue}' does not contains property-value.");
            }
            return propertyValue;
        }
    }

    public class CssPropertyException : Exception
    {
        public CssPropertyException(string message) : base(message)
        {
        }
    }

    public class MissingColonException : CssPropertyException
    {
        public MissingColonException(string message) : base(message)
        {
        }
    }

    public class InvalidPropertyNameException : CssPropertyException
    {
        public InvalidPropertyNameException(string message) : base(message)
        {
        }
    }

    public class MissingPropertyValueException : CssPropertyException
    {
        public MissingPropertyValueException(string message) : base(message)
        {
        }
    }
}
