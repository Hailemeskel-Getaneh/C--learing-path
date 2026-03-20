namespace Examples;

public class GenericConstraintsExample
{
    public static void Run()
    {
        Console.WriteLine("--- Generic Constraints Example ---");

        var repository = new Repository<User>();
        repository.Add(new User { Name = "Alice" });
        repository.Add(new User { Name = "Bob" });

        Console.WriteLine("Users in repository:");
        foreach (var user in repository.GetAll())
        {
            Console.WriteLine($"- {user.Name}");
        }

        Console.WriteLine();
    }
}

public class User
{
    public string Name { get; set; } = string.Empty;
}

// Generic class with constraints
// T must be a class and have a parameterless constructor
public class Repository<T> where T : class, new()
{
    private readonly List<T> _items = new List<T>();

    public void Add(T item) => _items.Add(item);

    public List<T> GetAll() => _items;
}
