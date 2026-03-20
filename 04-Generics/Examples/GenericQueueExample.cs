namespace Examples;

public class GenericQueueExample
{
    public static void Run()
    {
        Console.WriteLine("--- Generic Queue<T> Example (FIFO) ---");

        Queue<string> printQueue = new Queue<string>();
        printQueue.Enqueue("Document1.pdf");
        printQueue.Enqueue("Image.png");
        printQueue.Enqueue("Report.docx");

        Console.WriteLine($"Current Queue Count: {printQueue.Count}");

        while (printQueue.Count > 0)
        {
            string document = printQueue.Dequeue();
            Console.WriteLine($"Processing: {document}");
        }

        Console.WriteLine();
    }
}
