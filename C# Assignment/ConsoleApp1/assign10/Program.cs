using System;

namespace BasicCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.Write("Enter your choice (1-4): ");
            int choice = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the first number: ");
            double num1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter the second number: ");
            double num2 = Convert.ToDouble(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Result: " + (num1 + num2));
                    break;
                case 2:
                    Console.WriteLine("Result: " + (num1 - num2));
                    break;
                case 3:
                    Console.WriteLine("Result: " + (num1 * num2));
                    break;
                case 4:
                    if (num2 != 0)
                    {
                        Console.WriteLine("Result: " + (num1 / num2));
                    }
                    else
                    {
                        Console.WriteLine("Error: Division by zero");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}