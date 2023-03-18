﻿using HtmlRefactoringWindowsApp;
using HtmlRefactoringWindowsApp.Enums;
using System;
using static Xunit.Assert;

namespace HtmlRefactoringTests.Enums
{
    public class MagazineBrandTests
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

            MagazineBrand succToMaxElement = (MagazineBrand)(Enum.GetValues(typeof(MagazineBrand)).Cast<int>().Max() + 1);

            bool isDefined = prevToMinElement.IsDefined() || succToMaxElement.IsDefined();

            False(isDefined);
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
            const string label = "RRiF";

            const MagazineBrand magazineBrand = MagazineBrand.RRiF;

            Equal(label, magazineBrand.GetLabel());
        }

        [Fact]
        public void MagazineBrand_PiP_Name()
        {
            const string name = "Pravo i porezi";

            const MagazineBrand magazineBrand = MagazineBrand.PiP;

            Equal(name, magazineBrand.GetName());
        }

        [Fact]
        public void MagazineBrand_Proracuni_LeadChar()
        {
            const string leadChar = "P";

            const MagazineBrand magazineBrand = MagazineBrand.Proracuni;

            Equal(leadChar, magazineBrand.GetLeadChar());
        }


        [Fact]
        public void MagazineBrand_Neprofitni_ID()
        {
            const int id = 7;

            const MagazineBrand magazineBrand = MagazineBrand.Neprofitni;

            Equal(id, magazineBrand.GetID());
        }

    }
}