using AutoMapper;
using CardapioOnline.Application.DTOs.ClientDTO;
using CardapioOnline.Domain.Entities;

namespace CardapioOnline.Application.Mappings;

public class ClientMapping : Profile
{
    public ClientMapping()
    {
        CreateMap<CreateUserDto, User>().ReverseMap();
        CreateMap<User, ReadUserDto>();
        CreateMap<User, UpdateUserDto>();
    }
}