# 02 — LINQ Basics

**LINQ** (Language Integrated Query) is the bridge between C# and the Database. It allows you to query data using C# syntax instead of raw SQL strings.

## The Two Syntaxes

### 1. Method Syntax (Most Popular)
Uses extension methods and lambdas.
```csharp
var adults = users.Where(u => u.Age >= 18).OrderBy(u => u.Name).ToList();
```

### 2. Query Syntax (SQL-like)
Looks like traditional SQL.
```csharp
var adults = from u in users
             where u.Age >= 18
             orderby u.Name
             select u;
```

## Essential Operators for DB Developers

| Operator | Purpose | SQL Equivalent |
| :--- | :--- | :--- |
| `.Where()` | Filter rows | `WHERE` |
| `.Select()` | Transform/Projection | `SELECT` |
| `.OrderBy()` / `.OrderByDescending()` | Sort | `ORDER BY` |
| `.Include()` (EF Core specific) | Load related data | `JOIN` |
| `.FirstOrDefault()` | Get one item | `SELECT TOP 1` |
| `.Count()` | Get total count | `COUNT(*)` |
| `.Any()` | Check if any exist | `EXISTS` |

### Example: Finding a User by Email
```csharp
var user = await _context.Users
    .Where(u => u.Email == "haile@example.com")
    .FirstOrDefaultAsync();
```

---
*Reference: [LINQ Overview](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/)*
