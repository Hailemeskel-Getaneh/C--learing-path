using System;

class Program
{
    static void Main()
    {
        ShowTitle();

        string studentName = GetStudentName();

        int exam1 = GetScore("Exam 1");
        int exam2 = GetScore("Exam 2");
        int exam3 = GetScore("Exam 3");

        double average = CalculateAverage(exam1, exam2, exam3);

        char grade = DetermineGrade(average);

        PrintReport(studentName, average, grade);

        // Demonstrate ref parameter
        int bonus = 5;
        AddBonus(ref exam1, bonus);

        Console.WriteLine($"\nExam1 after bonus (ref example): {exam1}");

        // Demonstrate out parameter
        GetMinMax(exam1, exam2, exam3, out int min, out int max);
        Console.WriteLine($"Lowest score: {min}, Highest score: {max}");

        // Demonstrate in parameter
        DisplayAverage(in average);

        // Demonstrate recursion
        Console.WriteLine($"\nFactorial of 5 (recursion example): {Factorial(5)}");

        Console.WriteLine("\nProgram finished.");
    }

    // VOID METHOD
    static void ShowTitle()
    {
        Console.WriteLine("===== STUDENT GRADE MANAGER =====\n");
    }

    // METHOD RETURNING VALUE
    static string GetStudentName()
    {
        Console.Write("Enter student name: ");
        return Console.ReadLine();
    }

    // METHOD WITH PARAMETER
    static int GetScore(string examName)
    {
        Console.Write($"Enter {examName} score: ");
        return int.Parse(Console.ReadLine());
    }

    // METHOD WITH RETURN VALUE
    static double CalculateAverage(int a, int b, int c)
    {
        return (a + b + c) / 3.0;
    }

    // METHOD USING CONDITIONS
    static char DetermineGrade(double avg)
    {
        if (avg >= 90) return 'A';
        else if (avg >= 80) return 'B';
        else if (avg >= 70) return 'C';
        else if (avg >= 60) return 'D';
        else return 'F';
    }

    // DEFAULT PARAMETER
    static void PrintReport(string name, double avg, char grade, string course = "Programming")
    {
        Console.WriteLine("\n===== REPORT =====");
        Console.WriteLine($"Student: {name}");
        Console.WriteLine($"Course: {course}");
        Console.WriteLine($"Average: {avg:F2}");
        Console.WriteLine($"Grade: {grade}");
    }

    // REF PARAMETER
    static void AddBonus(ref int score, int bonus)
    {
        score += bonus;
    }

    // OUT PARAMETERS
    static void GetMinMax(int a, int b, int c, out int min, out int max)
    {
        min = Math.Min(a, Math.Min(b, c));
        max = Math.Max(a, Math.Max(b, c));
    }

    // IN PARAMETER
    static void DisplayAverage(in double avg)
    {
        Console.WriteLine($"\nAverage (read-only using 'in'): {avg + 4}");
    }

    // METHOD OVERLOADING
    static int Sum(int a, int b)
    {
        return a + b;
    }

    static int Sum(int a, int b, int c)
    {
        return a + b + c;
    }

    // EXPRESSION-BODIED METHOD
    static int Square(int x) => x * x;

    // RECURSION
    static int Factorial(int n)
    {
        if (n == 1) return 1;

        return n * Factorial(n - 1);
    }
}