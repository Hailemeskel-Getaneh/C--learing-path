using Microsoft.EntityFrameworkCore;
using ProductSupplier.Domain.Entities;
using ProductSupplier.Domain.Interfaces;
using ProductSupplier.Infrastructure.Data;

namespace ProductSupplier.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    // Get All Products
    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _context.Products
            .Include(p => p.Supplier)
            .ToListAsync();
    }

    // Get Product By Id
    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _context.Products
            .Include(p => p.Supplier)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    // Add Product
    public async Task AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);

        await _context.SaveChangesAsync();
    }

    // Update Product
    public async Task UpdateAsync(Product product)
    {
        _context.Products.Update(product);

        await _context.SaveChangesAsync();
    }

    // Delete Product
    public async Task DeleteAsync(int id)
    {
        var product = await _context.Products.FindAsync(id);

        if (product is null)
            return;

        // Soft delete
        product.Delete();

        await _context.SaveChangesAsync();
    }
}