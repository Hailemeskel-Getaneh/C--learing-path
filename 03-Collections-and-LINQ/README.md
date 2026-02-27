# Unit 03 — Collections and LINQ

This section is about managing and querying data. In real applications you rarely work with single values — you work with lists of things, and you need to filter, sort, and transform them efficiently.

## What's in here

- 01-Collections.md — Lists, Dictionaries, and when to use which
- 02-LINQ-Basics.md — Where, Select, OrderBy
- 03-Advanced-LINQ.md — GroupBy, aggregates, chaining

Practice project in `Projects/InventorySys/`.

## The key types

**List<T>** — your default go-to. A dynamic array that grows as you add items.

**Dictionary<TKey, TValue>** — for fast lookup by key. Think of it like a lookup table.

**Array** — fixed-size, fast, but rigid. Good when the size won't change.

## What LINQ is

LINQ (Language Integrated Query) lets you query any collection using a syntax that looks almost like SQL, but written directly in C#. Instead of writing loops to filter a list, you write:

```csharp
var expensiveItems = inventory.Where(i => i.Price > 100).OrderBy(i => i.Name);
```

Clean, readable, and composable.

---

*Reference: [Collections in C#](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/collections)*
