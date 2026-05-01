using DbContextEntityTracking.Data;
using DbContextEntityTracking.Models;
using Microsoft.EntityFrameworkCore;

using var context = new AppDbContext();

// Reset database
await context.Database.EnsureDeletedAsync();
await context.Database.EnsureCreatedAsync();

Console.WriteLine("--- EF Core DbContext & Entity Tracking Lab ---");

// 1. ADD
var laptop = new Product { Name = "Gaming Laptop", Price = 1500.00m };
Console.WriteLine($"\nBefore Add: State = {context.Entry(laptop).State}"); 

context.Products.Add(laptop);
Console.WriteLine($"After Add: State = {context.Entry(laptop).State}"); 

await context.SaveChangesAsync();
Console.WriteLine($"After Save: State = {context.Entry(laptop).State}"); 

// 2. UPDATE (Auto-detection)
Console.WriteLine("\n--- Modifying Entity ---");
laptop.Price = 1400.00m;
Console.WriteLine($"After price change: State = {context.Entry(laptop).State}"); 

await context.SaveChangesAsync();
Console.WriteLine($"After Save (Update): State = {context.Entry(laptop).State}"); 

// 3. CHANGE TRACKER ENTRIES
Console.WriteLine("\n--- Adding Multiple Entities ---");
context.Products.Add(new Product { Name = "Mouse", Price = 30.00m });
context.Products.Add(new Product { Name = "Headset", Price = 80.00m });

foreach (var entry in context.ChangeTracker.Entries())
{
    var productName = entry.Entity is Product p ? p.Name : "Unknown";
    Console.WriteLine($"Entity: {productName}, State: {entry.State}");
}

// 4. DELETE
Console.WriteLine("\n--- Deleting Laptop ---");
context.Products.Remove(laptop);
Console.WriteLine($"After Remove call: State = {context.Entry(laptop).State}"); 

await context.SaveChangesAsync();
Console.WriteLine($"After Save (Delete): State = {context.Entry(laptop).State}"); 

Console.WriteLine("\nLab finished!");
