# 01 — Async and Await (Performance & Database)

In modern .NET, almost all database and network operations are **Asynchronous**.

## 🔴 The Problem: Synchronous (Blocking)
If you call a database synchronously, the thread "waits" for the database to return data. 
- While waiting, the thread cannot do anything else.
- If your server has 100 threads and 100 people are waiting for the database, your app crashes (Thread Pool Starvation).

## 🟢 The Solution: Asynchronous (Non-blocking)
When you `await` a database call, the thread is released back to the system to handle other requests while the database does its work. When the database finishes, a thread comes back and resumes your method.

### Example: Sync vs Async

**Synchronous (Bad for DB):**
```csharp
public User GetUser(int id) 
{
    // Thread hangs here until DB responds
    return _context.Users.FirstOrDefault(x => x.Id == id); 
}
```

**Asynchronous (Good for DB):**
```csharp
public async Task<User> GetUserAsync(int id) 
{
    // Thread is released while DB works
    return await _context.Users.FirstOrDefaultAsync(x => x.Id == id); 
}
```

## Key Rules for DB Work
1. **Always go all the way up**: If your repository is async, your service must be async, and your controller must be async.
2. **Naming**: Methods should end in `Async` (e.g., `SaveAsync`, `ListUsersAsync`).
3. **Task**: Use `Task` for methods that return nothing (`void` equivalent) and `Task<T>` for methods that return a value.

---
*Reference: [Asynchronous programming](https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/)*
