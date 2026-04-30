# Arrays

An array is a fixed-size, ordered list of items — all of the same type.

## Creating an array

```csharp
// With values
string[] fruits = { "Apple", "Mango", "Banana" };

// Empty array with a set size
int[] scores = new int[5]; // creates 5 slots, all defaulting to 0
```

The size is set when you create it. You can't add or remove items after that (for that, you'd use a `List<T>`).

## Accessing elements

Arrays are zero-indexed — the first item is at index 0.

```csharp
Console.WriteLine(fruits[0]);  // Apple
Console.WriteLine(fruits[2]);  // Banana

fruits[1] = "Pineapple";       // change a value
```

## Iterating

```csharp
// With a for loop (when you need the index)
for (int i = 0; i < fruits.Length; i++) {
    Console.WriteLine($"{i}: {fruits[i]}");
}

// With foreach (when you just want the values)
foreach (string fruit in fruits) {
    Console.WriteLine(fruit);
}
```

## Useful properties and methods

- `fruits.Length` — number of elements
- `Array.Sort(fruits)` — sorts in place
- `Array.Reverse(fruits)` — reverses in place

## When to use Array vs List

Use an array when the number of items is fixed and you're working with simple or performance-critical code.
Use `List<T>` when you need to add and remove items dynamically — which is most of the time.

---

*Reference: [Arrays — C# Programming Guide](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/)*
