using Microsoft.EntityFrameworkCore;
using EfCoreTrackingDemo.Models;

namespace EfCoreTrackingDemo.Data;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options
            .UseSqlite("Data Source=app.db")
            .LogTo(Console.WriteLine);
    }
}