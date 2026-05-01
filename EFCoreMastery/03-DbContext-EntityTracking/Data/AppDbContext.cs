using Microsoft.EntityFrameworkCore;
using DbContextEntityTracking.Models;

namespace DbContextEntityTracking.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=tracking.db");
            // it will be .UseSqlServer for sql server
            // .UseNpgsql for postgresql
            // .UseMySQL for mysql
            // .UseSqlite for sqlite    
            
//              optionsBuilder.UseSqlServer(
//     "Server=.\SQLEXPRESS;Database=EFCoreMasteryDb;Trusted_Connection=True;TrustServerCertificate=True;"
// );

        }
    }
}
