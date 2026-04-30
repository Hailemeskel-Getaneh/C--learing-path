# Variables

A variable is just a named place to store a value. In C#, you have to declare the type when you create a variable.

## Basic syntax

```csharp
string name = "Haile";
int age = 25;
double salary = 4500.50;
bool isActive = true;
```

The type goes first, then the name, then the value. That's it.

## Why types matter

C# is "strongly typed" — you can't put a number into a string variable without explicitly converting it. This feels strict at first but it catches a lot of bugs before they happen.

## The `var` keyword

When the type is obvious from the value, you can use `var` and let the compiler figure it out:

```csharp
var city = "Addis Ababa";  // compiler knows it's a string
var count = 10;             // compiler knows it's an int
```

`var` doesn't mean "any type" — it's just shorthand. The type is still fixed at compile time.

## Naming conventions

- Variable names use camelCase: `firstName`, `totalAmount`, `isLoggedIn`
- Make names descriptive. `x` tells you nothing. `remainingDays` tells you everything.

## Common mistakes

Not initializing before use:
```csharp
int score;
Console.WriteLine(score); // Error: "Use of unassigned local variable"
```

Always assign a value before you try to use a variable.

---

*Reference: [Variables — Microsoft Learn](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/program-structure/)*
