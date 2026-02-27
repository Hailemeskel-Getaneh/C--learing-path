# Conditions

Conditions let the program make decisions — run this block of code if something is true, run a different block if it's false.

## if / else if / else

```csharp
int score = 72;

if (score >= 90) {
    Console.WriteLine("A");
} else if (score >= 75) {
    Console.WriteLine("B");
} else if (score >= 60) {
    Console.WriteLine("C");
} else {
    Console.WriteLine("F");
}
```

C# evaluates top to bottom and stops at the first true condition.

## switch

Use `switch` when you're comparing one variable against many possible values. It's cleaner than stacking a bunch of `else if` statements.

```csharp
string day = "Monday";

switch (day) {
    case "Saturday":
    case "Sunday":
        Console.WriteLine("Weekend");
        break;
    case "Monday":
        Console.WriteLine("Start of the week");
        break;
    default:
        Console.WriteLine("Weekday");
        break;
}
```

Note: `break` is required at the end of each case. Forget it and the code won't compile.

## Comparison operators

- `==` — equal to
- `!=` — not equal
- `>` / `<` — greater than / less than
- `>=` / `<=` — greater/less than or equal
- `&&` — AND (both conditions must be true)
- `||` — OR (at least one must be true)
- `!` — NOT (flips true to false)

```csharp
bool isAdult = age >= 18;
bool canVote = isAdult && isCitizen;
```

---

*Reference: [Selection statements — Microsoft docs](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements)*
