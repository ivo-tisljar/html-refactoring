
using HtmlRefactoringConsole;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
const string nameWithTitles = "Ivan PETARČIĆ, struč. spec. oec. zamjenik glavne urednice";
const string nameWithoutTitles = "Ivan PETARČIĆ";

var article = new Article("1", nameWithTitles, "3", "4");
Console.WriteLine(">" + nameWithoutTitles + "<");
string authorNameWithoutTitles = article.AuthorNameWithoutTitles();
Console.WriteLine(">" + authorNameWithoutTitles + "<");

