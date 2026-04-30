
public class Exercise{
public static void passwordChecker(){

    string password = "admin123";
    int trial = 0;
    int maxTrial = 3;

    do
      {

      Console.WriteLine("Enter your Password:");
      string newPassword = Console.ReadLine() ?? "";
      
        trial++;

      if( password == newPassword){
         Console.WriteLine(" You are successfully logged in");
         break;
      }

      else{
        Console.WriteLine("Incorrect password please try again");
      }

      if(trial == maxTrial)
      {
        Console.WriteLine("Trial Limit reached. Please try after 1 minute");
        break;
      }

    }

    while(true);

}
}