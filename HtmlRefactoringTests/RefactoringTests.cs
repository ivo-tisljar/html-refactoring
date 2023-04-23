
using HtmlRefactoringWindowsApp.Css;
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
            Throws<InvalidFieldCountInReplacerException>(() => new Replacer("a║b║c"));
            Throws<InvalidFieldCountInReplacerException>(() => new Replacer("a║b║c║d║e"));
        }

        [Fact]
        public void WhenCreatingReplacer_IfReplacerMethodIsInvalid_Throws()
        {
            Throws<InvalidReplacerMethodException>(() => new Replacer("a║b║c║d"));
            Throws<InvalidReplacerMethodException>(() => new Replacer("text║b║c║d"));
        }

        [Fact]
        public void WhenCreatingReplacer_IfOldValueInvalid_Throws()
        {
            Throws<InvalidOldValueException>(() => new Replacer("Text║║c║d"));
            Throws<InvalidOldValueException>(() => new Replacer("Regex║║c║d"));
        }

        [Fact]
        public void AfterCreatingReplacer_CanRead_AllIndividualFields()
        {
            var replacer1 = new Replacer("Text║Bravo║Charlie║");

            Equal(ReplacerMethod.Text, replacer1.ReplacerMethod);
            Equal("Bravo", replacer1.OldValue);
            Equal("Charlie", replacer1.NewValue);
            Equal("", replacer1.Info);

            var replacer2 = new Replacer("Text║&#160;║ ║Non-breaking space");

            Equal(ReplacerMethod.Text, replacer2.ReplacerMethod);
            Equal("&#160;", replacer2.OldValue);
            Equal(" ", replacer2.NewValue);
            Equal("Non-breaking space", replacer2.Info);

            var replacer3 = new Replacer("Text║one\ttwo\r\nthree║one two three║Tabs and line breaks beside plain text");

            Equal(ReplacerMethod.Text, replacer3.ReplacerMethod);
            Equal("one\ttwo\r\nthree", replacer3.OldValue);
            Equal("one two three", replacer3.NewValue);
            Equal("Tabs and line breaks beside plain text", replacer3.Info);

            var replacer4 = new Replacer("Regex║(09\\d)(\\d{3})(\\d{3,4})║$1/$2-$3║Regular expression");

            Equal(ReplacerMethod.Regex, replacer4.ReplacerMethod);
            Equal("(09\\d)(\\d{3})(\\d{3,4})", replacer4.OldValue);
            Equal("$1/$2-$3", replacer4.NewValue);
            Equal("Regular expression", replacer4.Info);
        }

        [Fact]
        public void AfterCreatingReplacer_WithTextMethod_ReplaceAsExpected()
        {
            var replacer1 = new Replacer("Text║Bravo║Charlie║");

            Equal("Alpha Charlie Charlie", replacer1.Replace("Alpha Bravo Charlie"));

            var replacer2 = new Replacer("Text║&#160;║ ║Non-breaking space");

            Equal("One   two   three", replacer2.Replace("One &#160; two &#160; three"));

            var replacer3 = new Replacer("Text║  ║ ║Replace two consecutive space chars with single one");

            Equal("One  two  three", replacer3.Replace("One   two   three"));

            var replacer4 = new Replacer("Text║\r\n║ ║Replace CrLf with single space char");

            Equal("One two three", replacer4.Replace("One\r\ntwo\r\nthree"));

        }

        [Fact]
        public void AfterCreatingReplacer_WithRegexMethod_ReplaceAsExpected()
        {
            var replacer1 = new Replacer("Regex║(09\\d)(\\d{3})(\\d{3,4})║$1/$2-$3║Phone number");

            Equal("098/765-432", replacer1.Replace("098765432"));

            var replacer2 = new Replacer("Regex║(09\\d)(\\d{3})(\\d{3,4})║$1/$2-$3║Phone number");

            Equal("091/234-5678\n092/345-678", replacer2.Replace("0912345678\n092345678"));
            Equal("012345678\n097/654-3210", replacer2.Replace("012345678\n0976543210"));
            Equal("098765-43210 xyz 099/888-777 abc", replacer2.Replace("098765-43210 xyz 099888777 abc"));
        }

        #endregion

        #region ReplacersTests

        [Fact]
        public void AfterCreatingReplacers_CountOfReplacers_IsZero()
        {
            Equal(0, new Replacers("").Count);
        }

        [Fact]
        public void WhenCreatingReplacers_IfAnyOfIndividualReplacersIsInvalid_Throws()
        {
            ThrowsAny<InvalidReplacerException>(() => new Replacers("a║b║c"));
            ThrowsAny<InvalidReplacerException>(() => new Replacers("RegEx║a║b║c"));
        }

        [Fact]
        public void AfterCreatingReplacers_WithOneReplacer_CountOfReplacersIsOne()
        {
            Equal(1, new Replacers("Text║X║║").Count);
        }

        [Fact]
        public void AfterCreatingReplacers_WithTwoReplacers_CountOfReplacersIsTwo()
        {
            Equal(2, new Replacers("Text║X║║█Regex║Y║║").Count);
        }

        [Fact]
        public void AfterCreatingReplacers_CanIndex_IndividualReplacers()
        {
            Equal("Regex", new Replacers("Text║X║║█Regex║Y║║")[1].ReplacerMethod.ToString());
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
