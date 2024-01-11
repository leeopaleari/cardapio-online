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

    public async Task<Product> Create(Product product)
    {
        _context.Product.Add(product);
        await _context.SaveChangesAsync();

        return product;
    }

    public async Task<Product> Update(Product product)
    {
        _context.Product.Update(product);
        await _context.SaveChangesAsync();

        return product;
    }

    public async Task<Product> Delete(int id)
    {
        var product = await _context.Product.FindAsync(id);

        _context.Product.Remove(product);
        await _context.SaveChangesAsync();

        return product;
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