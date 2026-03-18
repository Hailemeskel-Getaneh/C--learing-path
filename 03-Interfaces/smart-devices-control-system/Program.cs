using System;

// Here is the interface, sort of like a contract for all devices
interface ISmartDevice
{
    string Name { get; }
    void TurnOn();
    void TurnOff();
    void ShowStatus();
}

// creating the first device, a smart light
class SmartLight : ISmartDevice
{
    public string Name { get; private set; }
    private bool isOn;

    public SmartLight(string name) => Name = name;

    public void TurnOn() { isOn = true; }
    public void TurnOff() { isOn = false; }

    public void ShowStatus() =>
        Console.WriteLine($"{Name} Light is {(isOn ? "ON" : "OFF")}");
}

// let's making another one, maybe a fan is good here
class SmartFan : ISmartDevice
{
    public string Name { get; private set; }
    private bool isOn;

    public SmartFan(string name) => Name = name;

    public void TurnOn() { isOn = true; }
    public void TurnOff() { isOn = false; }

    public void ShowStatus() =>
        Console.WriteLine($"{Name} Fan is {(isOn ? "ON" : "OFF")}");
}

// TODO:SmartTV or Thermostat later

// testing the devices in the main program
class Program
{
    static void Main()
    {
        ISmartDevice[] devices = new ISmartDevice[2]; 
        devices[0] = new SmartLight("Living Room");
        devices[1] = new SmartFan("Bedroom");
        // devices[2] = new SmartThermostat("Hallway", 22); // I'll do this one later

        Console.WriteLine("--- Initial Status ---");
        foreach (ISmartDevice device in devices)
            device.ShowStatus();

        Console.WriteLine("\n--- Turning Devices On ---");
        foreach (ISmartDevice device in devices)
            device.TurnOn();

        foreach (ISmartDevice device in devices)
            device.ShowStatus();

        // checking final status to see if it works
        Console.WriteLine("\n--- Final Status ---");
        foreach (ISmartDevice device in devices)
            device.ShowStatus();
    }
}
