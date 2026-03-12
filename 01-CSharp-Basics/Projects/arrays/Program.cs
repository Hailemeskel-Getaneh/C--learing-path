using System;
using System.Linq;

class Program {
    static void Main() {
        string[] students = { "Senay", "Elias", "Girum", "Henok" };

        while (true) {
            Console.WriteLine("\nEnter the name of the student:");
            string input = Console.ReadLine()?.Trim() ?? "";

            bool found = false;
            foreach (string student in students) {
                if (student.Equals(input, StringComparison.OrdinalIgnoreCase)) {
                    found = true;
                    break; 
                }
            }

            if (found) {
                Console.WriteLine("This student exists in the list");
            } else {
                Console.WriteLine("This user does not exist");
            }

            Console.WriteLine("Enter 'y' to continue or any other key to exit:");
            string response = Console.ReadLine()?.ToLower() ?? "";

            if (response != "y") {
                break;
            }
        }
    }
}
