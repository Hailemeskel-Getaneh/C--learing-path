using Examples;

while (true)
{
    Console.WriteLine("Select a Generics Example to run:");
    Console.WriteLine("1. Generic Class Example");
    Console.WriteLine("2. Generic Method Example");
    Console.WriteLine("3. Generic Constraints Example");
    Console.WriteLine("4. Generic List<T> Example");
    Console.WriteLine("5. Generic Dictionary<TKey, TValue> Example");
    Console.WriteLine("6. Generic Queue<T> Example");
    Console.WriteLine("7. Generic Stack<T> Example");
    Console.WriteLine("8. Generic HashSet<T> Example");
    Console.WriteLine("9. Custom Sample Example (User Created)");
    Console.WriteLine("0. Exit");
    Console.WriteLine("\nEnter choice: ");

    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            GenericClassExample.Run();
            break;
        case "2":
            GenericMethodExample.Run();
            break;
        case "3":
            GenericConstraintsExample.Run();
            break;
        case "4":
            GenericListExample.Run();
            break;
        case "5":
            GenericDictionaryExample.Run();
            break;
        case "6":
            GenericQueueExample.Run();
            break;
        case "7":
            GenericStackExample.Run();
            break;
        case "8":
            GenericHashSetExample.Run();
            break;
      
        case "9":
            SampleExample.Run();
            break;
        case "0":
            return;
        default:
            Console.WriteLine("Invalid choice, try again.");
            break;
    }

    Console.WriteLine("\nPress any key to continue...");
    Console.ReadKey();
    Console.Clear();
}
