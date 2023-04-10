namespace HtmlRefactoringWindowsApp.Articles
{
    // TO-DO: OVO TREBA PRETVORITI U OBIČNU KLASU BEZ ENUMA: WebID, Name, Label, LeadChar

    public enum MagazineBrandEx
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
            public int WebID;
            public string Label;
            public string Name;
        }

        // This values are required by external bussines rules

        private static readonly MagazineBrandData[] magazineData = new MagazineBrandData[]
        {
            new MagazineBrandData { LeadChar = "R", WebID = 01, Label="RRiF", Name ="RRiF" },
            new MagazineBrandData { LeadChar = "P", WebID = 03, Label="PiP",  Name ="Pravo i porezi" },
            new MagazineBrandData { LeadChar = "P", WebID = 08, Label="Pror", Name ="Proračuni" },
            new MagazineBrandData { LeadChar = "N", WebID = 07, Label="Nepr", Name ="Neprofitni" },
            new MagazineBrandData { LeadChar = "P", WebID = 20, Label="PrGO", Name ="Godišnji obračun" },
            new MagazineBrandData { LeadChar = "O", WebID = 11, Label="Obrt", Name ="Obrtnici" },
            new MagazineBrandData { LeadChar = "O", WebID = 10, Label="Obav", Name ="Obavijesti" }
        };

        // file name leading char for this type of magazine

        public static string GetLeadChar(this MagazineBrandEx magazineBrand)
        {
            if (magazineBrand.IsDefined())
            {
                return magazineData[(int)magazineBrand].LeadChar;
            }
            throw new ArgumentOutOfRangeException($"Invalid value! Value {magazineBrand} is NOT valid for type MagazineBrandEx.");
        }

        public static int GetWebID(this MagazineBrandEx magazineBrand)
        {
            if (magazineBrand.IsDefined())
            {
                return magazineData[(int)magazineBrand].WebID;
            }
            throw new ArgumentOutOfRangeException($"Invalid value! Value {magazineBrand} is NOT valid for type MagazineBrandEx.");
        }

        public static string GetLabel(this MagazineBrandEx magazineBrand)
        {
            if (magazineBrand.IsDefined())
            {
                return magazineData[(int)magazineBrand].Label;
            }
            throw new ArgumentOutOfRangeException($"Invalid value! Value {magazineBrand} is NOT valid for type MagazineBrandEx.");
        }

        public static string GetName(this MagazineBrandEx magazineBrand)
        {
            if (magazineBrand.IsDefined())
            {
                return magazineData[(int)magazineBrand].Name;
            }
            throw new ArgumentOutOfRangeException($"Invalid value! Value {magazineBrand} is NOT valid for type MagazineBrandEx.");
        }

        public static bool IsDefined(this MagazineBrandEx magazineBrand)
        {
            return magazineBrand >= MagazineBrandEx.RRiF && magazineBrand <= MagazineBrandEx.Obavijesti;
        }
    }
}
