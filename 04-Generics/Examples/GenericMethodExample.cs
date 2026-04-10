namespace Examples;

public class GenericMethodExample{

        public static void Run(){

            Console.WriteLine("=== Swapping ( Generic Method ) ");

            int num1 = 5 , num2 = 7;
            string str1 = "Hello";
            string str2 = "World";

 // swaping integer
            Console.WriteLine("Before Swapping Integers");
            Console.WriteLine($"First Number: {num1} and Second Number: {num2}");

            swap(ref num1, ref num2);
            Console.WriteLine("After Swapping Integers");
            Console.WriteLine($"First Number: {num1} and Second Number: {num2}");

//swapping strings
            Console.WriteLine("Before Swapping strings");
            Console.WriteLine($"First string: {str1} and Second string: {str2}");

            swap(ref str1, ref str2);
             Console.WriteLine("After Swapping Strings");
            Console.WriteLine($"First string: {str1} and Second string: {str2}");


        }


        public static void swap<T>(ref T first, ref T second){

            T temp = first;
            first = second;
            second = temp;
        }






}