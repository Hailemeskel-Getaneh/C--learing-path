namespace Examples;

public class Sample<T>{

    public T? value;

    public void show(){
        Console.WriteLine(value);
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