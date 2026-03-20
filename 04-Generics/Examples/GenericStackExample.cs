namespace Examples;

public class GenericStackExample
{
    public static void Run()
    {
        Console.WriteLine("--- Generic Stack<T> Example (LIFO) ---");

        Stack<string> browserHistory = new Stack<string>();
        browserHistory.Push("google.com");
        browserHistory.Push("github.com");
        browserHistory.Push("stackoverflow.com");

        Console.WriteLine($"Current Top: {browserHistory.Peek()}");

        while (browserHistory.Count > 0)
        {
            string page = browserHistory.Pop();
            Console.WriteLine($"Going back from: {page}");
        }

        Console.WriteLine();
    }
}
