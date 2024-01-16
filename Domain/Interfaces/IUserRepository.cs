using CardapioOnline.Domain.Entities;

namespace CardapioOnline.Application.Interfaces;

public interface IUserRepository
{
    Task<User> Create(User user);
    Task<IEnumerable<User>> GetAllAsync();
    Task<User> Update(User user);
    Task<User> Delete(string id);

    Task<User> GetByIdAsync(string id);
}