# 04 — Repository & Unit of Work Pattern

This is the "Golden Standard" for professional .NET database projects. Your manager likely expects you to follow this architecture.

## 1. The Repository Pattern
The Repository acts as a "Buffer" between your application and the database.
- **Goal:** Hide the details of Entity Framework (DbContext) from your business logic.

### Why?
- **Avoid Duplication:** You write the code to "Get Active Users" once, instead of in 5 different controllers.
- **Testing:** You can "mock" the repository without actually connecting to SQL Server during unit tests.

```csharp
public interface IUserRepository
{
    Task<User> GetByEmailAsync(string email);
    Task<IEnumerable<User>> GetMembersAsync();
}
```

---

## 2. The Unit of Work Pattern
While Repository handles **Data Access**, Unit of Work handles **Transactions**.

### The Problem:
If you have a `ProductRepository` and an `OrderRepository`, and you want to save a new Order + Reduce Stock in one go... if you call `SaveChanges()` twice, one might succeed and the other fail. Your database is now "corrupt."

### The Solution:
The Unit of Work shares a **single DbContext** across all repositories and calls `SaveChanges()` **exactly once** at the end.

```csharp
public interface IUnitOfWork : IDisposable
{
    IProductRepository Products { get; }
    IOrderRepository Orders { get; }
    Task<int> CompleteAsync(); // This calls _context.SaveChangesAsync()
}
```

---

## 3. The Modern Flow
In a clean architecture, the flow looks like this:

**Controller** → **Service Layer** → **Unit of Work** → **Repositories** → **DbContext**

### Implementation Tip:
1. Define Interfaces for everything.
2. Register them in `Program.cs` (Dependency Injection).
3. Always use `async` when calling `CompleteAsync()`.

---
*Reference: [Repository and Unit of Work Patterns](https://learn.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application)*
