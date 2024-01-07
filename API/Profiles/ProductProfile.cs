using AutoMapper;
using CardapioOnline.API;
using CardapioOnline.API.Models;

namespace CardapioOnline.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<CreateProductDto, Product>();
        CreateMap<Product, ReadProductDto>();
        CreateMap<Product, UpdateProductDto>();
    }
}