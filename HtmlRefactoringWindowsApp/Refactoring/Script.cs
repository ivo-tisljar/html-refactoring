
namespace HtmlRefactoringWindowsApp.Refactoring
{
    public class Script
    {
        private const int fieldCount = 1;

        public Script(string script)
        {
            var fields = script.Split(';');
            //Validate

            //            magazine-brand;segment;tag-comparer;tag-input;class-comparer;class-input;conversion;tag-output;class-output;data;info
            //            
            //            
        }
    }

    public class InvalidScriptException : Exception
    {
        public InvalidScriptException(string message) : base(message) { }
    }
}
