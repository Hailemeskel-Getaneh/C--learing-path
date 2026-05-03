using Microsoft.EntityFrameworkCore;
using EfCoreTrackingDemo.Data;
using EfCoreTrackingDemo.Services;
using EfCoreTrackingDemo.Models;


using (var context = new AppDbContext())
{
     // apply migrations to database automatically
     context.Database.Migrate();

     var service = new ProductService(context);

     //seed intitial data
     if(!context.Products.Any()){

        context.Products.AddRange(
            new Product { Name = "Printer" , Price = 200m},
            new Product {Name = "Monitor", Price = 340m}
        );
        context.SaveChanges();
        Console.WriteLine("Seeding Successful");
     }
     else{
        Console.WriteLine("Database already contians data. Skeeping seed ...");
     }

      void Menu(){

        Console.WriteLine("=== Menu ===");
        Console.WriteLine("1. Create product");
        Console.WriteLine("2. View products");
        Console.WriteLine("3. Update Product");
        Console.WriteLine("4. Delete Product");
        Console.WriteLine("5. Exit");


     }

     bool running = true;

     while(running){

        Menu();

        Console.Write("Enter your choice:");
         var choice = Console.ReadLine();

        switch(choice){

            case "1":
            {
                    Console.Write("Enter name of the Product:");
                    string? name = Console.ReadLine() ;

                    Console.Write("Enter the Price:");
                    decimal price = decimal.Parse(Console.ReadLine() ?? "0");
                    service.CreateProduct(name, price);
                    break;
            }
            case "2":
                    service.ViewProducts();
                    break;
            
            case "3":
            {
                    Console.Write("Enter Product Id:");
                    int id = int.Parse(Console.ReadLine()!);

                    Console.Write("Enter product Name:");
                    string? name = Console.ReadLine();

                    Console.Write("Enter Price:");
                    decimal price = int.Parse(Console.ReadLine()!);

                    service.UpdateProduct(id, name, price);
                    break;
            }
            case "4":
            {
                    Console.WriteLine("Enter Id to delete");
                    int id = int.Parse(Console.ReadLine()!);

                    service.DeleteProduct(id);
                    break;
            }
            case "5":
                    running = false;
                    break;
            default:
                    Console.WriteLine("Invalid choice");
                    break;




        }      

   }

}