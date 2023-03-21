namespace HtmlRefactoringWindowsApp.Css
{
    public class CssProperty
    {
        private const char colon = ':';

        public string Name { get; }

        public string Value { get; }

        public CssProperty(string property)
        {
            var colonIndex = property.IndexOf(colon);
            if (colonIndex < 0)
            {
                throw new MissingColonException($"Error! Property '{property}' does not contain colon '{colon}'.");
            }

            var name = property.Substring(0, colonIndex).Trim();
            if (!IsValidPropertyName(name))
            {
                throw new InvalidPropertyNameException($"Error! Property '{property}' contains invalid property name '{name}'.");
            }
            Name = name;

            var value = property.Substring(colonIndex + 1).Trim();
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new MissingPropertyValueException($"Error! Property '{property}' does not contain property value.");
            }
            Value = value;
        }

        private bool IsValidPropertyName(string name)
        {
            // Property name can start with a letter, underscore, or hyphen, followed by letters, digits, underscores, or hyphens.
            // Reference: https://www.w3.org/TR/CSS21/syndata.html#value-def-identifier
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }
            if (!char.IsLetter(name[0]) && name[0] != '_' && name[0] != '-')
            {
                return false;
            }
            for (int i = 1; i < name.Length; i++)
            {
                if (!char.IsLetterOrDigit(name[i]) && name[i] != '_' && name[i] != '-')
                {
                    return false;
                }
            }
            return true;
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
