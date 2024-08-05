using System;

class Program
{
    static void Main()
    {
        for (int i = 0; i <= 255; i++)
        {
            Console.Write($"{(char)i} ");

            if (i % 10 == 9)
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
