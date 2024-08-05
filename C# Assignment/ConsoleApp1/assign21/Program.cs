namespace assign21
{
    using System;

    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Select a shape:");
                Console.WriteLine("a. Square");
                Console.WriteLine("b. Circle");
                Console.WriteLine("c. Rectangle");
                Console.WriteLine("d. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                if (choice == "a")
                {
                    Console.Write("Enter the side length of the square: ");
                    double side = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Select an operation:");
                    Console.WriteLine("i. Calculate area");
                    Console.WriteLine("ii. Calculate perimeter");
                    Console.WriteLine("iii. Calculate area and perimeter both");
                    Console.Write("Enter your choice: ");
                    string operation = Console.ReadLine();
                    if (operation == "i")
                    {
                        Console.WriteLine("Area of the square: " + (side * side));
                    }
                    else if (operation == "ii")
                    {
                        Console.WriteLine("Perimeter of the square: " + (4 * side));
                    }
                    else if (operation == "iii")
                    {
                        Console.WriteLine("Area of the square: " + (side * side));
                        Console.WriteLine("Perimeter of the square: " + (4 * side));
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice");
                    }
                }
                else if (choice == "b")
                {
                    Console.Write("Enter the radius of the circle: ");
                    double radius = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Select an operation:");
                    Console.WriteLine("i. Calculate area");
                    Console.WriteLine("ii. Calculate perimeter");
                    Console.WriteLine("iii. Calculate area and perimeter both");
                    Console.Write("Enter your choice: ");
                    string operation = Console.ReadLine();
                    if (operation == "i")
                    {
                        Console.WriteLine("Area of the circle: " + (Math.PI * radius * radius));
                    }
                    else if (operation == "ii")
                    {
                        Console.WriteLine("Perimeter of the circle: " + (2 * Math.PI * radius));
                    }
                    else if (operation == "iii")
                    {
                        Console.WriteLine("Area of the circle: " + (Math.PI * radius * radius));
                        Console.WriteLine("Perimeter of the circle: " + (2 * Math.PI * radius));
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice");
                    }
                }
                else if (choice == "c")
                {
                    Console.Write("Enter the length of the rectangle: ");
                    double length = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Enter the width of the rectangle: ");
                    double width = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Select an operation:");
                    Console.WriteLine("i. Calculate area");
                    Console.WriteLine("ii. Calculate perimeter");
                    Console.WriteLine("iii. Calculate area and perimeter both");
                    Console.Write("Enter your choice: ");
                    string operation = Console.ReadLine();
                    if (operation == "i")
                    {
                        Console.WriteLine("Area of the rectangle: " + (length * width));
                    }
                    else if (operation == "ii")
                    {
                        Console.WriteLine("Perimeter of the rectangle: " + (2 * (length + width)));
                    }
                    else if (operation == "iii")
                    {
                        Console.WriteLine("Area of the rectangle: " + (length * width));
                        Console.WriteLine("Perimeter of the rectangle: " + (2 * (length + width)));
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice");
                    }
                }
                else if (choice == "d")
                {
                    Console.WriteLine("Exiting the program");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice");
                }
            }
        }
    }
}
