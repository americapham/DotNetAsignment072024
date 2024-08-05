using System;

namespace SalesCommissionCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the basic salary: ");
            double basicSalary = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter the total sales amount: ");
            double salesAmount = Convert.ToDouble(Console.ReadLine());

            double commission = 0;

            if (salesAmount >= 5000 && salesAmount <= 7500)
            {
                commission = salesAmount * 0.03;
            }
            else if (salesAmount > 7500 && salesAmount <= 10500)
            {
                commission = salesAmount * 0.08;
            }
            else if (salesAmount > 10500 && salesAmount <= 15000)
            {
                commission = salesAmount * 0.11;
            }
            else if (salesAmount > 15000)
            {
                commission = salesAmount * 0.15;
            }

            double netSalary = basicSalary + commission;

            Console.WriteLine("Commission earned: " + commission);
            Console.WriteLine("Net Salary: " + netSalary);
        }
    }
}