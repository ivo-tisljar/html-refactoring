
using HtmlRefactoringWindowsApp.Articles;
using HtmlRefactoringWindowsApp.Css;
using HtmlRefactoringWindowsApp.Refactoring;

using static Xunit.Assert;

namespace HtmlRefactoringTests
{
    public class RefactoringTests
    {
        #region ScriptTests

        [Fact]
        public void WhenCreatingScriptWithEmptyOrWhiteSpaceArgument_Throws()
        {
            Throws<InvalidScriptException>(() => new Script(" \t"));
        }

        [Fact]
        public void WhenCreatingScriptWithInvalidNumberOfParametersInCsvArgument_Throws()
        {
            Throws<InvalidScriptException>(() => new Script("a;b;c;d;e;f;g;h;i"));
            Throws<InvalidScriptException>(() => new Script("a;b;c;d;e;f;g;h;i;j;k"));
        }

        //[Fact]
        //public void WhenCreatingScriptWithInvalidSegment_Throws()
        //{
        //    Throws<InvalidScriptException>(() => new Script(""));
        //}

        #endregion
    }
}
