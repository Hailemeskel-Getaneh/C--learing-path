# Methods

A method is a named block of code. You define it once, then call it as many times as you want. This is how you avoid repeating code and keep things organized.

## Basic method (no return value)

```csharp
void PrintGreeting(string name) {
    Console.WriteLine($"Hello, {name}!");
}

// Call it like this:
PrintGreeting("Haile");
```

`void` means the method doesn't give anything back — it just does something.

## Method with a return value

```csharp
int Add(int a, int b) {
    return a + b;
}

int result = Add(3, 7);  // result is 10
```

The return type replaces `void`, and you use `return` to send the value back.

## Parameters vs Arguments

Parameters are the variable names in the method definition.
Arguments are the actual values you pass when calling it.

```csharp
// "name" is the parameter
void Greet(string name) { ... }

// "Alice" is the argument
Greet("Alice");
```

## Optional parameters

You can give a parameter a default value, making it optional:

```csharp
void Log(string message, bool verbose = false) {
    if (verbose) Console.Write("[VERBOSE] ");
    Console.WriteLine(message);
}

Log("Starting app");         // works
Log("Starting app", true);   // also works
```

## Naming conventions

Methods use PascalCase: `GetUser()`, `CalculateTotal()`, `SaveToFile()`. They should be named after what they do — a verb or verb phrase.

---

*Reference: [Methods in C#](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/methods)*
