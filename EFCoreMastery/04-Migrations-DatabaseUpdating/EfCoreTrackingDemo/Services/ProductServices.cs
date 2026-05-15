using EfCoreTrackingDemo.Data;
using EfCoreTrackingDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCoreTrackingDemo.Services{


    public class ProductService {

        private readonly AppDbContext _context;

        public ProductService(AppDbContext context){
            _context = context;
        }



        public void CreateProduct(string? name, decimal price){

            var product= new Product {
                Name = name ?? "unknown",
                Price = price
            };

            _context.Products.Add(product);
            _context.SaveChanges();
            Console.WriteLine("product created successfully");

        }

        public void ViewProducts(){

            var products = _context.Products
                                        .AsNoTracking()
                                        .ToList();
            Console.WriteLine("==== Products List ====");
            foreach(var p in products){
                Console.WriteLine($"{p.Id} | {p.Name} | {p.Price}");
            }

        }


        public void UpdateProduct(int id, string? newName, decimal newPrice){

            var productToUpdate = _context.Products.FirstOrDefault(p => p.Id == id);

            if(productToUpdate == null){
                Console.WriteLine("Product Not Found");
                return;
            }

            productToUpdate.Name = newName;
            productToUpdate.Price = newPrice;

            _context.SaveChanges();
            Console.WriteLine("Product updated successfully");

        }

        public void DeleteProduct(int id){

            var productToDelete = _context.Products.FirstOrDefault(p => p.Id == id);

            if(productToDelete == null){
                Console.WriteLine($"Product with Id {id} not found");
                return;
            }
             _context.Products.Remove(productToDelete);
             _context.SaveChanges();
             Console.WriteLine("Product deleted successfully");
            }

        public void  CountProducts(){

            int count = _context.Products.Count();
            Console.WriteLine(count) ;
            


        }

            

        }





    }
