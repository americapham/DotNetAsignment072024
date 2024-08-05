using System;

namespace MarkSumCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] marks = new int[5];
            int sum = 0;

            Console.WriteLine("Enter 5 marks:");

            for (int i = 0; i < 5; i++)
            {
                Console.Write("Mark " + (i + 1) + ": ");
                marks[i] = Convert.ToInt32(Console.ReadLine());
                sum += marks[i];
            }

            Console.WriteLine("The sum of the marks is: " + sum);
        }
    }
}