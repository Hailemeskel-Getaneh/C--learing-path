using Microsoft.EntityFrameworkCore;
using EfCoreTrackingDemo.Data;
using EfCoreTrackingDemo.Models;


using(var context = new AppDbContext())
{
     // automatically apply migrations to database
     context.Database.Migrate();

     //check and seed initial data if there is nothing
     if(!context.Products.Any()){

         context.Products.Add(new Product{Name = "Monitor", Price= 200m});
         context.Products.Add(new Product{ Name = "Printer", Price= 300m});
         context.SaveChanges();
     }

     else{
        Console.WriteLine("There is already intial data. Skeeping seeding ....");
     }

     bool running = true;

     while(running){

        Console.WriteLine("=== Products Menu ===");
        Console.WriteLine("1. Create new Product");
        Console.WriteLine("2. View Products");
        Console.WriteLine("3. Update Product");
        Console.WriteLine("4. Delete Product");
        Console.WriteLine("5. Exit");


        Console.Write("Enter Your choice: ");
        var  choice = Console.ReadLine();

        switch(choice){

            case "1":
                    Console.Write("Enter the name of the Product:");
                    var name = Console.ReadLine();

                    Console.Write("Enter Price of the Product:");
                    var price = decimal.Parse(Console.ReadLine() ?? "0");

                    context.Products.Add( new Product{
                        Name = name ?? "unknown",
                        Price = price
                    });

                    context.SaveChanges();
                    Console.WriteLine("Product added Successfully");
                    break;
            case "2":
                    //Read, so use AsNoTracking();
                    var products =  context.Products
                                     .AsNoTracking()
                                     .ToList();
                    Console.WriteLine("--- Products List ---");
                    foreach(var p in products ){
                        
                        Console.WriteLine($"{p.Id} | {p.Name} | {p.Price}");
                    }
                    break;

            case "3":
                    Console.Write("Enter Product Id to update:");
                    int updateId = int.Parse(Console.ReadLine()!);

                    var productToUpdate = context.Products.FirstOrDefault(p => p.Id == updateId);

                    if(productToUpdate == null){
                        Console.WriteLine("Product not Found");
                        break;
                    }

                    Console.Write("Enter the name of the Product:");
                    productToUpdate.Name = Console.ReadLine() ?? "unknown";

                    Console.Write("Enter the new Price:");
                    productToUpdate.Price = decimal.Parse(Console.ReadLine()!);

                    context.SaveChanges();
                    Console.WriteLine("Product updated Successfully");
                    break;
            case "4":
                    Console.Write("Enter the Product Id to delete:");
                    int  deleteId = int.Parse(Console.ReadLine()!);

                    var productToDelete = context.Products.FirstOrDefault(p => p.Id == deleteId);

                    if(productToDelete == null){

                        Console.WriteLine("Product not Found");
                        break;
                    }

                    context.Products.Remove(productToDelete);
                    context.SaveChanges();
                    Console.WriteLine("Product Deleted Successfully");
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