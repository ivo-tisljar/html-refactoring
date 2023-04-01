using HtmlRefactoringWindowsApp.Utils;
using static Xunit.Assert;
using static HtmlRefactoringWindowsApp.Utils.StringUtils;

namespace HtmlRefactoringTests
{
    public class StringUtilsTests
    {
        [Fact]
        public void SplitAndIncludeSeparator_TestCases()
        {
            Empty(SplitAndIncludeSeparator("", ';'));

            var strings1 = SplitAndIncludeSeparator("x", ';');
            Single(strings1);
            Equal("x", strings1[0]);

            var strings2 = SplitAndIncludeSeparator(";", ';');
            Single(strings2);
            Equal(";", strings2[0]);

            var strings3 = SplitAndIncludeSeparator(";x", ';');
            Equal(2, strings3.Length);
            Equal(";", strings3[0]);
            Equal("x", strings3[1]);

            var strings4 = SplitAndIncludeSeparator("x;;y", ';');
            Equal(3, strings4.Length);
            Equal("x;", strings4[0]);
            Equal(";", strings4[1]);
            Equal("y", strings4[2]);
        }

        [Fact]
        public void StripTitlesFromName_TestCases()
        {
            Equal("Nada DREMEL", StripTitlesFromName(
                  "Mr. sc. Nada DREMEL, dipl. oec., ovl. rač. i ovl. por. savj."));

            Equal("Ivan PETARČIĆ", StripTitlesFromName(
                  "Priredio: Ivan PETARČIĆ, struč. spec. oec."));

            Equal("Anamarija WAGNER", StripTitlesFromName(
                  "Anamarija WAGNER, dipl. oec., ovl. rev. i ACCA"));

            Equal("Tamara CIRKVENI FILIPOVIĆ", StripTitlesFromName(
                  "Dr. sc. Tamara CIRKVENI FILIPOVIĆ, glavna urednica"));

            Equal("Marijana RADUSIN LIPOŠINOVIĆ", StripTitlesFromName(
                  "Marijana RADUSIN LIPOŠINOVIĆ, dipl. oec., univ. spec. oec. i ovl. rač."));

            Equal("Vinko BELAK", StripTitlesFromName(
                  "Prof. dr. sc. Vinko BELAK"));

            Equal("Jasna VUK", StripTitlesFromName(
                  "Jasna VUK, dipl. oec. i ovl. rač."));

            Equal("Tatjana GRBAC", StripTitlesFromName(
                  "Pripremila: Tatjana GRBAC, dipl. iur., stalni sudski tumač za njemački jezik"));
        }

        [Fact]
        public void WhenValidateEmptyOrWhiteSpace_Throws()
        {
            Throws<ArgumentOutOfRangeException>(() => ValidateIsNotEmptyAndIsNotWhiteSpace("", "x"));
            Throws<ArgumentOutOfRangeException>(() => ValidateIsNotEmptyAndIsNotWhiteSpace("\t \r\n", "x"));
        }
    }
}
