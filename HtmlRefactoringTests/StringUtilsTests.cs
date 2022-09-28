using HtmlRefactoringWindowsApp.Utils;

namespace HtmlRefactoringTests
{
    public class StringUtilsTests
    {

        [Fact]
        public void StripTitlesFromName_Nada()
        {
            const string nameWithTitles = "Mr. sc. Nada DREMEL, dipl. oec., ovl. rač. i ovl. por. savj.";
            const string nameWithoutTitles = "Nada DREMEL";

            string nameStripedOfTitles = StringUtils.StripTitlesFromName(nameWithTitles);

            Assert.Equal(nameStripedOfTitles, nameWithoutTitles);
        }

        [Fact]
        public void StripTitlesFromName_Ivan()
        {
            const string nameWithTitles = "Priredio: Ivan PETARČIĆ, struč. spec. oec.";
            const string nameWithoutTitles = "Ivan PETARČIĆ";

            string nameStripedOfTitles = StringUtils.StripTitlesFromName(nameWithTitles);

            Assert.Equal(nameStripedOfTitles, nameWithoutTitles);
        }

        [Fact]
        public void StripTitlesFromName_Anamarija()
        {
            const string nameWithTitles = "Anamarija WAGNER, dipl. oec., ovl. rev. i ACCA";
            const string nameWithoutTitles = "Anamarija WAGNER";

            string nameStripedOfTitles = StringUtils.StripTitlesFromName(nameWithTitles);

            Assert.Equal(nameStripedOfTitles, nameWithoutTitles);
        }

        [Fact]
        public void StripTitlesFromName_Tamara()
        {
            const string nameWithTitles = "Dr. sc. Tamara CIRKVENI FILIPOVIĆ, glavna urednica";
            const string nameWithoutTitles = "Tamara CIRKVENI FILIPOVIĆ";

            string nameStripedOfTitles = StringUtils.StripTitlesFromName(nameWithTitles);

            Assert.Equal(nameStripedOfTitles, nameWithoutTitles);
        }

        [Fact]
        public void StripTitlesFromName_Marijana()
        {
            const string nameWithTitles = "Marijana RADUSIN LIPOŠINOVIĆ, dipl. oec., univ. spec. oec. i ovl. rač.";
            const string nameWithoutTitles = "Marijana RADUSIN LIPOŠINOVIĆ";

            string nameStripedOfTitles = StringUtils.StripTitlesFromName(nameWithTitles);

            Assert.Equal(nameStripedOfTitles, nameWithoutTitles);
        }

        [Fact]
        public void StripTitlesFromName_Vinko()
        {
            const string nameWithTitles = "Prof. dr. sc. Vinko BELAK";
            const string nameWithoutTitles = "Vinko BELAK";

            string nameStripedOfTitles = StringUtils.StripTitlesFromName(nameWithTitles);

            Assert.Equal(nameStripedOfTitles, nameWithoutTitles);
        }

        [Fact]
        public void StripTitlesFromName_Jasna()
        {
            const string nameWithTitles = "Jasna VUK, dipl. oec. i ovl. rač.*";
            const string nameWithoutTitles = "Jasna VUK";

            string nameStripedOfTitles = StringUtils.StripTitlesFromName(nameWithTitles);

            Assert.Equal(nameStripedOfTitles, nameWithoutTitles);
        }

        [Fact]
        public void StripTitlesFromName_Tatjana()
        {
            const string nameWithTitles = "Pripremila: Tatjana GRBAC, dipl. iur., stalni sudski tumač za njemački jezik";
            const string nameWithoutTitles = "Tatjana GRBAC";

            string nameStripedOfTitles = StringUtils.StripTitlesFromName(nameWithTitles);

            Assert.Equal(nameStripedOfTitles, nameWithoutTitles);
        }
    }
}
