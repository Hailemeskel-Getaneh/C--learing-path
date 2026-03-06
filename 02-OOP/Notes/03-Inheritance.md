# Inheritance

Inheritance allows you to create a new class that reuses, extends, and modifies the behavior defined in another class.

## The Relationship
Inheritance is an **"IS-A"** relationship. 
- A `Dog` **is a** `Animal`.
- A `SavingsAccount` **is a** `BankAccount`.

## Base and Derived Classes
- **Base Class**: The "parent" class (the general one).
- **Derived Class**: The "child" class (the specialized one).

```csharp
// Base Class
public class Animal
{
    public string Name { get; set; }
    public void Eat() => Console.WriteLine($"{Name} is eating.");
}

// Derived Class
public class Dog : Animal // The colon (:) indicates inheritance
{
    public void Bark() => Console.WriteLine("Woof!");
}
```

## Reusing Code
The `Dog` class automatically gets the `Name` property and the `Eat()` method from `Animal`.

```csharp
Dog myDog = new Dog();
myDog.Name = "Rex";
myDog.Eat();  // Rex is eating.
myDog.Bark(); // Woof!
```

## Polymorphism with Virtual/Override
Sometimes you want the child class to do something differently than the parent. We use `virtual` in the base class and `override` in the child class.

```csharp
public class Animal
{
    public virtual void MakeSound() => Console.WriteLine("Generic animal sound");
}

public class Cat : Animal
{
    public override void MakeSound() => Console.WriteLine("Meow!");
}
```

## Key Points
- In C#, a class can only inherit from ONE base class.
- Use the `base` keyword to call methods or constructors of the parent class.
- Inheritance prevents code duplication.

---

*Reference: [Inheritance in C# — Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/object-oriented/inheritance)*
