using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assign11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Using If-Else
            Console.WriteLine("======== Using If-Else ============ ");
            Console.Write("Enter the first number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the second number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the third number: ");
            int num3 = Convert.ToInt32(Console.ReadLine());

            if (num1 >= num2 && num1 >= num3)
            {
                Console.WriteLine("The maximum number is: " + num1);
            }
            else if (num2 >= num1 && num2 >= num3)
            {
                Console.WriteLine("The maximum number is: " + num2);
            }
            else
            {
                Console.WriteLine("The maximum number is: " + num3);
            }


            // using Condition
            Console.WriteLine("======== Using Condition ============ ");
            Console.Write("Enter the first number: ");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the second number: ");
            num2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the third number: ");
            num3 = Convert.ToInt32(Console.ReadLine());

            int max = (num1 >= num2 && num1 >= num3) ? num1 : (num2 >= num1 && num2 >= num3) ? num2 : num3;

            Console.WriteLine("The maximum number is: " + max);

        }
    }
}
