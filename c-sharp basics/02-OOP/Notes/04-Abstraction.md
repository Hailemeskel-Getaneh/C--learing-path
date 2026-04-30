# Abstraction

Abstraction is the process of hiding complex implementation details and showing only the necessary features of an object. It focuses on *what* an object does rather than *how* it does it.

In C#, we achieve abstraction using **Abstract Classes** and **Interfaces**.

## Abstract Classes
An abstract class cannot be instantiated (you can't do `new Shape()`). It exists only to be inherited from.

```csharp
public abstract class Shape
{
    // Abstract method: No body, must be implemented by child classes
    public abstract double GetArea();

    // Regular method: Can have a body
    public void Display() => Console.WriteLine("This is a shape.");
}

public class Circle : Shape
{
    public double Radius { get; set; }
    public override double GetArea() => Math.PI * Radius * Radius;
}
```

## Interfaces
An interface is like a "contract." Any class that implements the interface MUST provide the code for the methods defined in it.

```csharp
public interface IMessageService
{
    void SendMessage(string message);
}

public class EmailService : IMessageService
{
    public void SendMessage(string message) 
    {
        Console.WriteLine($"Sending Email: {message}");
    }
}
```

## Abstract Class vs. Interface
- **Abstract Class**: Use when classes share common code or "is-a" relationship.
- **Interface**: Use when classes share a common behavior but aren't necessarily related (e.g., both a `User` and a `File` might be `IDeletable`).

## Why use Abstraction?
1. **Reduces Complexity**: Users of your class don't need to know the complex logic inside.
2. **Easy Maintenance**: You can change the "how" without changing the "what."
3. **Decoupling**: Interfaces allow you to swap implementations easily (e.g., swapping `EmailService` with `SmsService`).

---

*Reference: [Abstract and Sealed Classes — Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/abstract-and-sealed-classes-and-class-members)*
