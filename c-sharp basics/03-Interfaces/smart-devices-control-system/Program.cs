using models;


class SmartLight :ISmartDevice {

   public string Name { get; private set;}
   private bool isOn;

   public SmartLight(string name) => Name = name;

   public void TurnOn(){isOn = true;}
   public void TurnOff(){isOn = true;}
   
   public void ShowStatus(){
    Console.WriteLine($"{Name} Light is {(isOn ? "On": "Off")}");
   }

  public void showScreen(ISmartDevice device){

      
       
  }

}

class SmartTV : ISmartDevice {

    public string Name{get; private set;}
    private bool isOn;
    private int channelNumber = 1;


    public SmartTV(string name) => Name = name;

    public void TurnOn(){isOn = true;}
    public void TurnOff(){isOn = false;}
    public void ShowStatus(){
        Console.WriteLine($"{Name} TV is {(isOn ? "On." : "Off.")} ");
    }

       // slef method

   public void changeChannel(int channel){

        if(isOn){
            channelNumber = channel;
           Console.WriteLine($"The Tv is on Channel {channelNumber}");
        }
         else{
            Console.WriteLine("The TV is off. Can't change the channel");
         }
   }
}

class Program {

    public static void Main(){

        ISmartDevice[] devices = new ISmartDevice[2];
        devices[0] = new SmartLight("Living Room");
        devices[1] = new SmartTV("Sallon");

        // Show initial state of the devices
        Console.WriteLine("=== Initial Status of Devices ===");
        foreach(ISmartDevice device in devices)
                device.ShowStatus();
        
        // Change the status of the devices
        foreach(ISmartDevice device in devices)
                device.TurnOn();
        
        // show final state of the devices
        Console.WriteLine("=== After changing the status ===");
        foreach(ISmartDevice device in devices)
                device.ShowStatus();

        // change tv channel using downcasting or pattern matching
        foreach(ISmartDevice device in devices){
        
        //let's make the devices off
         device.TurnOff();
          if(device is SmartTV tv){

                Console.WriteLine("Enter the channel number: ");
                int channel = int.Parse(Console.ReadLine());
                 tv.changeChannel(channel);
             }
        }

    }
}