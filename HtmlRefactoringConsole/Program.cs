
using HtmlRefactoringConsole;
using HtmlRefactoringConsole.Enums;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
const string nameWithTitles = "Ivan PETARČIĆ, struč. spec. oec. zamjenik glavne urednice";
const string nameWithoutTitles = "Ivan PETARČIĆ";

var article = new Article("1", nameWithTitles, "3", "4");
Console.WriteLine(">" + nameWithoutTitles + "<");
string authorNameWithoutTitles = article.AuthorNameWithoutTitles();
Console.WriteLine(">" + authorNameWithoutTitles + "<");

foreach (MagazineBrand magazineType in Enum.GetValues(typeof(MagazineBrand)))
{
    Console.WriteLine($">{magazineType}<   >{magazineType.GetLeadChar()}<   >{magazineType.GetID()}<   >{magazineType.GetLabel()}<   >{magazineType.GetName()}<");
}

foreach (MagazineType2 magazineType in Enum.GetValues(typeof(MagazineType2)))
{
    Console.WriteLine($">{magazineType}<   >{magazineType.GetLeadChar()}<   >{magazineType.GetID()}<   >{magazineType.GetLabel()}<   >{magazineType.GetName()}<");
}
