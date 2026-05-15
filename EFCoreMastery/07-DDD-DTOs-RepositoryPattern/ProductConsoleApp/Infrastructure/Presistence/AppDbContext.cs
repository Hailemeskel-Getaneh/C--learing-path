using Microsoft.EntityFrameworkCore;
using ProductConsoleApp.Domain.Entities;
namespace ProductConsoleApp.Infrastructure.Persistence{  
public class AppDbContext: DbContext{
    public DbSet<Product> Products { get; set;}
    protected override void OnConfiguring(DbContextOptionsBuilder myConfig){
             myConfig
                    .UseSqlite("Data Source = app.db")
                    .LogTo(Console.WriteLine);
    }
}
}
