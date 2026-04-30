public interface IMyInterface
{
    // Declaring a delegate type inside the interface (C# 8.0+)
    public delegate void MyDelegateType(string message);
}
public interface IMyInterface
{
    // Property that holds a delegate instance
    Action<string> OnMessageReceived { get; set; }

    // Standard event using a delegate type
    event EventHandler ProcessCompleted;
}


public interface IProcessor
{
    // Interface method accepting a delegate
    void ProcessData(int data, Action<bool> callback);
}



inteface outside