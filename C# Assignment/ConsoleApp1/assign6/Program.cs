using System;

namespace ASCIIValuePrinter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a character: ");
            char inputChar = Convert.ToChar(Console.ReadLine());

            int asciiValue = (int)inputChar;

            Console.WriteLine("The ASCII value of " + inputChar + " is: " + asciiValue);
        }
    }
}