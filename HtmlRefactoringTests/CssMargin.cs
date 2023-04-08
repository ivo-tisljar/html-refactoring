﻿using HtmlRefactoringWindowsApp.Css;
using System.Drawing.Printing;
using System.Security.Cryptography;

namespace HtmlRefactoringTests
{
    public class CssMargin
    {
        private const string margin = "margin";
        private const string marginTop = "margin-top";
        private const string marginRight = "margin-right";
        private const string marginBottom = "margin-bottom";
        private const string marginLeft = "margin-left";

        public string? Top { get; set; }

        public string? Right { get; set; }

        public string? Bottom { get; set; }

        public string? Left { get; set; }

        public CssMargin(CssProperty cssProperty)
        {
            ValidateThatPropertyIsMargin(cssProperty);
            if (cssProperty.Name == margin)
                InitAllSides(cssProperty);
            else
                InitOneSide(cssProperty);
        }

            private static void ValidateThatPropertyIsMargin(CssProperty cssProperty)
            {
                if ((cssProperty.Name != margin) && (cssProperty.Name != marginTop) && (cssProperty.Name != marginRight) && (cssProperty.Name != marginBottom) &&
                    (cssProperty.Name != marginLeft))
                    throw new InvalidMarginException($"Error! Property '{cssProperty.Name}:{cssProperty.Value}' does not define a margin.");
            }

                private void InitAllSides(CssProperty cssProperty)
                {
                    var sides = cssProperty.Value.Split();

                    switch (sides.Count())
                    {
                        case 1:
                            Top = Right = Bottom = Left = sides[0]; break;
                        case 2:
                            Top = Bottom = sides[0];
                            Right = Left = sides[1]; break;
                        case 3:
                            Top = sides[0];
                            Right = Left = sides[1];
                            Bottom = sides[2]; break;
                        case 4:
                            Top = sides[0];
                            Right = sides[1];
                            Bottom = sides[2];
                            Left = sides[3]; break;
                        default:
                            throw new InvalidMarginException($"Error! Property '{cssProperty.Name}:{cssProperty.Value}' has invalid number of sides defined.");
                    }
                }

                private void InitOneSide(CssProperty cssProperty)
                {
                    switch (cssProperty.Name) 
                    {
                        case marginTop:
                            Top = cssProperty.Value; break;
                        case marginRight:
                            Right = cssProperty.Value; break;
                        case marginBottom:
                            Bottom = cssProperty.Value; break;
                        case marginLeft:
                            Left = cssProperty.Value; break;
                    }
                }
    }

public class InvalidMarginException : Exception
    {
        public InvalidMarginException(string message) : base(message) { }
    }
}