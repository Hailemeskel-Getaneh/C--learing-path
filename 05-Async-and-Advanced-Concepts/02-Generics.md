# 02 — Generics (The Foundation of Repositories)

Generics allow you to write code that works with **any data type** while still being completely type-safe (no errors at runtime).

In a database-focused project, you use generics to build a **Generic Repository**.

## Why use Generics?
Without generics, you would have to write separate repositories for every table:
- `ProductRepository`
- `OrderRepository`
- `CustomerRepository`

With generics, you write one logic that works for all of them.

## The IRepository<T> Pattern

```csharp
// 'T' stands for any Entity (Product, Order, etc.)
public interface IRepository<T> where T : class 
{
    Task<T> GetByIdAsync(int id);
    Task<List<T>> GetAllAsync();
    Task AddAsync(T entity);
}
```

### Implementation Example:
```csharp
public class Repository<T> : IRepository<T> where T : class
{
    private readonly MyDbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(MyDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<T> GetByIdAsync(int id) 
    {
        return await _dbSet.FindAsync(id);
    }
}
```

## Constraints (`where T : class`)
In the example above, `where T : class` tells C# that `T` must be a reference type (an object), which is required because Entity Framework only tracks objects.

---
*Reference: [Generics in C#](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/)*
