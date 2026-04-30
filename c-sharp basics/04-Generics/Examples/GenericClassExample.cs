namespace Examples;


public class Box<T>{

    public T? content;
}


public class GenericClassExample{

    public static void Run(){

        Console.WriteLine("=== This is Generic class example ===");

        Box<int> intBox = new Box<int>();
        intBox.content = 123;
        Console.WriteLine($"This is integer content {intBox.content}");

        Box<string> stringBox = new Box<string>();
        stringBox.content = "Hello from generics";
        Console.WriteLine($"This is string content {stringBox}");
    }
}

