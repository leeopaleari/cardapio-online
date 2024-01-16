using AutoMapper;
using CardapioOnline.Application.DTOs.ClientDTO;
using CardapioOnline.Application.Interfaces;
using CardapioOnline.Domain.Entities;

namespace CardapioOnline.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<CreateUserDto> Create(CreateUserDto userDto)
    {
        var client = _mapper.Map<User>(userDto);
        var createdClient = await _repository.Create(client);

        return _mapper.Map<CreateUserDto>(createdClient);
    }

    public async Task<UpdateUserDto> Update(UpdateUserDto userDto)
    {
        var client = _mapper.Map<User>(userDto);
        var updatedProduct = await _repository.Update(client);

        return _mapper.Map<UpdateUserDto>(updatedProduct);
    }

    public async Task<UpdateUserDto> Delete(string id)
    {
        var deletedClient = await _repository.Delete(id);

        return _mapper.Map<UpdateUserDto>(deletedClient);
    }

    public async Task<IList<ReadUserDto>> GetAllAsync()
    {
        var clients = await _repository.GetAllAsync();

        return _mapper.Map<IList<ReadUserDto>>(clients);
    }

    public async Task<ReadUserDto> GetByIdAsync(string id)
    {
        var product = await _repository.GetByIdAsync(id);

        return _mapper.Map<ReadUserDto>(product);
    }
}