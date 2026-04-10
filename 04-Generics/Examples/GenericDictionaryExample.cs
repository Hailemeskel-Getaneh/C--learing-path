namespace Examples;

public class GenericDictionaryExample{

    public static void Run(){
        
        Console.WriteLine("=== Generic Dictionary<TKey, TValue> example ====");

        Dictionary<int, string> employeeNames = new Dictionary<int, string>();
    
        // add values to the dictionary
        employeeNames.Add(1, "Hailemeskel");
        employeeNames.Add(2, "Selamawit Girma");
        employeeNames[3] = "Dagnachew";

        // loop through the dict and display values

        foreach(var (id, name) in employeeNames ){
            Console.WriteLine($"Id:{id}, Name {name}");
        }

        //try a safe getting value with an index

        if(employeeNames.TryGetValue(2, out string? name)){
            Console.WriteLine($"Found Employee: {name}");
        }
        Console.WriteLine();

    }
}