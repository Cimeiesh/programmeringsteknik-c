using System;
using System.Collections.Generic;
using System.Linq;

namespace vowelapp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Skriv en konsolapplikation som tar bort vokaler (konstigt va?) från en inmatad sträng.
            // Applikationen skall både presentera den resulterande strängen och antalet vokaler som togs bort.


            Console.WriteLine("Skriv något:");
            var input = Console.ReadLine();
            var letters = new HashSet<char>("AaEeIiOoUuYyÅåÄäÖö");

            string result = String.Concat(input.ToCharArray().Where(c => !letters.Contains(c)));

            int remove = 0;
            for (int i = 0; i < result.Length; i++)
            {
                remove++;
            }
            Console.WriteLine(result + remove);
            Console.ReadKey();
        }
    }
}
