# 01 — Collections (The Data Containers)

In C#, you rarely work with single variables. You work with **Collections**. 

For database work, you must choose the right collection for the right job.

## 1. List<T> (The Flexible Default)
The most common collection. It is ordered and allows duplicates.
- **When to use:** Storing results from a database query (`List<User> users`).
- **Complexity:** Fast for adding/index access, slow for searching.

```csharp
List<string> employees = new List<string> { "Haile", "John", "Sarah" };
employees.Add("Developer");
```

## 2. Dictionary<TKey, TValue> (The Fast Lookup)
Stores data in Key-Value pairs.
- **When to use:** Caching database records by their Primary Key (ID).
- **Complexity:** Near-instant lookup (`O(1)`).

```csharp
Dictionary<int, string> userCache = new Dictionary<int, string>();
userCache.Add(1, "Hailemeskel");
string name = userCache[1]; // Extremely fast
```

## 3. HashSet<T> (The Unique List)
A collection that only allows unique items.
- **When to use:** Managing Many-to-Many relationships where you want to ensure no duplicates (e.g., unique Roles).

```csharp
HashSet<string> roles = new HashSet<string> { "Admin", "User" };
roles.Add("Admin"); // Will do nothing because "Admin" exists.
```

## ⚠️ The Golden Rule for Database Results
When returning data from a service, usually return `IEnumerable<T>` or `List<T>`. 
Avoid returning `Array` unless you have a specific performance reason.

---
*Reference: [Collections in .NET](https://learn.microsoft.com/en-us/dotnet/standard/collections/)*
