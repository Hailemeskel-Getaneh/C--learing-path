# Classes and Objects

Classes are the blueprints. Objects are the things built from those blueprints.

## What is a Class?
A class describes what an object will be (its data) and what it will do (its behavior).

```csharp
public class Car 
{
    // Fields/Properties (Data)
    public string Model;
    public int Year;

    // Methods (Behavior)
    public void Drive() 
    {
        Console.WriteLine($"{Model} is driving!");
    }
}
```

## What is an Object?
An object is an "instance" of a class. You create it using the `new` keyword.

```csharp
Car myCar = new Car();
myCar.Model = "Tesla Model 3";
myCar.Year = 2023;
myCar.Drive(); // Output: Tesla Model 3 is driving!
```

## Constructors
A constructor is a special method that runs when you create a new object. It's usually used to set up initial values.

```csharp
public class Car 
{
    public string Model;
    
    // Constructor
    public Car(string modelName) 
    {
        Model = modelName;
    }
}

// Usage
var myCar = new Car("Mercedes");
```

## Key Points
- **Classes** are like the recipe; **Objects** are the cake.
- Use `public` to make members accessible outside the class.
- Always use `PascalCase` for class names and method names in C#.

---

*Reference: [Classes and Structs — Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/classes)*
