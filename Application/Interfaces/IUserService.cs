using CardapioOnline.Application.DTOs.ClientDTO;

namespace CardapioOnline.Application.Interfaces;

public interface IUserService
{
    Task<CreateUserDto> Create(CreateUserDto user);
    Task<UpdateUserDto> Update(UpdateUserDto user);
    Task<UpdateUserDto> Delete(string id);
    Task<IList<ReadUserDto>> GetAllAsync();
    Task<ReadUserDto> GetByIdAsync(string id);
}