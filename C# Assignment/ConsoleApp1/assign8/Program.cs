using System;

namespace LeapYearChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a year: ");
            int year = Convert.ToInt32(Console.ReadLine());

            string result = ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0)) ? " is a leap year." : " is not a leap year.";
            Console.WriteLine(year + result);
        }
    }
}