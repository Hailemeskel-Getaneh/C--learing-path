
class Program {

   static void Main(){

        Console.WriteLine(" == String Manipulation Program ==");

        // user input

        Console.WriteLine("Enter your Name");
        string name = Console.ReadLine();

        // check whitespace or null

        if(string.IsNullOrWhiteSpace(name)){
            Console.WriteLine("Name cannot be Null");
            return;
        }

        // trim space

        name = name.Trim();
        Console.WriteLine($"Hello {name}");

    // uppercase and lowercase
    Console.WriteLine($"Uppercase : {name.ToUpper()}");
    Console.WriteLine($"Lowercase: {name.ToLower()}");

    // Looping through string
    Console.WriteLine("Characters in your name");

    foreach( char c in name){

        Console.WriteLine(c + " ");
    }

    Console.WriteLine();

    // substring
    if(name.Length >= 3){
        Console.WriteLine($"The first three letters {name.Substring(0, 3)}");
    }

    //replacing
    string replaced = name.Replace("a", "*");
    Console.WriteLine($" a is replaced by * {replaced}");

    //starts and ends

    Console.WriteLine($"Starts with H ? {name.StartsWith("H")}");
    Console.WriteLine($"Ends with l ? {name.EndsWith("l")}");

    // contains

    Console.WriteLine($"Contains s {name.Contains("s")}");

    // spliting

    Console.WriteLine("Spliting into parts");

    string[] parts = name.Split(" ");

    foreach (string part in parts){
        Console.WriteLine( part);
    }

    Console.WriteLine(); // printing new line

 // Changing to character array

   char[] letters = name.ToCharArray();

   Console.WriteLine("Char Array:");
   foreach(char letter in letters){
    Console.WriteLine($"{letter}-");

   }

   Console.WriteLine();

   // accepting number input
Console.WriteLine("Enter you age");
string ageInput = Console.ReadLine();

if(int.TryParse(ageInput, out int age)){
    Console.WriteLine($"Next year you wil be {age + 1}");
    Console.WriteLine($" Your age as a string {age.ToString()}");
}

else {
    Console.WriteLine("Invalid age input");
}

//String Comparision

Console.WriteLine("Enter a word");
string word = Console.ReadLine();
if(word.Equals("hello", StringComparison.OrdinalIgnoreCase)){
    Console.WriteLine("you typed hello");
}




Console.WriteLine("\n Program Finished");


   }






}