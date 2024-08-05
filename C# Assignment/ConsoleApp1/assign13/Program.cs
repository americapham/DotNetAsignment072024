using System;

class Program
{
    static int DaysInMonth(int month, int year)
    {
        if (month == 2)
        {
            if (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0))
            {
                return 29;
            }
            else
            {
                return 28;
            }
        }
        else if (month == 4 || month == 6 || month == 9 || month == 11)
        {
            return 30;
        }
        else
        {
            return 31;
        }
    }

    static string MonthName(int month)
    {
        string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        return months[month - 1];
    }

    static void Main()
    {
        Console.Write("Enter date in dd/mm/yy format: ");
        string input = Console.ReadLine();
        string[] dateParts = input.Split('/');
        int day = int.Parse(dateParts[0]);
        int month = int.Parse(dateParts[1]);
        int year = int.Parse(dateParts[2]);

        int totalDays = DaysInMonth(month, year);
        string monthName = MonthName(month);

        Console.WriteLine($"Total number of days in {monthName} {year} is {totalDays}.");
    }
}