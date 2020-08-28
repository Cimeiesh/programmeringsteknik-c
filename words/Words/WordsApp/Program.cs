using System;
using System.Linq;

namespace WordsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Skriv en konsolapplikation som tar emot en skriven text.

            Console.WriteLine("Enter a string, preferrrably containing a sentence.");

            char[] vowels = new char[] { 'a', 'o', 'i', 'e', 'u', 'y', 'å', 'ä', 'ö' };

            string enteredString = Console.ReadLine();
            string lowercaseString = enteredString.ToLower();

            string[] words = enteredString.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int vowelCount = 0;
            int wordCount = words.Length;
            string longestWord = string.Empty;

            foreach (var characters in enteredString)
            {
                //var normalizedCharacter = char.ToLower(character);
                if (vowels.Contains(characters))
                {
                    vowelCount++;
                }
            }

            if (words.Length > longestWord.Length)
            {

            }
            for (var i = 0; i < enteredString.Length; i++)
            {
                var character = enteredString[i];
            }

            // Vi vill ha ut följande:
            //Antal ord?
            //Antal vokaler?
            //Vilket är det längsta ordet?

            Console.WriteLine("Word Counts: " + wordCount);
            Console.WriteLine("Vowel Counts: " + vowelCount);
            Console.WriteLine("Longest word: " + longestWord );
            //Word count
            //Vowel count
            //Longest word


        }
    }
}
