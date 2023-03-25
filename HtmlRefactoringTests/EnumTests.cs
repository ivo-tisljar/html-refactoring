using HtmlRefactoringWindowsApp.Enums;
using static Xunit.Assert;

namespace HtmlRefactoringTests.Enums
{
    public class EnumTests
    {
        [Fact]
        public void MagazineBrand_IsDefined_True()
        {
            bool isDefined = true;

            foreach (MagazineBrand magazineBrand in (MagazineBrand[])Enum.GetValues(typeof(MagazineBrand)))
            {
                isDefined &= magazineBrand.IsDefined();
            }
            True(isDefined);
        }

        [Fact]
        public void MagazineBrand_IsDefined_False()
        {
            MagazineBrand prevToMinElement = (MagazineBrand)(Enum.GetValues(typeof(MagazineBrand)).Cast<int>().Min() - 1);
            False(prevToMinElement.IsDefined());

            MagazineBrand succToMaxElement = (MagazineBrand)(Enum.GetValues(typeof(MagazineBrand)).Cast<int>().Max() + 1);
            False(succToMaxElement.IsDefined());
        }

        [Fact]
        public void MagazineBrand_Unknown_Label()
        {
            MagazineBrand succToMaxElement = (MagazineBrand)(Enum.GetValues(typeof(MagazineBrand)).Cast<int>().Max() + 1);

            Throws<ArgumentOutOfRangeException>(() => succToMaxElement.GetLabel());
        }

        [Fact]
        public void MagazineBrand_RRiF_Label()
        {
            Equal("RRiF", MagazineBrand.RRiF.GetLabel());
        }

        [Fact]
        public void MagazineBrand_PiP_Name()
        {
            Equal("Pravo i porezi", MagazineBrand.PiP.GetName());
        }

        [Fact]
        public void MagazineBrand_Proracuni_LeadChar()
        {
            Equal("P", MagazineBrand.Proracuni.GetLeadChar());
        }

        [Fact]
        public void MagazineBrand_Neprofitni_ID()
        {
            Equal(7, MagazineBrand.Neprofitni.GetID());
        }
    }
}
