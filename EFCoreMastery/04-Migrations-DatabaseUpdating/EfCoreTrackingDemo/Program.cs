using Microsoft.EntityFrameworkCore;
using EfCoreTrackingDemo.Data;
using EfCoreTrackingDemo.Services;
using EfCoreTrackingDemo.Models;

using (var context = new AppDbContext())
{
    // Apply migrations to database automatically
    context.Database.Migrate();

    var service = new ProductService(context);

    // Seed initial data
    if (!context.Products.Any())
    {
        context.Products.AddRange(
            new Product { Name = "Printer", Price = 200m },
            new Product { Name = "Monitor", Price = 340m }
        );
        context.SaveChanges();
        Console.WriteLine("Seeding Successful");
    }
    else
    {
        Console.WriteLine("Database already contains data. Skipping seed...");
    }

    bool running = true;
    while (running)
    {
        string choice = Menu();

        switch (choice)
        {
            case "1":
                Console.Write("Enter name of the Product: ");
                string? name1 = Console.ReadLine();
                Console.Write("Enter the Price: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal price1))
                {
                    service.CreateProduct(name1, price1);
                }
                break;

            case "2":
                Console.Write("Product Count: ");
                service.CountProducts(); 
                service.ViewProducts();
                break;

            case "3":
                Console.Write("Enter Product Id: ");
                if (int.TryParse(Console.ReadLine(), out int id3))
                {
                    Console.Write("Enter product Name: ");
                    string? name3 = Console.ReadLine();
                    Console.Write("Enter Price: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal price3))
                    {
                        service.UpdateProduct(id3, name3, price3);
                    }
                }
                break;

            case "4":
                Console.Write("Enter Id to delete: ");
                if (int.TryParse(Console.ReadLine(), out int id4))
                {
                    service.DeleteProduct(id4);
                }
                break;

            case "5":
                running = false;
                break;

            default:
                Console.WriteLine("Invalid choice");
                break;
        }
    }
}

string Menu()
{
    Console.WriteLine("\n=== Menu ===");
    Console.WriteLine("1. Create product");
    Console.WriteLine("2. View products");
    Console.WriteLine("3. Update Product");
    Console.WriteLine("4. Delete Product");
    Console.WriteLine("5. Exit");
    Console.WriteLine("Enter your choice: ");
    return Console.ReadLine() ?? "";
}
