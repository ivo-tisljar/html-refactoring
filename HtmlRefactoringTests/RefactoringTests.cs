
using HtmlRefactoringWindowsApp.Refactoring;

using static Xunit.Assert;

namespace HtmlRefactoringTests
{
    public class RefactoringTests
    {
        #region ReplacerTests

        [Fact]
        public void WhenCreatingReplacer_WithEmptyOrWhiteSpaceArgument_Throws()
        {
            Throws<InvalidReplacerException>(() => new Replacer(" \t \r \n"));
        }

        [Fact]
        public void WhenCreatingReplacer_WithInvalidNumberOfFields_Throws()
        {
            Throws<InvalidReplacerException>(() => new Replacer("a;b"));
            Throws<InvalidReplacerException>(() => new Replacer("a;b;c;d"));
        }

        #endregion

        #region ScriptTests

        [Fact]
        public void WhenCreatingScript_WithEmptyOrWhiteSpaceArgument_Throws()
        {
            Throws<InvalidScriptException>(() => new Script(" \t \r \n"));
        }

        [Fact]
        public void WhenCreatingScript_WithInvalidNumberOfFields_Throws()
        {
            Throws<InvalidScriptException>(() => new Script("a;b;c;d;e;f;g;h;i;j"));
            Throws<InvalidScriptException>(() => new Script("a;b;c;d;e;f;g;h;i;j;k;l"));
        }

        #endregion
    }
}
