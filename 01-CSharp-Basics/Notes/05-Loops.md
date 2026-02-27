# Loops

Loops let you run a block of code repeatedly without copy-pasting it. Three types I use constantly: `for`, `while`, and `foreach`.

## for loop

Use this when you know exactly how many times you want to iterate.

```csharp
for (int i = 0; i < 5; i++) {
    Console.WriteLine($"Step {i}");
}
```

The three parts: initialize a counter, check the condition, update the counter.

## while loop

Use when you don't know upfront how many iterations you'll need — you just keep going until a condition becomes false.

```csharp
int attempts = 0;

while (attempts < 3) {
    Console.WriteLine("Enter your PIN:");
    // ... read input ...
    attempts++;
}
```

Be careful: if the condition never becomes false, the loop runs forever. Always make sure there's a way out.

## foreach loop

The most readable option when you just want to go through every item in a collection.

```csharp
string[] names = { "Alice", "Bob", "Charlie" };

foreach (string name in names) {
    Console.WriteLine(name);
}
```

Can't modify the collection while iterating with `foreach` — if you need to do that, use a `for` loop with an index instead.

## break and continue

- `break` — stops the loop entirely
- `continue` — skips the rest of the current iteration and moves to the next one

```csharp
for (int i = 0; i < 10; i++) {
    if (i == 5) break;      // stops at 5
    if (i % 2 == 0) continue; // skips even numbers
    Console.WriteLine(i);
}
```

---

*Reference: [Iteration statements](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/iteration-statements)*
