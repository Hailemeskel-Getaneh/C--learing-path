using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProductSupplier.Domain.Entities;
using ProductSupplier.Domain.Interfaces;
using ProductSupplier.Infrastructure.Data;
using ProductSupplier.Infrastructure.Repositories;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlite(
                context.Configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ISupplierRepository, SupplierRepository>();
    })
    .Build();

using var scope = host.Services.CreateScope();
var services = scope.ServiceProvider;
var supplierRepo = services.GetRequiredService<ISupplierRepository>();
var productRepo = services.GetRequiredService<IProductRepository>();

bool exit = false;
while (!exit)
{
    Console.Clear();
    Console.WriteLine("=== Product & Supplier Management System ===");
    Console.WriteLine("1. Manage Suppliers");
    Console.WriteLine("2. Manage Products");
    Console.WriteLine("0. Exit");
    Console.Write("\nSelect an option: ");

    switch (Console.ReadLine())
    {
        case "1": await ManageSuppliers(supplierRepo); break;
        case "2": await ManageProducts(productRepo, supplierRepo); break;
        case "0": exit = true; break;
        default: Console.WriteLine("Invalid option. Press any key to try again..."); Console.ReadKey(); break;
    }
}

async Task ManageSuppliers(ISupplierRepository repo)
{
    bool back = false;
    while (!back)
    {
        Console.Clear();
        Console.WriteLine("--- Supplier Management ---");
        Console.WriteLine("1. List All Suppliers");
        Console.WriteLine("2. Add New Supplier");
        Console.WriteLine("3. Update Supplier");
        Console.WriteLine("4. Delete Supplier");
        Console.WriteLine("0. Back to Main Menu");
        Console.Write("\nSelect an option: ");

        switch (Console.ReadLine())
        {
            case "1": await ListSuppliers(repo); break;
            case "2": await AddSupplier(repo); break;
            case "3": await UpdateSupplier(repo); break;
            case "4": await DeleteSupplier(repo); break;
            case "0": back = true; break;
        }
    }
}

async Task ListSuppliers(ISupplierRepository repo)
{
    var suppliers = await repo.GetAllAsync();
    Console.WriteLine("\nSuppliers List:");
    foreach (var s in suppliers)
    {
        Console.WriteLine($"ID: {s.Id} | Name: {s.CompanyName} | Email: {s.Email} | Phone: {s.Phone}");
    }
    Console.WriteLine("\nPress any key to return...");
    Console.ReadKey();
}

