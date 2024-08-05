using System;

namespace EmployeeDetails
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the Employee Number: ");
            int empNo = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the Department Number: ");
            int deptNo = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the Designation Code: ");
            char desigCode = Convert.ToChar(Console.ReadLine());

            string departmentName = "";
            string designation = "";

            switch (deptNo)
            {
                case 10:
                    departmentName = "Purchase";
                    break;
                case 20:
                    departmentName = "Sales";
                    break;
                case 30:
                    departmentName = "Production";
                    break;
                case 40:
                    departmentName = "Marketing";
                    break;
                case 50:
                    departmentName = "Accounts";
                    break;
                default:
                    departmentName = "Unknown";
                    break;
            }

            switch (Char.ToUpper(desigCode))
            {
                case 'M':
                    designation = "Manager";
                    break;
                case 'S':
                    designation = "Supervisor";
                    break;
                case 'A':
                    designation = "Analyst";
                    break;
                default:
                    designation = "Unknown";
                    break;
            }

            Console.WriteLine("\nEmployee Number: " + empNo);
            Console.WriteLine("Department Number: " + deptNo + " (" + departmentName + ")");
            Console.WriteLine("Designation Code: " + desigCode + " (" + designation + ")");
        }
    }
}