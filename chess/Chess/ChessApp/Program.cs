using System;

namespace ChessApp
{
    class Program
    {
        static void Main(string[] args)
        {
         /*
          * Min första lösning
            // Rad 1
            Console.Write("▓");
            Console.Write("▓");

            Console.Write("░");
            Console.Write("░");

            Console.Write("▓");
            Console.Write("▓");

            Console.Write("░");
            Console.Write("░");

            Console.Write("▓");
            Console.Write("▓");
            
            Console.Write("░");
            Console.Write("░");

            Console.Write("▓");
            Console.Write("▓");
           
            Console.Write("░");
            Console.Write("░");

            // Rad 2
            Console.WriteLine(" ");
            Console.Write("░");
            Console.Write("░");

            Console.Write("▓");
            Console.Write("▓");

            Console.Write("░");
            Console.Write("░");

            Console.Write("▓");
            Console.Write("▓");

            Console.Write("░");
            Console.Write("░");

            Console.Write("▓");
            Console.Write("▓");

            Console.Write("░");
            Console.Write("░");

            Console.Write("▓");
            Console.Write("▓");

            // Rad 3
            Console.WriteLine(" ");
            Console.Write("▓");
            Console.Write("▓");

            Console.Write("░");
            Console.Write("░");

            Console.Write("▓");
            Console.Write("▓");

            Console.Write("░");
            Console.Write("░");

            Console.Write("▓");
            Console.Write("▓");

            Console.Write("░");
            Console.Write("░");

            Console.Write("▓");
            Console.Write("▓");

            Console.Write("░");
            Console.Write("░");

            // Rad 4
            Console.WriteLine(" ");
            Console.Write("░");
            Console.Write("░");

            Console.Write("▓");
            Console.Write("▓");

            Console.Write("░");
            Console.Write("░");

            Console.Write("▓");
            Console.Write("▓");

            Console.Write("░");
            Console.Write("░");

            Console.Write("▓");
            Console.Write("▓");

            Console.Write("░");
            Console.Write("░");

            Console.Write("▓");
            Console.Write("▓");

            // Rad 5
            Console.WriteLine(" ");
            Console.Write("▓");
            Console.Write("▓");

            Console.Write("░");
            Console.Write("░");

            Console.Write("▓");
            Console.Write("▓");

            Console.Write("░");
            Console.Write("░");

            Console.Write("▓");
            Console.Write("▓");

            Console.Write("░");
            Console.Write("░");

            Console.Write("▓");
            Console.Write("▓");

            Console.Write("░");
            Console.Write("░");

            // Rad 6
            Console.WriteLine(" ");
            Console.Write("░");
            Console.Write("░");

            Console.Write("▓");
            Console.Write("▓");

            Console.Write("░");
            Console.Write("░");

            Console.Write("▓");
            Console.Write("▓");

            Console.Write("░");
            Console.Write("░");

            Console.Write("▓");
            Console.Write("▓");

            Console.Write("░");
            Console.Write("░");

            Console.Write("▓");
            Console.Write("▓");

            // Rad 7
            Console.WriteLine(" ");
            Console.Write("▓");
            Console.Write("▓");

            Console.Write("░");
            Console.Write("░");

            Console.Write("▓");
            Console.Write("▓");

            Console.Write("░");
            Console.Write("░");

            Console.Write("▓");
            Console.Write("▓");

            Console.Write("░");
            Console.Write("░");

            Console.Write("▓");
            Console.Write("▓");

            Console.Write("░");
            Console.Write("░");

            // Rad 8
            Console.WriteLine(" ");
            Console.Write("░");
            Console.Write("░");

            Console.Write("▓");
            Console.Write("▓");

            Console.Write("░");
            Console.Write("░");

            Console.Write("▓");
            Console.Write("▓");

            Console.Write("░");
            Console.Write("░");

            Console.Write("▓");
            Console.Write("▓");

            Console.Write("░");
            Console.Write("░");

            Console.Write("▓");
            Console.Write("▓");
         */

            for (var y = 0; y < 8; y++)
            {
                for (var x = 0; x < 16; x++)
                {
                    int characterIndex = (x / 2 + y) % 2;
                    char character = characterIndex == 0 ? '░' : '▓';

                    Console.Write(character);
                }
                Console.Write('\n');
            }

            Console.ReadKey();
        }
    }
}
