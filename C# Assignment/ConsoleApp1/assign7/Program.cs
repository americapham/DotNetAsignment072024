using System;

namespace NetSalaryCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the basic salary: ");
            double basicSalary = Convert.ToDouble(Console.ReadLine());

            double hra = 0.20 * basicSalary;
            double da = 0.40 * basicSalary;
            double grossSalary = basicSalary + hra + da;
            double pf = 0.10 * grossSalary;
            double netSalary = grossSalary - pf;

            Console.WriteLine("HRA: " + hra);
            Console.WriteLine("DA: " + da);
            Console.WriteLine("Gross Salary: " + grossSalary);
            Console.WriteLine("PF: " + pf);
            Console.WriteLine("Net Salary: " + netSalary);
        }
    }
}