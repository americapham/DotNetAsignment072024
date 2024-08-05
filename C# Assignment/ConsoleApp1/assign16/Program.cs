using System;

class Program
{
    /**
     * program to display whether a user-entered number is a prime number
     */
    static bool IsPrime(int number)
    {
        if (number <= 1)
        {
            return false;
        }
        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }
        return true;
    }

    /**
     * Display the first 25 prime numbers using a while loop
     */
    static void DisplayTheFirst25PrimeNumbers()
    {
        int count = 0;
        int number = 2;

        while (count < 25)
        {
            if (IsPrime(number))
            {
                Console.Write($"{number} ");
                count++;
            }
            number++;
        }
    }

    static void Main()
    {
        Console.Write("Enter a number: ");
        int input = int.Parse(Console.ReadLine());

        if (IsPrime(input))
        {
            Console.WriteLine($"{input} is a prime number.");
        }
        else
        {
            Console.WriteLine($"{input} is not a prime number.");
        }

        Console.WriteLine("========================================");
        Console.WriteLine("The first 25 prime numbers: ");
        DisplayTheFirst25PrimeNumbers();
    }
}
