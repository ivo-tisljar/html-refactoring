﻿
using static HtmlRefactoringWindowsApp.Utils.StringUtils;
using static Xunit.Assert;

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
            True(IsAsciiHrLetterUpper('A'));
            True(IsAsciiHrLetterUpper('Z'));
            True(IsAsciiHrLetterUpper('Č'));
            True(IsAsciiHrLetterUpper('Ć'));
            True(IsAsciiHrLetterUpper('Đ'));
            True(IsAsciiHrLetterUpper('Š'));
            True(IsAsciiHrLetterUpper('Ž'));

            False(IsAsciiHrLetterUpper('a'));
            False(IsAsciiHrLetterUpper('č'));
            False(IsAsciiHrLetterUpper('0'));
            False(IsAsciiHrLetterUpper('€'));
            False(IsAsciiHrLetterUpper('.'));
            False(IsAsciiHrLetterUpper('#'));
        }

        [Fact]
        public void IsAsciiLetters_TestCases()
        {
            True(IsAsciiLetters(""));
            True(IsAsciiLetters("FirstAndLast"));
            True(IsAsciiLetters("AbcDefgHijklMnopqRstuVwxyz"));
            True(IsAsciiLetters("aBCdEFGhIJKLmNOPQrSTUvWXYZ"));

            False(IsAsciiLetters("Alpha7"));
            False(IsAsciiLetters("Alpha Zero"));
            False(IsAsciiLetters(" not trimmed "));
            False(IsAsciiLetters("One,two,three"));
            False(IsAsciiLetters("Sign for euro is €"));
            False(IsAsciiLetters("exclamation!"));
            False(IsAsciiLetters("Fullstop."));
            False(IsAsciiLetters("Upitnik?"));
            False(IsAsciiLetters("123"));
            False(IsAsciiLetters("Šušti lišće"));
        }

        [Fact]
        public void IsHrAccentedLetter_TestCases()
        {
            True(IsHrAccentedLetter('č'));
            True(IsHrAccentedLetter('ć'));
            True(IsHrAccentedLetter('đ'));
            True(IsHrAccentedLetter('š'));
            True(IsHrAccentedLetter('ž'));
            True(IsHrAccentedLetter('Č'));
            True(IsHrAccentedLetter('Ć'));
            True(IsHrAccentedLetter('Đ'));
            True(IsHrAccentedLetter('Š'));
            True(IsHrAccentedLetter('Ž'));

            False(IsHrAccentedLetter('0'));
            False(IsHrAccentedLetter('A'));
            False(IsHrAccentedLetter('z'));
            False(IsHrAccentedLetter('€'));
            False(IsHrAccentedLetter('ő'));
            False(IsHrAccentedLetter('ę'));
            False(IsHrAccentedLetter(':'));
        }

        [Fact]
        public void IsHrUpperAccentedLetter_TestCases()
        {
            True(IsHrUpperAccentedLetter('Č'));
            True(IsHrUpperAccentedLetter('Ć'));
            True(IsHrUpperAccentedLetter('Đ'));
            True(IsHrUpperAccentedLetter('Š'));
            True(IsHrUpperAccentedLetter('Ž'));

            False(IsHrUpperAccentedLetter('č'));
            False(IsHrUpperAccentedLetter('ć'));
            False(IsHrUpperAccentedLetter('đ'));
            False(IsHrUpperAccentedLetter('š'));
            False(IsHrUpperAccentedLetter('ž'));
            False(IsHrUpperAccentedLetter('0'));
            False(IsHrUpperAccentedLetter('A'));
            False(IsHrUpperAccentedLetter('!'));
        }

        [Fact]
        public void IsNaturalNumberUpToMaxDigitsCount_TestCases()
        {
            Throws<ArgumentOutOfRangeException>(() => IsNaturalNumberUpToMaxDigitsCount("12", 0));

            True(IsNaturalNumberUpToMaxDigitsCount("1", 1));
            True(IsNaturalNumberUpToMaxDigitsCount("12", 4));
            True(IsNaturalNumberUpToMaxDigitsCount("987", 987));
            True(IsNaturalNumberUpToMaxDigitsCount("1234567890123456789012345678901234567890", 40));

            False(IsNaturalNumberUpToMaxDigitsCount("0", 2));
            False(IsNaturalNumberUpToMaxDigitsCount("12", 1));
            False(IsNaturalNumberUpToMaxDigitsCount("x1", 3));
            False(IsNaturalNumberUpToMaxDigitsCount("1.0", 4));
        }

        [Fact]
        public void SplitStringWithSeparatorIncluded_TestCases()
        {
            var strings1 = SplitStringWithSeparatorIncluded("", ';');
            Single(strings1);
            Equal("", strings1[0]);

            var strings2 = SplitStringWithSeparatorIncluded("x", ';');
            Single(strings2);
            Equal("x", strings2[0]);

            var strings3 = SplitStringWithSeparatorIncluded(";", ';');
            Equal(2, strings3.Length);
            Equal(";", strings3[0]);
            Equal("", strings3[1]);

            var strings4 = SplitStringWithSeparatorIncluded(";x", ';');
            Equal(2, strings4.Length);
            Equal(";", strings4[0]);
            Equal("x", strings4[1]);

            var strings5 = SplitStringWithSeparatorIncluded("x;;y;", ';');
            Equal(4, strings5.Length);
            Equal("x;", strings5[0]);
            Equal(";", strings5[1]);
            Equal("y;", strings5[2]);
            Equal("", strings5[3]);
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
