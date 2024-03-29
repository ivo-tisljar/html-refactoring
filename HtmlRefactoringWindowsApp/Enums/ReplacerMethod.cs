﻿
namespace HtmlRefactoringWindowsApp.Enums
{
    public enum ReplacerMethod
    {
        Text = 0,
        Regex = 1
    }

    public static class StringExtensions_ReplacerMethod
    {
        public static ReplacerMethod ToReplacerMethod(this string replacerMethodString)
        {
            return (ReplacerMethod)Enum.Parse(typeof(ReplacerMethod), replacerMethodString);
        }
    }
}
