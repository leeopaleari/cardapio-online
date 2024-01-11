using CardapioOnline.Domain.Entities;

namespace CardapioOnline.Application.Interfaces;

public interface IProductRepository
{
    Task<Product> Create(Product product);
    Task<Product> Update(Product product);
    Task<Product> Delete(int id);
    Task<IList<Product>> GetAllAsync();
    Task<Product> GetByIdAsync(int id);
}