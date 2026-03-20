namespace Examples;

public class GenericDictionaryExample
{
    public static void Run()
    {
        Console.WriteLine("--- Generic Dictionary<TKey, TValue> Example ---");

        // Dictionary mapping ID (int) to Name (string)
        Dictionary<int, string> employeeNames = new Dictionary<int, string>();
        employeeNames.Add(101, "John Doe");
        employeeNames.Add(102, "Jane Smith");
        employeeNames.Add(103, "Bob Johnson");

        Console.WriteLine("Employees:");
        foreach (var entry in employeeNames)
        {
            Console.WriteLine($"ID: {entry.Key}, Name: {entry.Value}");
        }

        if (employeeNames.TryGetValue(102, out string? name))
        {
            Console.WriteLine($"Found Employee 102: {name}");
        }

        Console.WriteLine();
    }
}
