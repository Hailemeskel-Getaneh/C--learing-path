# 03 — Delegates, Lambdas, and Expressions

In the database world, you rarely pull all data into memory. You filter it using **Lambdas**.

## What is a Lambda?
A lambda expression is a "shorthand" function. 
In `_context.Users.Where(u => u.Email == "test@test.com")`, the `u => u.Email == "test@test.com"` is a lambda.

## Why is this important for DB?
Entity Framework (EF) converts your Lambda expressions directly into **SQL**.

### In Memory vs In Database
- **Func<T, bool>**: Used for in-memory collections (filtering after the data is downloaded).
- **Expression<Func<T, bool>>**: Used for database queries. EF uses the "Expression" to read your code and write the SQL `WHERE` clause.

## Example: The Dynamic Filter
If you build a flexible repository, you often pass a lambda as a parameter:

```csharp
public async Task<T> FindOneAsync(Expression<Func<T, bool>> predicate) 
{
    return await _dbSet.FirstOrDefaultAsync(predicate);
}

// Usage:
var user = await userRepository.FindOneAsync(x => x.Username == "haile");
```

### Common operators to know:
- `=>` : "Goes to" (The input parameter goes to this logic).
- `&&` : AND (Database `AND`).
- `||` : OR (Database `OR`).

---
*Reference: [Lambda expressions](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions)*
