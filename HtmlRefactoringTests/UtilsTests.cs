
using HtmlRefactoringWindowsApp.Utils;
using static Xunit.Assert;
using static HtmlRefactoringWindowsApp.Utils.StringUtils;

namespace HtmlRefactoringTests
{
    public class UtilsTests
    {
        [Fact]
        public void CountCharInString_TestCases()
        {
            Equal(4, CountCharInString(';', "Danas;je;lijep;dan;"));
            Equal(1, CountCharInString('D', "Danas;je;lijep;dan"));
            Equal(1, CountCharInString('d', "Danas;je;lijep;dan"));
            Equal(0, CountCharInString('\t', "Danas \r\n je \r\n lijep \n dan!"));
            Equal(3, CountCharInString('\n', "Danas \r\n je \r\n lijep \n dan!"));
        }

        [Fact]
        public void IsAsciiHrLettersOrSpace_TestCases()
        {
            True(IsAsciiHrLettersOrSpace(""));
            True(IsAsciiHrLettersOrSpace("Šušti lišće"));
            True(IsAsciiHrLettersOrSpace("first and LAST"));
            True(IsAsciiHrLettersOrSpace(" not trimmed "));
            True(IsAsciiHrLettersOrSpace("Abcčć Dđefg Hijkl Mnopq Rsštu Vwxyz Ž"));
            True(IsAsciiHrLettersOrSpace("aBCČĆ dĐEFG hIJKL mNOPQ rSŠTU vWXYZ ž"));

            False(IsAsciiHrLettersOrSpace("Alpha 7"));
            False(IsAsciiHrLettersOrSpace("One, two, three"));
            False(IsAsciiHrLettersOrSpace("Sign for euro is €"));
            False(IsAsciiHrLettersOrSpace("exclamation!"));
            False(IsAsciiHrLettersOrSpace("Točka."));
            False(IsAsciiHrLettersOrSpace("Upitnik?"));
            False(IsAsciiHrLettersOrSpace("123"));
        }

        [Fact]
        public void IsAsciiHrLetterUpper_TestCases()
        {
        }

        [Fact]
        public void IsAsciiLetters_TestCases()
        {
        }

        [Fact]
        public void IsHrAccentedLetter_TestCases()
        {
        }

        [Fact]
        public void IsHrUpperAccentedLetter_TestCases()
        {
        }

        [Fact]
        public void IsNaturalNumberUpToMaxDigitsCount_TestCases()
        {
        }

        [Fact]
        public void SplitWithSeparatorIncluded_TestCases()
        {
            Empty(SplitWithSeparatorIncluded("", ';'));

            var strings1 = SplitWithSeparatorIncluded("x", ';');
            Single(strings1);
            Equal("x", strings1[0]);

            var strings2 = SplitWithSeparatorIncluded(";", ';');
            Single(strings2);
            Equal(";", strings2[0]);

            var strings3 = SplitWithSeparatorIncluded(";x", ';');
            Equal(2, strings3.Length);
            Equal(";", strings3[0]);
            Equal("x", strings3[1]);

            var strings4 = SplitWithSeparatorIncluded("x;;y;", ';');
            Equal(3, strings4.Length);
            Equal("x;", strings4[0]);
            Equal(";", strings4[1]);
            Equal("y;", strings4[2]);
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
            Throws<ArgumentOutOfRangeException>(() => ValidateIsNotEmptyNorWhiteSpace("", "x"));
            Throws<ArgumentOutOfRangeException>(() => ValidateIsNotEmptyNorWhiteSpace("\t \r\n", "x"));
        }
    }
}
