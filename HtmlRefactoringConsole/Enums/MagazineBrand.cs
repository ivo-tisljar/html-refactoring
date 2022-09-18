﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlRefactoringConsole.Enums
{
    public enum MagazineBrand
    {
        RRiF = 0,
        PiP = 1,
        Proracuni = 2,
        Neprofitni = 3,
        GodisnjiObracun = 4,
        Obrtnici = 5,
        Obavijesti = 6
    }

    public static class MagazineBrandExtensions
    {
        private struct MagazineBrandData
        {
            public string LeadChar;
            public int ID;
            public string Label;
            public string Name;
        }

        // This values are required by external bussines rules

        private static readonly MagazineBrandData[] magazineData = new MagazineBrandData[]
        {
            new MagazineBrandData { LeadChar = "R", ID = 01, Label="RRiF", Name ="RRiF" },
            new MagazineBrandData { LeadChar = "P", ID = 03, Label="PiP",  Name ="Pravo i porezi" },
            new MagazineBrandData { LeadChar = "P", ID = 08, Label="Pror", Name ="Proračuni" },
            new MagazineBrandData { LeadChar = "N", ID = 07, Label="Nepr", Name ="Neprofitni" },
            new MagazineBrandData { LeadChar = "P", ID = 20, Label="PrGO", Name ="Godišnji obračun" },
            new MagazineBrandData { LeadChar = "O", ID = 11, Label="Obrt", Name ="Obrtnici" },
            new MagazineBrandData { LeadChar = "O", ID = 10, Label="Obav", Name ="Obavijesti" }
        };

        // file name leading char for this type of magazine

        public static string GetLeadChar(this MagazineBrand magazineBrand)
        {
            return magazineData[(int)magazineBrand].LeadChar;
        }

        public static int GetID(this MagazineBrand magazineBrand)
        {
            return magazineData[(int)magazineBrand].ID;
        }

        public static string GetLabel(this MagazineBrand magazineBrand)
        {
            return magazineData[(int)magazineBrand].Label;
        }

        public static string GetName(this MagazineBrand magazineBrand)
        {
            return magazineData[(int)magazineBrand].Name;
        }
    }
}
