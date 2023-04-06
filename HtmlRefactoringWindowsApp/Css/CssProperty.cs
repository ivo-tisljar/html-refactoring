
using System.Text.RegularExpressions;

namespace HtmlRefactoringWindowsApp.Css

//  We are using simplified syntax for CSS properties, validation rules covers all use cases that we face
{
    public class CssProperty
    {
        public string Name { get; }

        public string Value { get; }

        public CssProperty(string property)
        {
            var colonIndex = FetchColonIndex(property);
            Name = InitPropertyName(property, property[..colonIndex].Trim());
            Value = InitPropertyValue(property, property[(colonIndex + 1)..].Trim());
        }

            private static int FetchColonIndex(string property)
            {
                if (!property.Contains(':'))
                    throw new MissingColonException($"Error! Property '{property}' does not contains colon ':'.");

                return property.IndexOf(':');
            }

            //  Constructor CssProperty with RegEx is 5 times slower (200.000 properties/sec) than version with if & for-loop validation function

            private static string InitPropertyName(string property, string propertyName)
            {
                var reg = new Regex("^[a-zA-Z_-][0-9a-zA-Z_-]*$");

                if (!reg.IsMatch(propertyName))
                    throw new InvalidPropertyNameException($"Error! Property '{property}' does not contain or has invalid property-name.");

                return propertyName;
            }

            private static string InitPropertyValue(string property, string propertyValue)
            {
                if (string.IsNullOrWhiteSpace(propertyValue))
                    throw new MissingPropertyValueException($"Error! Property '{property}' does not contains property-value.");

                return propertyValue;
            }
    }

    public class CssPropertyException : Exception
    {
        public CssPropertyException(string message) : base(message) {}
    }

    public class MissingColonException : CssPropertyException
    {
        public MissingColonException(string message) : base(message) {}
    }

    public class InvalidPropertyNameException : CssPropertyException
    {
        public InvalidPropertyNameException(string message) : base(message) {}
    }

    public class MissingPropertyValueException : CssPropertyException
    {
        public MissingPropertyValueException(string message) : base(message) {}
    }
}
