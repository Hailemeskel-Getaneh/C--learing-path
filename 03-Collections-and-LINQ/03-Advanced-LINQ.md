# 03 — Advanced LINQ (IQueryable vs IEnumerable)

This is the most important concept in database performance. If you get this wrong, your application will be slow.

## The Core Difference

### 1. IQueryable (Database Side)
- **When:** Used when querying a database via EF Core (`DbSet<T>`).
- **What:** It builds a **SQL Query**. No data is downloaded yet.
- **The Magic:** If you add `.Where()`, it adds it to the SQL `WHERE` clause.
- **Efficiency:** Only the filtered data is sent from the DB to your App.

### 2. IEnumerable (Memory Side)
- **When:** Used for in-memory lists or after data is downloaded.
- **What:** It runs the filter in the **Application's RAM**.
- **The Risk:** If you convert to `IEnumerable` before filtering, you download the **WHOLE TABLE** first.

---

## ❌ The "Memory Leak" Mistake (IEnumerable)
```csharp
// BAD: downloads all 1,000,000 users into C# memory, then filters.
IEnumerable<User> users = _context.Users.AsEnumerable(); 
var filtered = users.Where(u => u.Id == 500).ToList(); 
```

## ✅ The "Performance" Way (IQueryable)
```csharp
// GOOD: Sends "SELECT * FROM Users WHERE Id = 500" to SQL Server.
IQueryable<User> users = _context.Users; 
var filtered = await users.Where(u => u.Id == 500).ToListAsync(); 
```

## Deferred Execution
LINQ queries do **NOT** run immediately. They run only when you:
1. Iterate over them (`foreach`).
2. Convert to a list (`.ToList()`, `.ToArray()`).
3. Call a single result method (`.First()`, `.Count()`).

### 💡 Tip for Managers:
Always keep your queries as `IQueryable` for as long as possible until you are ready to send the final result.

---
*Reference: [IQueryable vs IEnumerable](https://learn.microsoft.com/en-us/dotnet/framework/data/adonet/ef/language-reference/ieryable-vs-ienumerable)*
