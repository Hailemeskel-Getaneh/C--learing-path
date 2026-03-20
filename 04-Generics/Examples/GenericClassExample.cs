namespace Examples;

public class GenericClassExample
{
    public static void Run()
    {
        Console.WriteLine("--- Generic Class Example ---");

        // Create a Box for integers
        Box<int> intBox = new Box<int>();
        intBox.Content = 123;
        Console.WriteLine($"Integer Box content: {intBox.Content}");

        // Create a Box for strings
        Box<string> stringBox = new Box<string>();
        stringBox.Content = "Hello Generics";
        Console.WriteLine($"String Box content: {stringBox.Content}");

        Console.WriteLine();
    }
}

// here is a simple generic class

public class Box<T>
{
    public T? Content { get; set; }
}
