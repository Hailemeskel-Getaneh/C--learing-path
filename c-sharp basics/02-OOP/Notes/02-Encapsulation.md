# Encapsulation

Encapsulation is about "hiding the internal state" of an object and requiring all interaction to be performed through a well-defined interface.

## Why use it?
It prevents outside code from accidentally messing up the data inside your object. Think of it like a protective shield.

## Private Fields and Public Properties
In C#, we use `private` fields to store data and `public` properties to control how that data is accessed or changed.

```csharp
public class BankAccount
{
    // Private field - cannot be accessed directly from outside
    private decimal _balance;

    // Public property - controls access
    public decimal Balance
    {
        get { return _balance; }
    }

    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            _balance += amount;
        }
    }
}
```

## Automatic Properties
If you don't need any special logic (like validation), you can use a shorthand:

```csharp
public class User
{
    public string Name { get; set; }
    public string Email { get; set; }
}
```

## Access Modifiers
- `public`: Access is not restricted.
- `private`: Access is limited to the containing class.
- `protected`: Access is limited to the class and its subclasses.
- `internal`: Access is limited to the current project (assembly).

## Key Points
- Keep your fields `private`.
- Use `Properties` to expose data safely.
- Proper encapsulation makes your code easier to maintain because you can change the internal logic without breaking the code that uses your class.

---

*Reference: [Encapsulation (C#) — Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/properties)*
