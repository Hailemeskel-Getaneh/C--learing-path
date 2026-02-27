# Data Types

C# has a set of built-in types for different kinds of data. Getting the right type matters — it affects memory, precision, and what operations you can do.

## The ones I use most

**Integers (whole numbers)**
- `int` — standard. Range: roughly -2 billion to +2 billion. Covers most cases.
- `long` — use when you need bigger numbers than int can hold.

**Decimals**
- `double` — default for floating point. Good for general math.
- `decimal` — higher precision. Always use this for money calculations.

```csharp
double pi = 3.14159;
decimal price = 29.99m;  // note the 'm' suffix for decimal
```

**Text**
- `string` — sequence of characters, in double quotes.
- `char` — a single character, in single quotes.

```csharp
string greeting = "Hello";
char initial = 'H';
```

**Boolean**
- `bool` — true or false, nothing else.

```csharp
bool isComplete = false;
```

## Value types vs Reference types

Value types (`int`, `double`, `bool`, `char`) store the actual data directly.
Reference types (`string`, classes) store a reference (pointer) to where the data lives in memory.

In practice this doesn't affect much early on, but it's good to know when things behave unexpectedly.

## Casting

Sometimes you need to convert between types:

```csharp
int x = 5;
double y = (double)x;    // explicit cast
double z = x;            // implicit — int can always become double safely
```

Going from `double` to `int` requires an explicit cast because you'll lose the decimal part.

---

*Reference: [Built-in types](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/built-in-types)*
