using System;

namespace VariableSwapper
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = 5;
            int num2 = 7;
            int temp;

            Console.WriteLine("Before swapping:");
            Console.WriteLine("num1 = " + num1);
            Console.WriteLine("num2 = " + num2);

            // Swapping the variables using a third variable
            temp = num1;
            num1 = num2;
            num2 = temp;

            Console.WriteLine("\nAfter swapping:");
            Console.WriteLine("num1 = " + num1);
            Console.WriteLine("num2 = " + num2);
        }
    }
}