async Task AddSupplier(ISupplierRepository repo)
{
    try
    {
        Console.Write("Enter Company Name: ");
        string name = Console.ReadLine() ?? "";
        Console.Write("Enter Email: ");
        string email = Console.ReadLine() ?? "";
        Console.Write("Enter Phone: ");
        string phone = Console.ReadLine() ?? "";
        Console.Write("Enter Address: ");
        string address = Console.ReadLine() ?? "";

        var supplier = new Supplier(name, email, phone, address);
        await repo.AddAsync(supplier);
        Console.WriteLine("Supplier added successfully!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
    Console.ReadKey();
}

async Task UpdateSupplier(ISupplierRepository repo)
{
    Console.Write("Enter Supplier ID to update: ");
    if (int.TryParse(Console.ReadLine(), out int id))
    {
        var supplier = await repo.GetByIdAsync(id);
        if (supplier == null)
        {
            Console.WriteLine("Supplier not found.");
        }
        else
        {
            try
            {
                Console.Write($"Enter New Name ({supplier.CompanyName}): ");
                string name = Console.ReadLine()!;
                if (!string.IsNullOrWhiteSpace(name)) supplier.setName(name);

                Console.Write($"Enter New Email ({supplier.Email}): ");
                string email = Console.ReadLine()!;
                if (!string.IsNullOrWhiteSpace(email)) supplier.setEmail(email);

                Console.Write($"Enter New Phone ({supplier.Phone}): ");
                string phone = Console.ReadLine()!;
                if (!string.IsNullOrWhiteSpace(phone)) supplier.setPhone(phone);

                Console.Write($"Enter New Address ({supplier.Address}): ");
                string address = Console.ReadLine()!;
                if (!string.IsNullOrWhiteSpace(address)) supplier.setAddress(address);

                await repo.UpdateAsync(supplier);
                Console.WriteLine("Supplier updated successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
    Console.ReadKey();
}

async Task DeleteSupplier(ISupplierRepository repo)
{
    Console.Write("Enter Supplier ID to delete: ");
    if (int.TryParse(Console.ReadLine(), out int id))
    {
        await repo.DeleteAsync(id);
        Console.WriteLine("Supplier deleted successfully (Soft delete).");
    }
    Console.ReadKey();
}

async Task ManageProducts(IProductRepository productRepo, ISupplierRepository supplierRepo)
{
    bool back = false;
    while (!back)
    {
        Console.Clear();
        Console.WriteLine("--- Product Management ---");
        Console.WriteLine("1. List All Products");
        Console.WriteLine("2. Add New Product");
        Console.WriteLine("3. Update Product");
        Console.WriteLine("4. Delete Product");
        Console.WriteLine("0. Back to Main Menu");
        Console.Write("\nSelect an option: ");

        switch (Console.ReadLine())
        {
            case "1": await ListProducts(productRepo); break;
            case "2": await AddProduct(productRepo, supplierRepo); break;
            case "3": await UpdateProduct(productRepo); break;
            case "4": await DeleteProduct(productRepo); break;
            case "0": back = true; break;
        }
    }
}

async Task ListProducts(IProductRepository repo)
{
    var products = await repo.GetAllAsync();
    Console.WriteLine("\nProducts List:");
    foreach (var p in products)
    {
        Console.WriteLine($"ID: {p.Id} | Name: {p.Name} | Price: {p.Price} | Stock: {p.QuantityInStock} | Supplier: {p.Supplier?.CompanyName}");
    }
    Console.WriteLine("\nPress any key to return...");
    Console.ReadKey();
}

async Task AddProduct(IProductRepository productRepo, ISupplierRepository supplierRepo)
{
    try
    {
        var suppliers = await supplierRepo.GetAllAsync();
        if (!suppliers.Any())
        {
            Console.WriteLine("No suppliers available. Add a supplier first.");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("Select Supplier ID:");
        foreach (var s in suppliers) Console.WriteLine($"{s.Id}: {s.CompanyName}");
        if (!int.TryParse(Console.ReadLine(), out int supplierId)) return;

        Console.Write("Enter Product Name: ");
        string name = Console.ReadLine() ?? "";
        Console.Write("Enter Price: ");
        decimal.TryParse(Console.ReadLine(), out decimal price);
        Console.Write("Enter Stock Quantity: ");
        int.TryParse(Console.ReadLine(), out int stock);

        var product = new Product(name, price, stock, supplierId);
        await productRepo.AddAsync(product);
        Console.WriteLine("Product added successfully!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
    Console.ReadKey();
}

async Task UpdateProduct(IProductRepository repo)
{
    Console.Write("Enter Product ID to update: ");
    if (int.TryParse(Console.ReadLine(), out int id))
    {
        var product = await repo.GetByIdAsync(id);
        if (product == null)
        {
            Console.WriteLine("Product not found.");
        }
        else
        {
            try
            {
                Console.Write($"Enter New Name ({product.Name}): ");
                string name = Console.ReadLine()!;
                if (!string.IsNullOrWhiteSpace(name)) product.setName(name);

                Console.Write($"Enter New Price ({product.Price}): ");
                if (decimal.TryParse(Console.ReadLine(), out decimal price)) product.setPrice(price);

                Console.Write($"Enter New Stock ({product.QuantityInStock}): ");
                if (int.TryParse(Console.ReadLine(), out int stock)) product.setQuantity(stock);

                await repo.UpdateAsync(product);
                Console.WriteLine("Product updated successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
    Console.ReadKey();
}

async Task DeleteProduct(IProductRepository repo)
{
    Console.Write("Enter Product ID to delete: ");
    if (int.TryParse(Console.ReadLine(), out int id))
    {
        await repo.DeleteAsync(id);
        Console.WriteLine("Product deleted successfully (Soft delete).");
    }
    Console.ReadKey();
}
