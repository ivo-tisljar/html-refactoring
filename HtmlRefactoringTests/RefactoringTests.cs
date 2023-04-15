
using HtmlRefactoringWindowsApp.Articles;
using HtmlRefactoringWindowsApp.Css;
using HtmlRefactoringWindowsApp.Refactoring;

using static Xunit.Assert;

namespace HtmlRefactoringTests
{
    public class RefactoringTests
    {
        #region ReplacerTests

        [Fact]
        public void CanCreateReplacer()
        {
            var replacer = new Replacer("");
        }

        #endregion

        #region ScriptTests

        [Fact]
        public void WhenCreatingScript_WithEmptyOrWhiteSpaceArgument_Throws()
        {
            Throws<InvalidScriptException>(() => new Script(" \t"));
        }

        [Fact]
        public void WhenCreatingScript_WithInvalidNumberOfCSVs_Throws()
        {
            Throws<InvalidScriptException>(() => new Script("a;b;c;d;e;f;g;h;i;j"));
            Throws<InvalidScriptException>(() => new Script("a;b;c;d;e;f;g;h;i;j;k;l"));
        }

        #endregion
    }
}
