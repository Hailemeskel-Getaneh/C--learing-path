using ProductSupplier.Domain.Entities;

namespace ProductSupplier.Domain.Interfaces;

public interface ISupplierRepository
{
    Task<IEnumerable<Supplier>> GetAllAsync();

    Task<Supplier?> GetByIdAsync(int id);

    Task AddAsync(Supplier supplier);

    Task UpdateAsync(Supplier supplier);

    Task DeleteAsync(int id);
}