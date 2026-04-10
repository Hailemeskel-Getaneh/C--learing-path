namespace Examples;

public class Sample<T>{

    public T? value;

    public void show(){
        Console.WriteLine(value);

// Display the length of the value if the value is string
        if(value is string s){
        
         Console.WriteLine(s.Length);

        }

        else if(value is int i){
            Console.WriteLine("value is integer and cannot conpute the lenght");
        }

    }

}

public class SampleExample{


 public static void Run(){

  Sample<int> a = new Sample<int>();
       a.value = 23;
       a.show();

    Sample<string> b = new Sample<string>();
     b.value = "Hello";
     b.show();

 }
  

}