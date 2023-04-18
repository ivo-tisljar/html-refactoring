
using HtmlRefactoringWindowsApp.Enums;
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
            Throws<ReplacerIsEmptyException>(() => new Replacer(" \t \r \n"));
        }

        [Fact]
        public void WhenCreatingReplacer_WithInvalidNumberOfFields_Throws()
        {
            Throws<InvalidFieldCountInReplacerException>(() => new Replacer("a\0b\0c"));
            Throws<InvalidFieldCountInReplacerException>(() => new Replacer("a\0b\0c\0d\0e"));
        }

        [Fact]
        public void WhenCreatingReplacer_IfReplacerMethodIsInvalid_Throws()
        {
            Throws<InvalidReplacerMethodException>(() => new Replacer("a\0b\0c\0d"));
            Throws<InvalidReplacerMethodException>(() => new Replacer("text\0b\0c\0d"));
        }

        [Fact]
        public void WhenCreatingReplacer_IfOldValueInvalid_Throws()
        {
            Throws<InvalidOldValueException>(() => new Replacer("Text\0\0c\0d"));
            Throws<InvalidOldValueException>(() => new Replacer("Regex\0\0c\0d"));
        }

        [Fact]
        public void AfterCreatingReplacer_CanRead_AllIndividualFields()
        {
            var replacer1 = new Replacer("Text\0Bravo\0Charlie\0");

            Equal(ReplacerMethod.Text, replacer1.ReplacerMethod);
            Equal("Bravo", replacer1.OldValue);
            Equal("Charlie", replacer1.NewValue);
            Equal("", replacer1.Info);

            var replacer2 = new Replacer("Text\0&#160;\0 \0Non-breaking space");

            Equal(ReplacerMethod.Text, replacer2.ReplacerMethod);
            Equal("&#160;", replacer2.OldValue);
            Equal(" ", replacer2.NewValue);
            Equal("Non-breaking space", replacer2.Info);

            var replacer3 = new Replacer("Text\0one\ttwo\r\nthree\0one two three\0Tabs and line breaks beside plain text");

            Equal(ReplacerMethod.Text, replacer3.ReplacerMethod);
            Equal("one\ttwo\r\nthree", replacer3.OldValue);
            Equal("one two three", replacer3.NewValue);
            Equal("Tabs and line breaks beside plain text", replacer3.Info);

            var replacer4 = new Replacer("Regex\0(09\\d)(\\d{3})(\\d{3,4})\0$1/$2-$3\0Regular expression");

            Equal(ReplacerMethod.Regex, replacer4.ReplacerMethod);
            Equal("(09\\d)(\\d{3})(\\d{3,4})", replacer4.OldValue);
            Equal("$1/$2-$3", replacer4.NewValue);
            Equal("Regular expression", replacer4.Info);
        }

        [Fact]
        public void AfterCreatingReplacer_WithTextMethod_ReplaceAsExpected()
        {
            var replacer1 = new Replacer("Text\0Bravo\0Charlie\0");

            Equal("Alpha Charlie Charlie", replacer1.Replace("Alpha Bravo Charlie"));

            var replacer2 = new Replacer("Text\0&#160;\0 \0Non-breaking space");

            Equal("One   two   three", replacer2.Replace("One &#160; two &#160; three"));

            var replacer3 = new Replacer("Text\0  \0 \0Replace two consecutive space chars with single one");

            Equal("One  two  three", replacer3.Replace("One   two   three"));

            var replacer4 = new Replacer("Text\0\r\n\0 \0Replace CrLf with single space char");

            Equal("One two three", replacer4.Replace("One\r\ntwo\r\nthree"));

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
