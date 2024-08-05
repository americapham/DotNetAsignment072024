using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        string input = Console.ReadLine();
        double number;

        if (double.TryParse(input, out number))
        {
            double absoluteValue = Math.Abs(number);
            Console.WriteLine($"The absolute value of {number} is {absoluteValue}.");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }
}