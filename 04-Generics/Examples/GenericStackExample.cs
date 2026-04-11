namespace Examples;


public class GenericStackExample{

    public static void Run(){

        Console.WriteLine("=== Generic Stack Example ===");

        Stack<string> tools = new Stack<string>();


        // add items at the top 

        tools.Push("Hammer");
        tools.Push("Wrench");
        tools.Push("Level");
        tools.Push("Mallet");

        foreach(string tool in tools ){
            Console.WriteLine(tool);
        }

        Console.WriteLine($"The top of the tools is  {tools.Peek()}");

        Console.WriteLine($"There are {tools.Count} tools.");

        Console.WriteLine($"Tool Removed from the top  is {tools.Pop()}");
    }
}