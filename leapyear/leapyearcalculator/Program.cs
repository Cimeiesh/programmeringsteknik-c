using System;

namespace leapyearcalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Räkna ut hur många skottår som passerat mellan två inmatade värden.

            // DateTime.IsLeapYear(year) är en metod man kan använda.

            //Console.WriteLine("Welcome!");
            //Console.WriteLine("To check how many leap years is between two years, please write first year:");
            //string inputOne = Console.ReadLine();

            //Console.WriteLine("Please write the second year:");
            //string inputTwo = Console.ReadLine();

            //int yearOne = int.Parse(inputOne);
            //int yearTwo = int.Parse(inputTwo);

            //for (int year = yearOne; year <= yearTwo; year++)
            //{
            //    if(DateTime.IsLeapYear(year))
            //    {
            //        Console.WriteLine($"{0} are leaps years", year);

            //        DateTime leapYear = new DateTime(year);
            //        Console.WriteLine("   One year from {0} is {1}.",
            //           leapDay.ToString("d"),
            //           nextYear.ToString("d"));
            //    }
            //}

            int firstYear = int.Parse(args[0]);
            int secondYear = int.Parse(args[1]);

            int maxYear = Math.Max(firstYear, secondYear);
            int minYear = Math.Min(firstYear, secondYear);

            int leapYearCount = 0;
            for (int year = minYear; year <= maxYear; year++)
            {
                bool isLeapYear = DateTime.IsLeapYear(year);
                
                if (isLeapYear)
                {
                    leapYearCount ++;
                }

            }

            Console.WriteLine($"Encountered {leapYearCount} leap year from {minYear} to {maxYear}.");
        }
    }
}
