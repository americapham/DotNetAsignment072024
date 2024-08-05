using System;

namespace MarkAverageCalculator
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

            double average = (double)sum / 5;

            Console.WriteLine("The average mark is: " + average);
        }

    }
}
