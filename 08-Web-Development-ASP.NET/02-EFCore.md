# 02 — Entity Framework Core (Deep Dive)

Entity Framework (EF) Core is an Object-Relational Mapper (ORM). It allows you to interact with a database using C# classes instead of SQL.

## 1. The DbContext (The Session)
The `DbContext` is a single session with the database. It handles change tracking, transactions, and connection management.

```csharp
public class MyDbContext : DbContext 
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }
}
```

## 2. Code First & Migrations
You write the C# class first, and EF Core creates the SQL table for you.
- **Migration**: A file that describes the changes to the database.
- **Commands:**
  - `dotnet ef migrations add InitialCreate` (Create the plan)
  - `dotnet ef database update` (Apply the plan to SQL Server)

## 3. Fluent API (Configuration)
While you can use "Data Annotations" (like `[Key]`), professional projects use the **Fluent API** inside `OnModelCreating`.

```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Product>()
        .Property(p => p.Name)
        .IsRequired()
        .HasMaxLength(200);

    // Defining a One-to-Many relationship
    modelBuilder.Entity<Product>()
        .HasOne(p => p.Category)
        .WithMany(c => c.Products)
        .HasForeignKey(p => p.CategoryId);
}
```

## 4. Tracking vs. No-Tracking
- **Tracking (Default):** EF keeps a copy of the object in memory to see if you change it.
- **AsNoTracking:** Faster. Use this for **Read-Only** operations where you won't call `SaveChanges`.

```csharp
var users = await _context.Users.AsNoTracking().ToListAsync();
```

---
*Reference: [EF Core Documentation](https://learn.microsoft.com/en-us/ef/core/)*
