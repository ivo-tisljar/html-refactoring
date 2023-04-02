using System.ComponentModel;

namespace HtmlRefactoringWindowsApp.Temp
{
    public enum MagazineType2
    {
        [Description("RRiF")]
        //[Description2("RRiF")]
        RRiF = 1,
        [Description("Pravo i porezi")]
        //[Description2("Pravo i porezi")]
        PiP = 3,
        [Description("Proračuni")]
        //[Description2("Proračuni")]
        Proracuni = 8,
        [Description("Neprofitni")]
        //[Description2("Neprofitni")]
        Neprofitni = 7,
        [Description("Godišnji obračun")]
        //[Description2("Godišnji obračun")]
        GodisnjiObracun = 20,
        [Description("Obrtnici")]
        //[Description2("Obrtnici")]
        Obrtnici = 11,
        [Description("Obavijesti")]
        //[Description2("Obavijesti")]
        Obavijesti = 10
    }

    public static class MagazineType2Extensions
    {
        public static string GetLeadChar(this MagazineType2 magazineType)
        {
            if (magazineType == MagazineType2.GodisnjiObracun)
            {
                return "P";
            }
            return magazineType.ToString()[..1];
        }

        public static int GetID(this MagazineType2 magazineType)
        {
            return (int)magazineType;
        }

        public static string GetLabel(this MagazineType2 magazineType)
        {
            return magazineType switch
            {
                MagazineType2.RRiF => "RRiF",
                MagazineType2.PiP => "PiP",
                MagazineType2.Proracuni => "Pror",
                MagazineType2.Neprofitni => "Nepr",
                MagazineType2.GodisnjiObracun => "PrGO",
                MagazineType2.Obrtnici => "Obrt",
                MagazineType2.Obavijesti => "Obav",
                _ => throw new ArgumentException("Item not found.", nameof(magazineType)),
            };
        }

        public static string GetName(this MagazineType2 magazineType)
        {
            var field = magazineType.GetType().GetField(magazineType.ToString());
            if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
            {
                return attribute.Description;
            }
            throw new ArgumentException("Item not found.", nameof(magazineType));
        }
    }
}
