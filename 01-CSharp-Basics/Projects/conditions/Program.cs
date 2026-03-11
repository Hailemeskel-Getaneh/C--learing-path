
class Program {

   static void Main(){
    
    Console.WriteLine("Choise Exercise: ");
    Console.WriteLine("1. Status Code ");
    Console.WriteLine("2. Temprature Evaluator");
    Console.WriteLine("3. Even  or odd checker");

    int choice = int.Parse(Console.ReadLine() ?? "0");

    switch(choice){

        case 1:
             statusCode();
             break;
        case 2:
             TempratureEvalutor();
             break;
        case 3:
             gradeEvaluator();
             break;
        default:
                Console.WriteLine("Invalid Choice");
                break;
    }
   }

    static void statusCode(){

        Console.WriteLine("Enter status code: ");
        int status = int.Parse(Console.ReadLine() ?? "0");

        string message = status switch{
             
             200 => "It is okay",
             201 => "Created successfully",
             300 => "Redirection",
             401 => "Unauthenticated",
             403 => "unauthorized",
             404 => "Not found",
             500 => "Server Error",
             _ => "Unknown error"

        };

        Console.WriteLine(message);
    }

    static void TempratureEvalutor(){

        Console.WriteLine("Enter the temprature: ");
        String temp = Console.ReadLine();

        if(!double.TryParse(temp, out double result)){
            Console.WriteLine("Invalid input. Please Enter valid number");
        }
        else{

            switch(result){

                case < 10:
                   Console.WriteLine("It's cold");
                   break;
                case  >= 10 and <= 25:
                  Console.WriteLine("It it Normal");
                  break;
                case > 25:
                    Console.WriteLine("It's warm");
                    break;
            }

        }
    }


    static void gradeEvaluator(){
        Console.WriteLine("Enter your score (0-100): ");
        if (int.TryParse(Console.ReadLine(), out int score)) {
            string grade = score switch {
                >= 90 => "A",
                >= 80 => "B",
                >= 70 => "C",
                >= 60 => "D",
                _ => "F"
            };
            Console.WriteLine($"Your grade is: {grade}");
        } else {
            Console.WriteLine("Invalid score entered.");
        }
    }



}