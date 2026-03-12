
public class Exercises{


    public void numberSum(){
    
    int n = 0;
    int result = 0;
    while(true){

        Console.WriteLine("Enter a number:");
     n = Convert.ToInt32(Console.ReadLine());

     for(int i = 1; i <= n; i++){
        
           result = result  +  i;
     }

    Console.WriteLine(result);
     
     result = 0;

  
    Console.WriteLine("Enter y to contiue or n to exit");
    char response = char.Parse (Console.ReadLine()) ?? "";
    if(char.ToLower(response) != 'y'){
        return;

    }

    
}
    }


}