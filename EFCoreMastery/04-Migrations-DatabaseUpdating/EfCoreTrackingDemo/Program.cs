using Microsoft.EntityFrameworkCore;
using EfCoreTrackingDemo.Data;
using EfCoreTrackingDemo.Models;

using (var context = new AppDbContext())
{
   context.Database.Migrate();

    if (!context.Products.Any())
    {
        context.Products.Add(new Product { Name = "Laptop" });
        context.Products.Add(new Product{ Name = "Mobile phone"});
        context.SaveChanges();
    }

    Console.WriteLine("Database Initialized");
}