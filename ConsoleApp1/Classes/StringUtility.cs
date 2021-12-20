using System;
using System.Collections.Generic;

namespace CSharpFundamentals
{
    public class StringUtility
    {
        public static string SummerizeText(string text, int maxLenght = 20)
        {
            if (text.Length < 20)
                return text;

            var words = text.Split(" ");
            var totalCharacters = 0;
            var summmaryWords = new List<string>();

            foreach (var word in words)
            {
                summmaryWords.Add(word);

                totalCharacters += word.Length + 1;
                if (totalCharacters >= 20)
                {
                    break;
                }
            }

            return String.Join(" ", summmaryWords) + "...";
        }
    }
}