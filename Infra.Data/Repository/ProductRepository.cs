using CardapioOnline.Application.Interfaces;
using CardapioOnline.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CardapioOnline.Infra.Data.Repository;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Create(Product product)
    {
        _context.Product.Add(product);
        _context.SaveChanges();
    }

    public void Update(Product product)
    {
        _context.Product.Update(product);
        _context.SaveChanges();
    }

    public void Delete(Product product)
    {
        _context.Product.Remove(product);
        _context.SaveChanges();
    }

    public async Task<IList<Product>> GetAllAsync()
    {
        var products = await _context.Product.ToListAsync();
        return products;
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        var product = await _context.Product.FirstOrDefaultAsync(p => p.Code == id);
        return product;
    }
}