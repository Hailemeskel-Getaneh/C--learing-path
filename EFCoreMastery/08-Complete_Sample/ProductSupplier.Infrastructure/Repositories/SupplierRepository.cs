using Microsoft.EntityFrameworkCore;
using ProductSupplier.Domain.Entities;
using ProductSupplier.Domain.Interfaces;
using ProductSupplier.Infrastructure.Data;

namespace ProductSupplier.Infrastructure.Repositories;

public class SupplierRepository : ISupplierRepository
{
    private readonly ApplicationDbContext _context;

    public SupplierRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Supplier>> GetAllAsync()
    {
        return await _context.Suppliers
            .Include(s => s.Products)
            .ToListAsync();
    }

    public async Task<Supplier?> GetByIdAsync(int id)
    {
        return await _context.Suppliers
            .Include(s => s.Products)
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task AddAsync(Supplier supplier)
    {
        await _context.Suppliers.AddAsync(supplier);

        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Supplier supplier)
    {
        _context.Suppliers.Update(supplier);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var supplier = await _context.Suppliers.FindAsync(id);

        if (supplier is null)
            return;

        supplier.Delete();

        await _context.SaveChangesAsync();
    }
}