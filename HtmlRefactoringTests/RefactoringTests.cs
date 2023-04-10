
using HtmlRefactoringWindowsApp.Css;
using HtmlRefactoringWindowsApp.Refactoring;

using static Xunit.Assert;

namespace HtmlRefactoringTests
{
    public class RefactoringTests
    {
        #region ScriptTests

        [Fact]
        public void CanCreateScript()
        {
            var script = new Script("");
        }

        //[Fact]
        //public void WhenCreatingScriptWithInvalidSegment_Throws()
        //{
        //    Throws<InvalidScriptException>(() => new Script(""));
        //}

        #endregion
    }
}
