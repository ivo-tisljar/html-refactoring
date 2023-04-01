using HtmlRefactoringWindowsApp.Utils;
using static Xunit.Assert;

namespace HtmlRefactoringTests
{
    public class StringUtilsTests
    {
        [Fact]
        public void StripTitlesFromNames()
        {
            Equal("Nada DREMEL", StringUtils.StripTitlesFromName(
                  "Mr. sc. Nada DREMEL, dipl. oec., ovl. rač. i ovl. por. savj."));

            Equal("Ivan PETARČIĆ", StringUtils.StripTitlesFromName(
                  "Priredio: Ivan PETARČIĆ, struč. spec. oec."));

            Equal("Anamarija WAGNER", StringUtils.StripTitlesFromName(
                  "Anamarija WAGNER, dipl. oec., ovl. rev. i ACCA"));

            Equal("Tamara CIRKVENI FILIPOVIĆ", StringUtils.StripTitlesFromName(
                  "Dr. sc. Tamara CIRKVENI FILIPOVIĆ, glavna urednica"));

            Equal("Marijana RADUSIN LIPOŠINOVIĆ", StringUtils.StripTitlesFromName(
                  "Marijana RADUSIN LIPOŠINOVIĆ, dipl. oec., univ. spec. oec. i ovl. rač."));

            Equal("Vinko BELAK", StringUtils.StripTitlesFromName(
                  "Prof. dr. sc. Vinko BELAK"));

            Equal("Jasna VUK", StringUtils.StripTitlesFromName(
                  "Jasna VUK, dipl. oec. i ovl. rač."));

            Equal("Tatjana GRBAC", StringUtils.StripTitlesFromName(
                  "Pripremila: Tatjana GRBAC, dipl. iur., stalni sudski tumač za njemački jezik"));
        }

        [Fact]
        public void StripTitlesFromName_TestCases()
        {
            Equal("Nada DREMEL", StringUtils.StripTitlesFromName(
                  "Mr. sc. Nada DREMEL, dipl. oec., ovl. rač. i ovl. por. savj."));

            Equal("Ivan PETARČIĆ", StringUtils.StripTitlesFromName(
                  "Priredio: Ivan PETARČIĆ, struč. spec. oec."));

            Equal("Anamarija WAGNER", StringUtils.StripTitlesFromName(
                  "Anamarija WAGNER, dipl. oec., ovl. rev. i ACCA"));

            Equal("Tamara CIRKVENI FILIPOVIĆ", StringUtils.StripTitlesFromName(
                  "Dr. sc. Tamara CIRKVENI FILIPOVIĆ, glavna urednica"));

            Equal("Marijana RADUSIN LIPOŠINOVIĆ", StringUtils.StripTitlesFromName(
                  "Marijana RADUSIN LIPOŠINOVIĆ, dipl. oec., univ. spec. oec. i ovl. rač."));

            Equal("Vinko BELAK", StringUtils.StripTitlesFromName(
                  "Prof. dr. sc. Vinko BELAK"));

            Equal("Jasna VUK", StringUtils.StripTitlesFromName(
                  "Jasna VUK, dipl. oec. i ovl. rač."));

            Equal("Tatjana GRBAC", StringUtils.StripTitlesFromName(
                  "Pripremila: Tatjana GRBAC, dipl. iur., stalni sudski tumač za njemački jezik"));
        }

        [Fact]
        public void WhenValidateEmptyOrWhiteSpace_Throws()
        {
            Throws<ArgumentOutOfRangeException>(() => StringUtils.ValidateIsNotEmptyAndIsNotWhiteSpace("", "x"));
            Throws<ArgumentOutOfRangeException>(() => StringUtils.ValidateIsNotEmptyAndIsNotWhiteSpace("\t \r\n", "x"));
        }
    }
}
