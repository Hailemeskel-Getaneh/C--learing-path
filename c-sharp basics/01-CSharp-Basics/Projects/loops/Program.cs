using System;

class Program {


static void Main(){

 while(true){

   Console.WriteLine("1. Password Checker");
   Console.WriteLine("2. Number Sum");
   Console.WriteLine("0. to exit");

if( !int.TryParse(Console.ReadLine(), out int choice)){
     Console.WriteLine("Invalid choice. Please try again");
     continue;
}
     
      switch (choice){
        case 1:
           Exercise.passwordChecker();
           break;
        case 2 :
           Exercises.numberSum();
           break;
        case 0:
          return;
        default:
            Console.WriteLine("Invalid Choice");
            break;
     }

 }
    

}


}