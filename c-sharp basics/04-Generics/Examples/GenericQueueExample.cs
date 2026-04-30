namespace Examples;


public class GenericQueueExample {

    public static void Run(){

        Console.WriteLine("=== Queue (FIFO) ====");

        Queue<string> tasks = new Queue<string>();

        tasks.Enqueue("Studying");
        tasks.Enqueue("Praying");
        tasks.Enqueue("Eating");
        tasks.Enqueue("Sleeping");


        Console.WriteLine($"There are {tasks.Count} tasks");

        foreach( string task in tasks){
            Console.WriteLine(task);
        }

       Console.WriteLine($"Removing the first task {tasks.Dequeue()}") ;

       Console.WriteLine($"Now, the first task is {tasks.Peek()}");

       Console.WriteLine($"The task list contains Coding ? {tasks.Contains("Coding")}");

    }
}