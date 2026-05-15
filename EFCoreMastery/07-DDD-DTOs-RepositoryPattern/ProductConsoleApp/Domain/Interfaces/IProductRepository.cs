namespace ProductApp.Domain.Interfaces;

using ProductApp.Domain.Entities;
using System.Collections.Generic;

public interface IProductRepository {
    // READ (Get All)
    IEnumerable<Product> GetAll(); 
    
    // READ (Get One)
    Product GetById(int id);
    
    // CREATE
    void Add(Product product);
    
    // UPDATE
    void Update(Product product);
    
    // DELETE
    void Delete(int id);
}
