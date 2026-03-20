namespace Examples;

public class GenericMethodExample
{
    public static void Run()
    {
        Console.WriteLine("--- Generic Method Example ---");

        int a = 5, b = 10;
        Console.WriteLine($"Before Swap: a = {a}, b = {b}");
        Swap(ref a, ref b);
        Console.WriteLine($"After Swap:  a = {a}, b = {b}");

        string s1 = "World", s2 = "Hello";
        Console.WriteLine($"Before Swap: s1 = {s1}, s2 = {s2}");
        Swap(ref s1, ref s2);
        Console.WriteLine($"After Swap:  s1 = {s1}, s2 = {s2}");

        Console.WriteLine();
    }

    // A generic method to swap two values
    public static void Swap<T>(ref T lhs, ref T rhs)
    {
        T temp = lhs;
        lhs = rhs;
        rhs = temp;
    }
}
