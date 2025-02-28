﻿using System;
using System.Linq;

namespace CSharpAdvanceNET.ExtensionMethods
{
    public static class StringExtensions
    {
        

        public static string Shorten(this String str, int numberOfWords)
        {
            if (numberOfWords < 0)
                throw new ArgumentOutOfRangeException("numberOfWords should be greater than or qual to 0");

            if (numberOfWords == 0)
                return "";

            var words = str.Split(' ');

            if (words.Length <= numberOfWords)
                return str;

            return string.Join(" ", words.Take(numberOfWords))+"...";
        }
    }
}