namespace Examples;



public class GenericListExample
{
    public static void abc()
    {
        Console.WriteLine("--- Generic List<T> Example ---");

        // List of strings
        List<string> fruits = new List<string>();
        fruits.Add("Apple");
        fruits.Add("Banana");
        fruits.Add("Cherry");

        Console.WriteLine("Items in list:");
        foreach (var fruit in fruits)
        {
            Console.WriteLine($"- {fruit}");
        }

        Console.WriteLine($"Total items: {fruits.Count}");
        Console.WriteLine();
    }
}
