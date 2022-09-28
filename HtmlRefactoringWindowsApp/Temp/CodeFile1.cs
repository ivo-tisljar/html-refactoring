using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return magazineType.ToString().Substring(0, 1);
        }

        public static int GetID(this MagazineType2 magazineType)
        {
            return (int)magazineType;
        }

        public static string GetLabel(this MagazineType2 magazineType)
        {
            switch (magazineType)
            {
                case MagazineType2.RRiF:
                    return "RRiF";
                case MagazineType2.PiP:
                    return "PiP";
                case MagazineType2.Proracuni:
                    return "Pror";
                case MagazineType2.Neprofitni:
                    return "Nepr";
                case MagazineType2.GodisnjiObracun:
                    return "PrGO";
                case MagazineType2.Obrtnici:
                    return "Obrt";
                case MagazineType2.Obavijesti:
                    return "Obav";
                default:
                    throw new ArgumentException("Item not found.", nameof(magazineType));
            }
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
