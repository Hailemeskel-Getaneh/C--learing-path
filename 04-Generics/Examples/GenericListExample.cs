namespace Examples;

public class GenericListExample{

    public static void Run(){

        List<string> names = new List<string>();

        // add element to the list
        names.Add("Hailemeskel");
        names.Add("Eliyas");
        names.Add("Esayas");

        //Add multiple elements at a time
        names.AddRange(new List<string> {"Selam", "Henok", "yared"});

        //Insert at a specific index
        names.Insert(1, "Ayalew");

        //Access elements
        Console.WriteLine($"First Element {names[0]}");

        // iterate through the items
           void display(List<string> Names){
            Console.WriteLine("\n All names");
                    foreach(var name in Names){

                        Console.WriteLine(name);
                    }
        }

        // find Element
        string found = names.Find(n => n.StartsWith("A"));
        Console.WriteLine($"Found: {found}");

        //Check existence of an element
        bool exists = names.Contains("Alemayehu");
        Console.WriteLine($"Contains Alemayehu: {exists}");

        //Get index
        int index = names.IndexOf("Hailemeskel");
        Console.WriteLine($"Index of Hailemeskel: {index}");

        // Remove element
        names.Remove("Eliyas");

        //Remove at index
        names.RemoveAt(4);

        //Count element of the list
        Console.WriteLine($"The are {names.Count} elements");

        //sort ascending
        names.Sort();

        Console.WriteLine("After Removing two elements are sorting");
        display(names);

        // Reverse => used for descending sort 
        names.Reverse();

        //Convert to array
        string[] array = names.ToArray();

        // clear elements
        names.Clear();


        Console.WriteLine($"After clearing , there are {names.Count} elementsts");




    }
}