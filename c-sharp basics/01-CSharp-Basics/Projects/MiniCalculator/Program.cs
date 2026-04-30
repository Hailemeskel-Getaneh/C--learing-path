using System;

// Mini Calculator — Practice project for C# Basics
// Covers: variables, methods, conditions, loops, user input

// FACADE
//class design


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Mini Calculator ===\n");
        bool running = true;

        while (running)
        {
            Console.WriteLine("Choose an operation:");
            Console.WriteLine("1 - Add");
            Console.WriteLine("2 - Subtract");
            Console.WriteLine("3 - Multiply");
            Console.WriteLine("4 - Divide");
            Console.WriteLine("5 - Exit");
            Console.Write("\nChoice: ");

            string input = Console.ReadLine();

            if (input == "5")
            {
                Console.WriteLine("Goodbye!");
                running = false;
                break;
            }

            Console.Write("First number: ");
            if (!double.TryParse(Console.ReadLine(), out double a))
            {
                Console.WriteLine("That's not a valid number. Try again.\n");
                continue;
            }

            Console.Write("Second number: ");
            if (!double.TryParse(Console.ReadLine(), out double b))
            {
                Console.WriteLine("That's not a valid number. Try again.\n");
                continue;
            }

            double result;

            switch (input)
            {
                case "1":
                    result = Add(a, b);
                    Console.WriteLine($"\nResult: {a} + {b} = {result}\n");
                    break;
                case "2":
                    result = Subtract(a, b);
                    Console.WriteLine($"\nResult: {a} - {b} = {result}\n");
                    break;
                case "3":
                    result = Multiply(a, b);
                    Console.WriteLine($"\nResult: {a} * {b} = {result}\n");
                    break;
                case "4":
                    if (b == 0)
                    {
                        Console.WriteLine("\nCan't divide by zero.\n");
                        break;
                    }
                    result = Divide(a, b);
                    Console.WriteLine($"\nResult: {a} / {b} = {result}\n");
                    break;
                default:
                    Console.WriteLine("Invalid choice.\n");
                    break;
            }
        }
    }

    static double Add(double a, double b) => a + b;
    static double Subtract(double a, double b) => a - b;
    static double Multiply(double a, double b) => a * b;
    static double Divide(double a, double b) => a / b;
}
