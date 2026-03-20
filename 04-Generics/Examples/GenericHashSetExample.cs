namespace Examples;


public class GenericHashSetExample
{
    public static void Run()
    {
       Console.WriteLine("--- Generic HashSet<T> Example (Unique Items) ---");

        HashSet<int> uniqueNumbers = new HashSet<int>();
        uniqueNumbers.Add(1);
        uniqueNumbers.Add(2);
        uniqueNumbers.Add(2); // Duplicate - will be ignored
        uniqueNumbers.Add(3);

        Console.WriteLine("Unique numbers in set:");
        foreach (int num in uniqueNumbers)
        {
            Console.WriteLine($"- {num}");
        }

        Console.WriteLine($"Contains 2? {uniqueNumbers.Contains(2)}");
        Console.WriteLine($"Set Count: {uniqueNumbers.Count}");

        Console.WriteLine();
    }
}
