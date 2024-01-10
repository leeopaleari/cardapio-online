using CardapioOnline.Domain.Entities;

namespace CardapioOnline.Application.Interfaces;

public interface IProductRepository
{
    void Create(Product product);
    void Update(Product product);
    void Delete(Product product);
    Task<IList<Product>> GetAllAsync();
    Task<Product> GetByIdAsync(int id);
}