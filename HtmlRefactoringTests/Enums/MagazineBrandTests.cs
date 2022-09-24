using HtmlRefactoringConsole;
using HtmlRefactoringConsole.Enums;
using System;

namespace HtmlRefactoringTests.Enums
{
    public class MagazineBrandTests
    {
        [Fact]
        public void MagazineBrand_RRiF_Label()
        {
            const string label = "RRiF";

            const MagazineBrand magazineBrand = MagazineBrand.RRiF;

//assertThat(Month.valueOf("January"), is (notNullValue()));

            Assert.Equal(label, magazineBrand.GetLabel());
        }

        [Fact]
        public void MagazineBrand_PiP_Name()
        {
            const string name = "Pravo i porezi";

            const MagazineBrand magazineBrand = MagazineBrand.PiP;

            Assert.Equal(name, magazineBrand.GetName());
        }

        [Fact]
        public void MagazineBrand_Proracuni_LeadChar()
        {
            const string leadChar = "P";

            const MagazineBrand magazineBrand = MagazineBrand.Proracuni;

            Assert.Equal(leadChar, magazineBrand.GetLeadChar());
        }


        [Fact]
        public void MagazineBrand_Neprofitni_ID()
        {
            const int id = 7;

            const MagazineBrand magazineBrand = MagazineBrand.Neprofitni;

            Assert.Equal(id, magazineBrand.GetID());
        }

    }
}
