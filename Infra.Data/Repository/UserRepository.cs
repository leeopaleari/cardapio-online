using CardapioOnline.Application.Interfaces;
using CardapioOnline.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CardapioOnline.Infra.Data.Repository;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<User> Create(User user)
    {
        _context.Client.Add(user);
        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        var clients = await _context.Client.ToListAsync();
        return clients;
    }
    
    public async Task<User> GetByIdAsync(string id)
    {
        var client = await _context.Client.FirstOrDefaultAsync(c => c.Id == id);
        return client;
    }

    public async Task<User> Update(User user)
    {
        _context.Client.Update(user);
        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<User> Delete(string id)
    {
        var client = await _context.Client.FindAsync(id);

        _context.Client.Remove(client);
        await _context.SaveChangesAsync();

        return client;
    }
}